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
    public partial class BookBorrowManagement : DevExpress.XtraEditors.XtraForm
    {
        public BookBorrowManagement()
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
                if (!gvBorrow.IsGroupRow(gvBorrow.FocusedRowHandle))
                {
                    if (gvBorrow.SelectedRowsCount > 0)
                    {
                        int selectedRowId = Convert.ToInt32(gvBorrow.GetRowCellValue(gvBorrow.FocusedRowHandle, "id"));
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

        private void BookBorrowManagement_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (!bwGetBorrowedDetails.IsBusy)
            {
                ShowLoading("Loading data...");
                bwGetBorrowedDetails.RunWorkerAsync();
            }
        }

        DataTable BorrowedDetails = new DataTable();
        private void bwGetBorrowedDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowedDetails = Borrower.GetBorrowedBooks();
            bwGetBorrowedDetails.CancelAsync();
        }

        private void bwGetBorrowedDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Borrower.GetBorrowedBooksSuccessful)
            {
                dtBorrow.DataSource = BorrowedDetails;
            }
            else
                Msgbox.Error(Borrower.GetBorrowedBooksErrorMessage);
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            BookBorrowForm bbf = new BookBorrowForm();
            bbf.ShowDialog();
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            BookReturnForm bbf = new BookReturnForm();
            bbf.ShowDialog();
        }
    }
}