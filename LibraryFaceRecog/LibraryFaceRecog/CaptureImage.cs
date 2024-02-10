using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Text.RegularExpressions;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.IO.Ports;
using System.Globalization;
using System.Net;
using LibraryFaceRecog.Core;
using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LibraryFaceRecog
{
    public partial class CaptureImage : DevExpress.XtraEditors.XtraForm
    {
        #region variablesfordetection
        HaarCascade faceDetected;
        Image<Bgr, Byte> Frame;
        Emgu.CV.Capture camera;
        Image<Gray, byte> result;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> Users = new List<string>();
        int Count, Numlabels, t;
        string name, names, errm, filename;
        #endregion

        public CaptureImage()
        {
            InitializeComponent();
        }

        #region UTIL
        bool loadingIsAlreadyShowing = false;
        private void ShowLoading(string message)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = false;
                }

                if (!loadingIsAlreadyShowing)
                {
                    loadingIsAlreadyShowing = true;
                    splashScreenManager1.ShowWaitForm();
                }
                splashScreenManager1.SetWaitFormDescription(message);
            }
            catch { }
        }

        private void HideLoading()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    c.Enabled = true;
                }

                loadingIsAlreadyShowing = false;
                splashScreenManager1.CloseWaitForm();
            }
            catch { }
        }

        #endregion

        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool CameraConnected;
        private bool programFirstLoad,HasDetection;

        private void CaptureImage_Shown(object sender, EventArgs e)
        {
            ShowLoading("Loading Dependencies...");
            faceDetected = new HaarCascade("BisuHaarcascade.xml");
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
            programFirstLoad = false;
            int cameraCounter = 0;
            foreach (FilterInfo Device in CaptureDevice)
            {
                cmbCameraList.Properties.Items.Add(Device.Name);
                cameraCounter++;
            }
            if (cameraCounter.Equals(0))
            {
                CameraConnected = false;
                Msgbox.QuestionWarning("No camera detected!\nDo you still want to continue?");
                if (Msgbox.isYes)
                    btnCapture.Enabled = false;
                else
                    this.Dispose();
            }
            else
            {
                cmbCameraList.SelectedIndex = 0;
                // cmbCameraList.Enabled = false;
                CameraConnected = true;
                StartCamera();
            }

            programFirstLoad = true;
            HideLoading();
        }

        private void CaptureImage_Load(object sender, EventArgs e)
        {
        }

        private void StartCamera()
        {
            camera = new Emgu.CV.Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);
        }

        public void FrameProcedure(object sender, EventArgs e)
        {
            if (CameraConnected)
            {
                Users.Add("");
                Frame = camera.QueryFrame().Resize(800, 720, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayFace = Frame.Convert<Gray, Byte>();
                MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 100));
                btnCapture.Enabled = faceDetectedNow[0].Count() > 0?true:false;
                CameraBox.Image = Frame;
                names = "";
            }
        }


        private void cmbCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCameraList.SelectedIndex > -1)
            {
                cmbResolution.Properties.Items.Clear();
                //load all camera capabilities:
                FinalFrame = new VideoCaptureDevice(CaptureDevice[cmbCameraList.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
                FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 

                int a = FinalFrame.VideoCapabilities.Length, resCount = 0;
                for (int i = 0; i < FinalFrame.VideoCapabilities.Length; i++)
                {

                    string resolution_size = FinalFrame.VideoCapabilities[i].FrameSize.ToString();

                    string resSizeLength = FinalFrame.VideoCapabilities[i].FrameSize.Height.ToString();
                    string resSizeWidth = FinalFrame.VideoCapabilities[i].FrameSize.Width.ToString();
                    cmbResolution.Properties.Items.Add(string.Concat(resSizeWidth, "x", resSizeLength));
                    resCount++;
                }

                cmbResolution.SelectedIndex = 0;
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //try
            //{
            //    Bitmap cameraImage = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
            //    var filter = new Mirror(false, false);
            //    filter.ApplyInPlace(cameraImage);
            //    Frame = camera.QueryFrame().Resize(800, 720, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //    grayFace = Frame.Convert<Gray, Byte>();
            //    MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 100));
            //    foreach (MCvAvgComp f in faceDetectedNow[0])
            //    {
            //        result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //        Frame.Draw(f.rect, new Bgr(Color.Green), 3);
            //        //if (trainingImages.ToArray().Length != 0)
            //        //{
            //        //    MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
            //        //    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(),labels.ToArray(),1500,ref termCriterias);
            //        //    name = recognizer.Recognize(result);
            //        //    Frame.Draw(name, ref font, new Point(f.rect.X -2,f.rect.Y-2),new Bgr(Color.Red));
            //        //}
            //        ////Users[t - 1] = name;
            //        //Users.Add("");
            //    }
            //    CameraBox.Image = Frame;
            //}
            //catch { }
        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResolution.SelectedIndex > -1)
            {
                RestartCamera();
            }
        }

        private void RestartCamera()
        {
            if (programFirstLoad)
            {
                StopCamera();
                StartCamera();
            }
        }

        private void StopCamera()
        {
            try
            {
                camera = new Emgu.CV.Capture();
                camera.Dispose();
                CameraConnected = false;
            }
            catch (Exception ex) { Msgbox.Error(ex.Message); }
        }

        private void CaptureImage_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            if (CameraConnected)
                StopCamera();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
            {
                if (CameraConnected)
                    StopCamera();
                this.Close();
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            peCapturedImage.Image = CameraBox.Image;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}