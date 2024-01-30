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

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (peCapturedImage.Image == null)
            {
                CaptureImage ci = new CaptureImage();
                ci.ShowDialog();
                peCapturedImage.Image = ci.peCapturedImage.Image;
            }
            else
            {
                Msgbox.QuestionYesNo("Are you sure you want to retake picture?");
                if (Msgbox.isYes)
                {   
                    CaptureImage ci = new CaptureImage();
                    ci.ShowDialog();
                    peCapturedImage.Image = ci.peCapturedImage.Image;
                }
            } 
        }

        bool IsGood;
        System.Drawing.Image _image;
        private void btnSave_Click(object sender, EventArgs e)
        {
            IsGood = true;
            foreach (Control x in this.layoutControl1.Controls.OfType<TextEdit>().OrderBy(c => c.TabIndex))
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
                MemoryStream ms = new MemoryStream();
                byte[] img = ImageToByteArray(peCapturedImage.Image);
                Register.RegisteredBorrowersAdd(txtFirstName.Text, txtMiddleInitial.Text, txtFamilyName.Text, cmbSex.Text, txtCourse.Text, txtYear.Text, txtSection.Text, img);
                if (Register.RegisteredBorrowersAddSuccessful)
                    Msgbox.Show("Entry Success");
                else
                    Msgbox.Error(Register.RegisteredBorrowersAddErrorMessage);
            }
        }
        public byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Png); // You can choose different image formats
                return ms.ToArray();
            }
        }

    }
}