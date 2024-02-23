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
       // MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        Image<Bgr, Byte> Frame;
        Emgu.CV.Capture camera;
        string filename = (Application.StartupPath + "\\Recognize") + "/Faces.txt";
        string ImagePath = (Application.StartupPath + "\\Recognize\\images\\");
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
        public bool ForReturn = false;
        private void FaceDetector_Shown(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(filename, String.Empty);
                ShowLoading("Loading Dependencies...");
                btnSelect.Text = ForReturn ? "Select as Returner" : "Select as Borrower";
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
                    HideLoading();
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
            }
            catch (Exception ex)
            {
                Msgbox.Error(ex.Message);
            }

            programFirstLoad = true;
            foreach (string imageFileName in Directory.GetFiles(ImagePath, "*.jpg"))
            {
                File.Delete(imageFileName);
            }
            RegisteredUsers = Register.GetRegisteredBorrowers(PublicVariables.AccountType);
            foreach (DataRow row in RegisteredUsers.Rows)
            {
                byte[] img = (byte[])RegisteredUsers.Rows[0]["image"];
                MemoryStream ms = new MemoryStream(img);
                System.Drawing.Image GoodImage = System.Drawing.Image.FromStream(ms);
                GoodImage.Save(ImagePath+row[0].ToString(), System.Drawing.Imaging.ImageFormat.Jpeg);
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
                Frame = camera.QueryFrame().Resize(800, 720, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
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
            string type = btnSelect.Text == "Select as Borrower" ? "Borrower" : "Returner";
            Msgbox.QuestionYesNo("Are you sure you want to select " + lblName.Text + " as " + type + "?");
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

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CaptureImage.Image = CameraBox.Image;
            CaptureImage.Image.Bitmap.Save(ImagePath + "known.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

    }
}