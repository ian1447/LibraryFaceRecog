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

namespace LibraryFaceRecog
{
    public partial class CaptureImage : DevExpress.XtraEditors.XtraForm
    {
        public CaptureImage()
        {
            InitializeComponent();
        }

        private FilterInfoCollection CaptureDevice; // list of webcam
        private VideoCaptureDevice FinalFrame;
        private bool CameraConnected;
        private bool programFirstLoad;

        private void CaptureImage_Load(object sender, EventArgs e)
        {
            //System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(PublicVariables.ImageDir);
            //foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();

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

                    string resolution = "Resolution Number " + Convert.ToString(i);
                    string resolution_size = FinalFrame.VideoCapabilities[i].FrameSize.ToString();

                    string resSizeLength = FinalFrame.VideoCapabilities[i].FrameSize.Height.ToString();
                    string resSizeWidth = FinalFrame.VideoCapabilities[i].FrameSize.Width.ToString();
                    cmbResolution.Properties.Items.Add(string.Concat(resSizeWidth, "x", resSizeLength));
                    resCount++;
                }

                cmbResolution.SelectedIndex = 0;

                //if (resCount > 0)
                //    cmbResolution.SelectedIndex = Properties.Settings.Default.ResolutionIndex;
            }
        }



        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            try
            {
                Bitmap cameraImage = (Bitmap)eventArgs.Frame.Clone();// clone the bitmap
                var filter = new Mirror(false, false);
                filter.ApplyInPlace(cameraImage);
                peLiveCapture.Image = cameraImage;
            }
            catch { }
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
            peCapturedImage.Image = peLiveCapture.Image;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}