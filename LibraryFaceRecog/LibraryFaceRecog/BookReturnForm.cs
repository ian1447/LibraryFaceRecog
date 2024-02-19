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
    public partial class BookReturnForm : DevExpress.XtraEditors.XtraForm
    {
        public BookReturnForm()
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

        int BorrowerId;
        private void btnFaceRecog_Click(object sender, EventArgs e)
        {
            FaceDetector fd = new FaceDetector();
            fd.ForReturn = true;
            fd.ShowDialog();
            if (!string.IsNullOrEmpty(fd.lblName.Text))
            {
                BorrowerId = fd.RegisteredUserId;
                txtBorrowerName.Text = fd.lblName.Text;
                btnOpen.Visible = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBorrowerName.Text))
            {
                BookBorrowedSearchForm bbsf = new BookBorrowedSearchForm();
                bbsf.borrowerid = BorrowerId;
                bbsf.ShowDialog();
                txtBarcode.Text = bbsf.barcode;
            }
            else
                Msgbox.Exclamation("Please select a returner or scan a barcode");
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!bwReturnBook.IsBusy)
            {
                ShowLoading("Returning Book...");
                bwReturnBook.RunWorkerAsync();
            }
        }

        private void bwReturnBook_DoWork(object sender, DoWorkEventArgs e)
        {
            Borrower.ReturnBook(txtBarcode.Text);
            bwReturnBook.CancelAsync();
        }

        private void bwReturnBook_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Borrower.ReturnBookSuccessful)
            {
                Msgbox.Information("Book Successfully returned...");
                this.Close();
            }
            else
                Msgbox.Error(Borrower.ReturnBookErrorMessage);
        }
    }
}