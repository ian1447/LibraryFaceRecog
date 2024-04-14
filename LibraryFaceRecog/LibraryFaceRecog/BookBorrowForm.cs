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
using LibraryFaceRecog.Sop;
using LibraryFaceRecog.Reports;
using DevExpress.XtraReports.UI;

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
        string barcode;
        string bookauthor;
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
                    bookauthor = bsf.BookAuthor;
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
            BorrowersTable = Register.GetRegisteredBorrowers(PublicVariables.AccountType);
            bwGetBorrowerDetails.CancelAsync();
        }

        private void bwGetBorrowerDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            DataTable FinalData = new DataTable();
            if (Register.GetRegisteredBorrowersSuccessful)
            {
                try
                {
                    FinalData = BorrowersTable.AsEnumerable().Where(row => row.Field<int>("id") == BorrowerId).CopyToDataTable();
                    txtCourse.Text = FinalData.Rows[0]["course"].ToString();
                    txtSection.Text = FinalData.Rows[0]["section"].ToString();
                    txtSex.Text = FinalData.Rows[0]["sex"].ToString();
                    txtYear.Text = FinalData.Rows[0]["year"].ToString();
                }
                catch
                {
                    Msgbox.Exclamation("No one was selected...");
                }
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
                        Msgbox.Exclamation("Please input all fields.");
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
                        Msgbox.Exclamation("Please input all fields.");
                        IsGood = false;
                        break;
                    }
                }
            }

            if (IsGood)
            {
                barcode = (bookid.ToString() + GetRandom() + BorrowerId.ToString() + GetRandom() + DateTime.Now.ToString()).EncryptString().Substring(0, 10);
                if (!bwSaveBorrower.IsBusy)
                {
                    ShowLoading("Generating Barcode and saving...");
                    bwSaveBorrower.RunWorkerAsync();
                }
            }
        }

        public string GetRandom()
        {
            Random res = new Random();
            String str = "abcdefghijklmnopqrstuvwxyz";
            String ran = "";
            for (int i = 0; i < 2; i++)
            {
                int x = res.Next(26);
                ran = ran + str[x];
            }
            return ran;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
                this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            BookBorrowerSearchForm bbsf = new BookBorrowerSearchForm();
            bbsf.ShowDialog();
            if (bbsf.BorrowerId > 0)
            {
                BorrowerId = bbsf.BorrowerId;
                txtBorrowerName.Text =bbsf.lblName.Text;
                if (!bwGetBorrowerDetails.IsBusy)
                {
                    ShowLoading("Loading Data...");
                    bwGetBorrowerDetails.RunWorkerAsync();
                }
            }
        }

        private void bwSaveBorrower_DoWork(object sender, DoWorkEventArgs e)
        {
            Borrower.BorrowBook(bookid,BorrowerId,barcode);
            bwSaveBorrower.CancelAsync();
        }

        private void bwSaveBorrower_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Borrower.BorrowBookSuccessful)
            {
                Msgbox.Information("Barcode for return is:\n\n" + barcode);
                if (PublicVariables.AccountType == "Bisu")
                {
                    ReturnForm rf = new ReturnForm();
                    rf.lblDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
                    rf.lblBookTitle.Text = meBookTitle.Text;
                    rf.lblBorrower.Text = txtBorrowerName.Text;
                    rf.lblAuthor.Text = bookauthor;
                    rf.xrBarCode.Text = barcode;
                    rf.lblReturnDay.Text = PublicVariables.AccountType == "Bisu" ? "Note: Please Return within 3 Days. Thank you." : "Note: Please Return within 5 Days. Thank you.";
                    rf.ShowPreviewDialog();
                    this.Close();
                }
                else
                {
                    CongReturnForm rf = new CongReturnForm();
                    rf.lblDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
                    rf.lblBookTitle.Text = meBookTitle.Text;
                    rf.lblBorrower.Text = txtBorrowerName.Text;
                    rf.lblAuthor.Text = bookauthor;
                    rf.xrBarCode.Text = barcode;
                    rf.lblReturnDay.Text = PublicVariables.AccountType == "Bisu" ? "Note: Please Return within 3 Days. Thank you." : "Note: Please Return within 5 Days. Thank you.";
                    rf.ShowPreviewDialog();
                    this.Close();
                }
            }
            else
                Msgbox.Error(Borrower.BorrowBookErrorMessage);
        }
    }
}