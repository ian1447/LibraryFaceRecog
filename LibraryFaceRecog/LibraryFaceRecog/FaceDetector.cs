using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emgu.CV;
using Emgu.CV.Structure;
using System.IO;
using LibraryFaceRecog.Core;
using LibraryFaceRecog.Dal;
using AForge.Video.DirectShow;

namespace LibraryFaceRecog
{
    public partial class FaceDetector : DevExpress.XtraEditors.XtraForm
    {
        public FaceDetector()
        {
            InitializeComponent();
        }
        #region variablesfordetection
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        HaarCascade faceDetected;
        Image<Bgr, Byte> Frame;
        Emgu.CV.Capture camera;
        Image<Gray, byte> result;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayFace = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> Users = new List<string>();
        string filename = (Application.StartupPath + "\\Faces") + "/Faces.txt";
        DataTable RegisteredUsers = new DataTable();
        int Count = 0;
        #endregion

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
        private bool programFirstLoad;
        public int RegisteredUserId;
        private void FaceDetector_Shown(object sender, EventArgs e)
        {
           // faceDetected = new HaarCascade("BisuHaarcascade.xml");
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
                    btnSelect.Enabled = false;
                else
                    this.Dispose();
            }
            else
            {
                cmbCameraList.SelectedIndex = 0;
                CameraConnected = true;
                StartCamera();
            }

            programFirstLoad = true;
            File.WriteAllText(filename, String.Empty);
            string ImagePath = (Application.StartupPath + "\\Faces");
            foreach (string imageFileName in Directory.GetFiles(ImagePath, "*.jpg"))
            {
                File.Delete(imageFileName);
            }
            RegisteredUsers = Register.GetRegisteredBorrowers("Bisu");
            foreach (DataRow row in RegisteredUsers.Rows)
            {
                Count += 1;
                byte[] img = (byte[])row["image"];
                MemoryStream ms = new MemoryStream(img);
                Bitmap bmImage = new Bitmap(Image.FromStream(ms));
                Image<Bgr, Byte> dbimage = new Image<Bgr, byte>(bmImage);
                //CaptureImage.Image = dbimage;
                Image<Bgr, Byte> Frame = (Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>)dbimage;
                grayFace = Frame.Convert<Gray, Byte>();
                // grayFace = camera.QueryGrayFrame().Resize(800, 720, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                MCvAvgComp[][] DetectedFaces = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 100));
                foreach (MCvAvgComp f in DetectedFaces[0])
                {
                    result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    TrainedFace = Frame.Copy(f.rect).Convert<Gray, byte>();
                   // CaptureImage.Image = TrainedFace;
                    break;
                }
                if (DetectedFaces[0].Count() > 0)
                {
                    TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    //CaptureImage.Image = TrainedFace;
                    trainingImages.Add(TrainedFace);
                    labels.Add(row[0].ToString());
                    File.WriteAllText(filename, trainingImages.ToArray().Length.ToString() + ",");
                    for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                    {
                        trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".jpg");
                        File.AppendAllText(filename, labels.ToArray()[i - 1] + ",");
                    }
                }
                else
                    Msgbox.Error("No Face Detected");
            }
            HideLoading();
        }

        private void StartCamera()
        {
            camera = new Emgu.CV.Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);
        }


        public void FrameProcedure(object sender, EventArgs e)
        {
            DataTable ForName = new DataTable();
            if (CameraConnected)
            {
                Users.Add("");
                Frame = camera.QueryFrame().Resize(800, 720, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayFace = Frame.Convert<Gray, Byte>();
                MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 100));
                foreach (MCvAvgComp f in faceDetectedNow[0])
                {
                    result = Frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                    Frame.Draw(f.rect, new Bgr(Color.Green), 3);
                    if (trainingImages.ToArray().Length != 0)
                    {
                        MCvTermCriteria termCriterias = new MCvTermCriteria(Count, 0.001);
                        EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingImages.ToArray(), labels.ToArray(), 1500, ref termCriterias);
                        RegisteredUserId = Convert.ToInt32(recognizer.Recognize(result).ToString());
                        ForName = RegisteredUsers.AsEnumerable().Where(row => row.Field<int>("id") == Convert.ToInt32(recognizer.Recognize(result).ToString())).CopyToDataTable();
                        lblName.Text = ForName.Rows[0][4].ToString();
                        CaptureImage.Image = Frame;
                        btnSelect.Enabled = true;
                    }
                }
                CameraBox.Image = Frame;
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

        private void cmbCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCameraList.SelectedIndex > -1)
            {
                cmbResolution.Properties.Items.Clear();
                //load all camera capabilities:
                FinalFrame = new VideoCaptureDevice(CaptureDevice[cmbCameraList.SelectedIndex].MonikerString);

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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            //Image<Bgr, Byte> Frame = (Emgu.CV.Image<Emgu.CV.Structure.Bgr, byte>)CaptureImage.Image;
            //grayFace = Frame.Convert<Gray, Byte>();
            //MCvAvgComp[][] faceDetectedNow = grayFace.DetectHaarCascade(faceDetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(100, 100));
            //if (faceDetectedNow[0].Count() < 1)
            //{
            //    Msgbox.Information("Cannot Close");
            //}
            //else
            Msgbox.QuestionYesNo("Are you sure you want to select " + lblName.Text + " as borrower?");
            if (Msgbox.isYes)
            {
                if (CameraConnected)
                    StopCamera();
                this.Close();
            }
        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResolution.SelectedIndex > -1)
            {
                RestartCamera();
            }
        }

        private void FaceDetector_FormClosed(object sender, FormClosedEventArgs e)
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

    }
}