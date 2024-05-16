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
        private bool programFirstLoad;
        string filename = (Application.StartupPath + "\\Checker") + "/log.txt";
        string knownpath = (Application.StartupPath + "\\Checker\\");

        private void CaptureImage_Shown(object sender, EventArgs e)
        {
            ShowLoading("Loading Dependencies...");
            programFirstLoad = false;
            int cameraCounter = 0;
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);//constructor
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
            try
            {
                if (!string.IsNullOrEmpty(cmbCameraList.Text))
                {
                    if (cmbResolution.SelectedIndex > -1)
                    {
                        FinalFrame = new VideoCaptureDevice(CaptureDevice[cmbCameraList.SelectedIndex].MonikerString);// specified web cam and its filter moniker string
                        FinalFrame.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);// click button event is fired, 
                        //FinalFrame.DesiredFrameSize = new System.Drawing.Size(1920, 1080);
                        FinalFrame.VideoResolution = FinalFrame.VideoCapabilities[cmbResolution.SelectedIndex];
                        FinalFrame.Start();
                        CameraConnected = true;
                    }
                }
            }
            catch
            {
                Msgbox.Error("Unknown error in using the camera. \nPlease attached the camera to the unit.");
                this.Dispose();
            }
        }

        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap cameraImage = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
                peCameraBox.Image = cameraImage;
            }
            catch { }
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
                if (FinalFrame.IsRunning)
                    FinalFrame.Stop();
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
            CapturedImage.Image = peCameraBox.Image;
            CapturedImage.Image.Save(knownpath + "known.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            File.WriteAllText(filename, String.Empty);
            Process facerecog = new Process()
            {
                StartInfo = new ProcessStartInfo(PublicVariables.DefaultDirectory + "\\Checker\\checkExisting.exe")
                {
                    WorkingDirectory = PublicVariables.DefaultDirectory + "\\Checker"
                }
            };
            facerecog.StartInfo.FileName = PublicVariables.DefaultDirectory + "\\Checker\\checkExisting.exe";
            facerecog.Start();
            facerecog.WaitForExit();
            StreamReader sr = new StreamReader(filename);
            string line = sr.ReadLine();
            sr.Dispose();
            if (!string.IsNullOrEmpty(line))
            {
               //Msgbox.Error("Face already Registered...");
                CapturedImage.Image = null;
                btnSave.Enabled = false;
            }
            else
                btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}