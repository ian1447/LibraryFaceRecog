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
    public partial class ShowBorrowerDetailsForm : DevExpress.XtraEditors.XtraForm
    {
        public ShowBorrowerDetailsForm()
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

        public int borrower_id;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowBorrowerDetailsForm_Shown(object sender, EventArgs e)
        {
            if (!bwGetDetails.IsBusy)
            {
                ShowLoading("Getting data...");
                bwGetDetails.RunWorkerAsync();
            }
        }

        DataTable Borrowertable = new DataTable();
        private void bwGetDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            Borrowertable = Register.GetRegisteredBorrowers(PublicVariables.AccountType);
            bwGetDetails.CancelAsync();
        }

        private void bwGetDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.GetRegisteredBorrowersSuccessful)
            {
                if (Borrowertable.Rows.Count > 0)
                {
                    DataTable BorrowerDetail = Borrowertable.AsEnumerable()
                        .Where(row => row.Field<int>("id") == borrower_id).CopyToDataTable();
                    txtName.Text = BorrowerDetail.Rows[0]["name"].ToString();
                    txtContactNo.Text = BorrowerDetail.Rows[0]["contact_number"].ToString();
                    txtCourse.Text = BorrowerDetail.Rows[0]["course"].ToString();
                    txtSex.Text = BorrowerDetail.Rows[0]["sex"].ToString();
                    txtYearSection.Text = BorrowerDetail.Rows[0]["year_and_section"].ToString();
                    byte[] img = (byte[])BorrowerDetail.Rows[0]["image"];
                    MemoryStream ms = new MemoryStream(img);
                    peCapturedImage.Image = Image.FromStream(ms);
                }
            }
            else
                Msgbox.Error(Register.GetRegisteredBorrowersErrorMessage);
        }


    }
}