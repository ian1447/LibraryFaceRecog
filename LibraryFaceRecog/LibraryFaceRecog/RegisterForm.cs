using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LibraryFaceRecog.Core;
using LibraryFaceRecog.Dal;
using System.IO;

namespace LibraryFaceRecog
{
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        public RegisterForm()
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

        public bool IsAdd = true;
        public int EditId;
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            btnSave.Text = !IsAdd ? "Edit" : "Add";
        }
        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (peCapturedImage.Image == null)
            {
                CaptureImage ci = new CaptureImage();
                ci.ShowDialog();
                if (ci.CapturedImage.Image != null)
                    peCapturedImage.Image = ci.CapturedImage.Image;
            }
            else
            {
                Msgbox.QuestionYesNo("Are you sure you want to retake picture?");
                if (Msgbox.isYes)
                {   
                    CaptureImage ci = new CaptureImage();
                    ci.ShowDialog();
                    if (ci.CapturedImage.Image != null)
                        peCapturedImage.Image = ci.CapturedImage.Image;
                }
            } 
        }

        bool IsGood;
        MemoryStream ms = new MemoryStream();
        byte[] img;
        private void btnSave_Click(object sender, EventArgs e)
        {
            IsGood = true;
            foreach (Control x in this.layoutControl1.Controls)
            {
                if (x is TextEdit)
                {
                    if (string.IsNullOrEmpty((x as TextEdit).Text))
                    {
                        Msgbox.Exclamation("Please Input " + (x as TextEdit).Name.ToString().Remove(0, 3).Trim(':') + "!");
                        (x as TextEdit).Focus();
                        (x as TextEdit).Select();
                        IsGood = false;
                        break;
                    }

                }
                if (x is ComboBoxEdit)
                {
                    if ((x as ComboBoxEdit).EditValue == null)
                    {
                        Msgbox.Exclamation("Please Input " + (x as TextEdit).Name.ToString().Remove(0, 3).Trim(':') + "!");
                        IsGood = false;
                        break;
                    }
                }
            }
            if (peCapturedImage.Image == null)
            {
                IsGood = false;
                Msgbox.Exclamation("Image needeed. \n\n Please Capture Image.");
            }

            if (IsGood)
            {
                img = ImageToByteArray(peCapturedImage.Image);
                if (IsAdd)
                {
                    if (!bwSaveDetails.IsBusy)
                    {
                        ShowLoading("Saving Details...");
                        bwSaveDetails.RunWorkerAsync();
                    }
                }
                else
                {
                    if (!bwEditDetails.IsBusy)
                    {
                        ShowLoading("Editing Details");
                        bwEditDetails.RunWorkerAsync();
                    }
                    //Msgbox.Information("Feature to be implemented...");
                    //this.Close();
                }
            }
        }
        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); 
                return ms.ToArray();
            }
        }

        private void bwSaveDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            Register.RegisteredBorrowersAdd(txtContactNo.Text,txtFirstName.Text, txtMiddleInitial.Text, txtFamilyName.Text, cmbSex.Text, txtCourse.Text, txtYear.Text, txtSection.Text, img);
            bwSaveDetails.CancelAsync();
        }

        private void bwSaveDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.RegisteredBorrowersAddSuccessful)
            {
                Msgbox.Information("Save Successfull");
                this.Close();
            }
            else
                Msgbox.Error(Register.RegisteredBorrowersAddErrorMessage);
        }

        private void bwEditDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            Register.RegisteredBorrowersEdit(txtContactNo.Text,txtFirstName.Text, txtMiddleInitial.Text, txtFamilyName.Text, cmbSex.Text, txtCourse.Text, txtYear.Text, txtSection.Text, img,EditId);
            bwEditDetails.CancelAsync();
        }

        private void bwEditDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.RegisteredBorrowersEditSuccessful)
            {
                Msgbox.Information("Edit Successfull");
                this.Close();
            }
            else
                Msgbox.Error(Register.RegisteredBorrowersEditErrorMessage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
                this.Close();
        }
    }
}