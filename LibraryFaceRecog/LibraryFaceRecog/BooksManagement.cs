using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using LibraryFaceRecog.Dal;
using LibraryFaceRecog.Core;

namespace LibraryFaceRecog
{
    public partial class BooksManagement : DevExpress.XtraEditors.XtraForm
    {
        public BooksManagement()
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
                if (gvBooks.GetRowHandle(gvBooks.FocusedRowHandle) >= 0)
                {
                    if (gvBooks.SelectedRowsCount > 0)
                    {
                        int selectedRowId = Convert.ToInt32(gvBooks.GetRowCellValue(gvBooks.FocusedRowHandle, "id"));
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

        private void BooksManagement_Shown(object sender, EventArgs e)
        {
            if (!bwGetBooks.IsBusy)
            {
                ShowLoading("Getting Details...");
                bwGetBooks.RunWorkerAsync();
            }
        }

        DataTable BooksTable = new DataTable();
        private void bwGetBooks_DoWork(object sender, DoWorkEventArgs e)
        {
            BooksTable = Books.GetBooks("Bisu");
            bwGetBooks.CancelAsync();
        }

        private void bwGetBooks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Books.GetBooksSuccessful)
            {
                dtBooks.DataSource = BooksTable;
            }
            else
                Msgbox.Error(Books.GetBooksErrorMessage);
        }
    }
}