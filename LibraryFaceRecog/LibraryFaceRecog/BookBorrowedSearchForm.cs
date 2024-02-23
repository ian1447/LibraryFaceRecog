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
    public partial class BookBorrowedSearchForm : DevExpress.XtraEditors.XtraForm
    {
        public BookBorrowedSearchForm()
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

        private bool SelectionPass()
        {
            try
            {
                if (!gvBorrowedBooks.IsGroupRow(gvBorrowedBooks.FocusedRowHandle))
                {
                    if (gvBorrowedBooks.SelectedRowsCount > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            catch { return false; }
        }

        string _type = "Bisu";
        public int borrowerid = 0;
        public string barcode;
        DataTable BorrowedBooksTable = new DataTable();
        private void BookBorrowedSearchForm_Shown(object sender, EventArgs e)
        {
            if (!bwGetBorrowedBooks.IsBusy)
            {
                ShowLoading("Loading Borrowed Books...");
                bwGetBorrowedBooks.RunWorkerAsync();
            }
        }

        private void bwGetBorrowedBooks_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowedBooksTable = Borrower.GetBorrowedBooksbyBorrower(borrowerid);
            bwGetBorrowedBooks.CancelAsync();
        }

        private void bwGetBorrowedBooks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Borrower.GetBorrowedBooksbyBorrowerSuccessful)
            {
                dtBorrowedBooks.DataSource = BorrowedBooksTable;
            }
            else
                Msgbox.Error(Borrower.GetBorrowedBooksbyBorrowerErrorMessage);
        }

        public string booktitle, bookauthor;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBorrowedBooks.GetFocusedRow();
                barcode = focusRowView.Row["barcode"].ToString();
                booktitle = focusRowView.Row["title"].ToString();
                bookauthor = focusRowView.Row["author"].ToString();
                this.Close();
            }
            else
                Msgbox.Exclamation("Please select a borrower.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
                this.Close();
        }

        private void gvBorrowedBooks_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBorrowedBooks.GetFocusedRow();
                lblBarcode.Text = "Barcode: " + focusRowView.Row["barcode"].ToString();
            }
        }
    }
}