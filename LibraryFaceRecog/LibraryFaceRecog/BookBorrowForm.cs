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

namespace LibraryFaceRecog
{
    public partial class BookBorrowForm : DevExpress.XtraEditors.XtraForm
    {
        public BookBorrowForm()
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

        DataTable BorrowersTable = new DataTable();
        int bookid, BorrowerId;
        private void txtBookTitle_Click(object sender, EventArgs e)
        {
            bool OpenSearchGood = true;

            if (!string.IsNullOrEmpty(meBookTitle.Text))
            {
                Msgbox.QuestionYesNo("Are you sure you want to change Book?");
                if (!Msgbox.isYes)
                    OpenSearchGood = false;
            }

            if (OpenSearchGood)
            {
                BookSearchForm bsf = new BookSearchForm();
                bsf.ShowDialog();
                if (!string.IsNullOrEmpty(bsf.BookTitle))
                {
                    meBookTitle.Text = bsf.BookTitle;
                    bookid = bsf.BookId;
                }
            }
        }

        private void btnLoadCamera_Click(object sender, EventArgs e)
        {
            FaceDetector fd = new FaceDetector();
            fd.ShowDialog();
            if (!string.IsNullOrEmpty(fd.lblName.Text))
            {
                BorrowerId = fd.RegisteredUserId;
                txtBorrowerName.Text = fd.lblName.Text;
                if (!bwGetBorrowerDetails.IsBusy)
                {
                    ShowLoading("Loading Data...");
                    bwGetBorrowerDetails.RunWorkerAsync();
                }
            }
        }

        private void bwGetBorrowerDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowersTable = Register.GetRegisteredBorrowers("Bisu");
            bwGetBorrowerDetails.CancelAsync();
        }

        private void bwGetBorrowerDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            DataTable FinalData = new DataTable();
            if (Register.GetRegisteredBorrowersSuccessful)
            {
                FinalData = BorrowersTable.AsEnumerable().Where(row => row.Field<int>("id") == BorrowerId).CopyToDataTable();
                txtCourse.Text = FinalData.Rows[0]["course"].ToString();
                txtSection.Text = FinalData.Rows[0]["section"].ToString();
                txtSex.Text = FinalData.Rows[0]["sex"].ToString();
                txtYear.Text = FinalData.Rows[0]["year"].ToString();
            }
            else
                Msgbox.Error(Register.GetRegisteredBorrowersErrorMessage);
        }

        bool IsGood;
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
                if (x is MemoEdit)
                {
                    if ((x as MemoEdit).EditValue == null)
                    {
                        Msgbox.Exclamation("Please Input " + (x as MemoEdit).Name.ToString().Remove(0, 3).Trim(':') + "!");
                        IsGood = false;
                        break;
                    }
                }
            }

            if (IsGood)
            {
                Msgbox.Information("Saved");
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
                this.Close();
        }
    }
}