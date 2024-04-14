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
using LibraryFaceRecog.Reports;
using DevExpress.XtraReports.UI;

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

        int BorrowerId = 0;
        bool firstload = true;
        private void BookBorrowManagement_Shown(object sender, EventArgs e)
        {
            pnlDates.Location = new Point(
                   this.ClientSize.Width / 2 - pnlDates.Size.Width / 2,
                   this.ClientSize.Height / 3 - pnlDates.Size.Height / 2);
            datePeriod.Columns.Add("Period", typeof(string));
            datePeriod.Rows.Add("Today's Record");
            datePeriod.Rows.Add("This Week's Record");
            datePeriod.Rows.Add("This Month's Record");
            datePeriod.Rows.Add("All Records");
            datePeriod.Rows.Add("Pick a date..");
            luePeriod.Properties.DataSource = datePeriod;
            luePeriod.Properties.DisplayMember = "Period";
            luePeriod.Properties.ValueMember = "Period";
            luePeriod.EditValue = "Today's Record";
            if (!bwGetBorrower.IsBusy)
            {
                ShowLoading("Loading Data...");
                bwGetBorrower.RunWorkerAsync();
            }
            firstload = false;
            LoadData();
        }

        private void LoadData()
        {
            if (!firstload)
            {
                if (!bwGetBorrowedDetails.IsBusy)
                {
                    ShowLoading("Loading data...");
                    bwGetBorrowedDetails.RunWorkerAsync();
                }
            }
        }

        DataTable BorrowedDetails = new DataTable();
        DataTable datePeriod = new DataTable();
        private void bwGetBorrowedDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowedDetails = Borrower.GetBorrowedBooks(dateFrom,dateTo);
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
            btnRefresh.PerformClick();
        }

        DataTable BorrowerTable = new DataTable();
        private void bwGetBorrower_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowerTable = Register.GetRegisteredBorrowers(PublicVariables.AccountType);
            bwGetBorrower.CancelAsync();
        }

        private void bwGetBorrower_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.GetRegisteredBorrowersSuccessful)
            {
                lueBorrower.Properties.DataSource = BorrowerTable;
                lueBorrower.Properties.DisplayMember = "name";
                lueBorrower.Properties.ValueMember = "id";
            }
            else
                Msgbox.Error(Register.GetRegisteredBorrowersErrorMessage);
        }

        private void lueBorrower_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
                lueBorrower.EditValue = null;
        }

        DataTable FilteredTable = new DataTable();
        private void lueBorrower_EditValueChanged(object sender, EventArgs e)
        {
            BorrowerId = lueBorrower.EditValue != null ? Convert.ToInt32(lueBorrower.EditValue.ToString()) : 0;
            if (BorrowerId != 0)
            {
                FilteredTable =  BorrowedDetails.AsEnumerable()
                          .Where(row => row.Field<int>("borrower_id") == BorrowerId).Count() > 0? BorrowedDetails.AsEnumerable()
                          .Where(row => row.Field<int>("borrower_id") == BorrowerId).CopyToDataTable() : new DataTable();
                dtBorrow.DataSource = FilteredTable;
            }
            else
                dtBorrow.DataSource = BorrowedDetails;
        }

        DateTime baseDate = DateTime.Now;
        DateTime dateFrom = new DateTime();
        DateTime dateTo = new DateTime();
        private void luePeriod_EditValueChanged(object sender, EventArgs e)
        {
            pnlDates.Visible = luePeriod.Text.Equals("Pick a date..") ? true : false;
            layoutControlGroup1.Enabled = luePeriod.Text == "Pick a date.." ? false : true;
            luePeriod.Properties.DisplayMember = "Period";

            if (luePeriod.Text.Equals("Today's Record"))
            {
                dtpTo.EditValue = DateTime.Now;
                dtpFrom.EditValue = DateTime.Now;

                dateFrom = DateTime.Now;
                dateTo = DateTime.Now;
                LoadData();
            }
            else if (luePeriod.Text.Equals("This Week's Record"))
            {
                dtpFrom.EditValue = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddDays(7).AddSeconds(-1);

                dateFrom = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddDays(7).AddSeconds(-1);
                LoadData();
            }
            else if (luePeriod.Text.Equals("This Month's Record"))
            {
                dtpFrom.EditValue = baseDate.AddDays(1 - baseDate.Day);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddMonths(1).AddSeconds(-1);

                dateFrom = baseDate.AddDays(1 - baseDate.Day);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddMonths(1).AddSeconds(-1);
                LoadData();
            }
            else if (luePeriod.Text.Equals("All Records"))
            {
                dtpFrom.EditValue = baseDate.AddYears(-100);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddYears(100);

                dateFrom = baseDate.AddYears(-100);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddYears(100);
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dateFrom = Convert.ToDateTime(dtpFrom.EditValue);
            dateTo = Convert.ToDateTime(dtpTo.EditValue);
            LoadData();
            pnlDates.Visible = false;
            layoutControlGroup1.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gvBorrow.RowCount > 0)
            {
                if (PublicVariables.AccountType == "Bisu")
                {
                    BisuBookBorrowReport bbr = new BisuBookBorrowReport();
                    bbr.lblDate.Text = "Borrow Report for: " + dtpFrom.Text + " - " + dtpTo.Text;
                    bbr.DataSource = dtBorrow.DataSource;
                    bbr.DataMember = "CustomSqlQuery";
                    bbr.ShowPreviewDialog();
                }
                else
                {
                    CongressionalBookBorrowReport cbr = new CongressionalBookBorrowReport();
                    cbr.lblDate.Text = "Borrow Report for: " + dtpFrom.Text + " - " + dtpTo.Text;
                    cbr.DataSource = dtBorrow.DataSource;
                    cbr.DataMember = "CustomSqlQuery";
                    cbr.ShowPreviewDialog();
                }
            }
            else
                Msgbox.Information("Nothing to print ");
        }

        private void luePeriod_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (luePeriod.Text == "Pick a date..")
            {
                dtpTo.EditValue = DateTime.Now;
                dtpFrom.EditValue = DateTime.Now;

                dateFrom = DateTime.Now;
                dateTo = DateTime.Now;
                layoutControlGroup1.Enabled = false;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBorrow.GetFocusedRow();
                ShowBorrowerDetailsForm sbdf = new ShowBorrowerDetailsForm();
                sbdf.borrower_id = Convert.ToInt32(focusRowView.Row["borrower_id"].ToString());
                sbdf.ShowDialog();
            }
        }
    }
}