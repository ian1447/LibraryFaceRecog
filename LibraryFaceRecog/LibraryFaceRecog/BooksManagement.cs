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

        private void BooksManagement_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
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
            BooksTable = Books.GetBooks(PublicVariables.AccountType);
            bwGetBooks.CancelAsync();
        }

        DataTable ActiveTable = new DataTable();
        private void bwGetBooks_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Books.GetBooksSuccessful)
            {
                ActiveTable = BooksTable.AsEnumerable()
                    .Where(row => row.Field<Boolean>("is_active") == true).Count() > 0 ? BooksTable.AsEnumerable()
                    .Where(row => row.Field<Boolean>("is_active") == true).CopyToDataTable() : new DataTable();
                dtBooks.DataSource = ActiveTable;
            }
            else
                Msgbox.Error(Books.GetBooksErrorMessage);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddBooksForm adf = new AddBooksForm();
            adf.ShowDialog();
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBooks.GetFocusedRow();
                AddBooksForm adf = new AddBooksForm();
                adf.IsAdd = false;
                adf.meTitle.Text = focusRowView.Row["title"].ToString();
                adf.mePlaceandPublisher.Text = focusRowView.Row["place_and_publisher"].ToString();
                adf.txtAccountNo.Text = focusRowView.Row["account_no"].ToString();
                adf.txtAuthor.Text = focusRowView.Row["author"].ToString();
                adf.txtCallNo.Text = focusRowView.Row["call_no"].ToString();
                adf.txtCopyrightYear.Text = focusRowView.Row["copyright_year"].ToString();
                adf.txtCost.Text = focusRowView.Row["edition"].ToString();
                adf.txtNoofCopies.Text = focusRowView.Row["no_of_copies"].ToString();
                adf.txtSection.Text = focusRowView.Row["section"].ToString();
                adf._edit_id = Convert.ToInt32(focusRowView.Row["id"].ToString());
                adf.ShowDialog();
                btnRefresh.PerformClick();
            }
            else
                Msgbox.Exclamation("Please select a book.");
        }

        private void gvBooks_ColumnFilterChanged(object sender, EventArgs e)
        {
            var focusRowView = (DataRowView)gvBooks.GetFocusedRow();
        }

        int deac_id = 0;
        private void btnDeac_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBooks.GetFocusedRow();
                Msgbox.QuestionYesNo("Are you sure you want to deactivate '" + focusRowView.Row["title"].ToString()+"'");
                if (Msgbox.isYes)
                {
                    deac_id = Convert.ToInt32(focusRowView.Row["id"].ToString());
                    if (!bwDeac.IsBusy)
                    {
                        ShowLoading("Deactivating Book...");
                        bwDeac.RunWorkerAsync();
                    }
                }
            }
            else
                Msgbox.Exclamation("Please select a book.");
        }

        private void bwDeac_DoWork(object sender, DoWorkEventArgs e)
        {
            Books.BookDeac(deac_id);
            bwDeac.CancelAsync();
        }

        private void bwDeac_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Books.BookDeacSuccessful)
            {
                Msgbox.Information("Book Deactivated");
                btnRefresh.PerformClick();
            }
            else
                Msgbox.Error(Books.BookDeacErrorMessage);
        }
    }
}