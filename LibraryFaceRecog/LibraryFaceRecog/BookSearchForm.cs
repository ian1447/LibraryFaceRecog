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
    public partial class BookSearchForm : DevExpress.XtraEditors.XtraForm
    {
        public BookSearchForm()
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
                if (!gvBooks.IsGroupRow(gvBooks.FocusedRowHandle))
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

        public string BookTitle, BookAuthor;
        public int BookId;
        DataTable BooksTable = new DataTable();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (!bwGetBooks.IsBusy)
                {
                    ShowLoading("Loading data...");
                    bwGetBooks.RunWorkerAsync();
                }
            }
        }

        private void bwGetBooks_DoWork(object sender, DoWorkEventArgs e)
        {
            BooksTable = Books.SearchBooks(txtSearch.Text);
            bwGetBooks.CancelAsync();
        }

        private void bwGetBooks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Books.SearchBooksSuccessful)
                dtBooks.DataSource = BooksTable;
            else
                Msgbox.Error(Books.SearchBooksErrorMessage);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBooks.GetFocusedRow();
                BookId = Convert.ToInt32(focusRowView.Row[0].ToString());
                BookTitle = focusRowView.Row["title"].ToString();
                BookAuthor = focusRowView.Row["author"].ToString();
                if (Convert.ToInt32(focusRowView.Row["no_of_copies"].ToString()) > 1)
                    this.Close();
                else
                    Msgbox.Exclamation("Cannot Borrow books with only 1 copy left.");
            }
            else
                Msgbox.Exclamation("Nothing to select.");
        }

        private void gvBooks_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBooks.GetFocusedRow();
                BookId = Convert.ToInt32(focusRowView.Row[0].ToString());
                BookTitle = focusRowView.Row[6].ToString();
                BookAuthor = focusRowView.Row["author"].ToString();
            }
        }
    }
}