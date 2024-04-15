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
using LibraryFaceRecog.Reports;
using DevExpress.XtraReports.UI;

namespace LibraryFaceRecog
{
    public partial class EntranceManagementForm : DevExpress.XtraEditors.XtraForm
    {
        public EntranceManagementForm()
        {
            InitializeComponent();
        }

        DataTable dataPeriod = new DataTable();
        DateTime dateFrom = new DateTime();
        DateTime dateTo = new DateTime();
        bool Firstload = true;

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
                if (!gvLogs.IsGroupRow(gvLogs.FocusedRowHandle))
                {
                    if (gvLogs.SelectedRowsCount > 0)
                    {
                        int selectedRowId = Convert.ToInt32(gvLogs.GetRowCellValue(gvLogs.FocusedRowHandle, "id"));
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

        private void EntranceManagementForm_Shown(object sender, EventArgs e)
        {
            pnlDates.Location = new Point(
                   this.ClientSize.Width / 2 - pnlDates.Size.Width / 2,
                   this.ClientSize.Height / 3 - pnlDates.Size.Height / 2);
            dataPeriod.Columns.Add("Period", typeof(string));
            dataPeriod.Rows.Add("Today's Record");
            dataPeriod.Rows.Add("This Week's Record");
            dataPeriod.Rows.Add("This Month's Record");
            dataPeriod.Rows.Add("All Records");
            dataPeriod.Rows.Add("Pick a date..");
            luePeriod.Properties.DataSource = dataPeriod;
            luePeriod.Properties.DisplayMember = "Period";
            luePeriod.Properties.ValueMember = "Period";
            luePeriod.EditValue = "Today's Record";
            Firstload = false;
            LoadData();
        }

        private void LoadData()
        {
            if (!Firstload)
            {
                if (!bwGetEntranceLogs.IsBusy)
                {
                    ShowLoading("Loading logs...");
                    bwGetEntranceLogs.RunWorkerAsync();
                }
            }
        }

        private void luePeriod_EditValueChanged(object sender, EventArgs e)
        {
            pnlDates.Visible = luePeriod.Text.Equals("Pick a date..") ? true : false;
            DateTime baseDate = DateTime.Now;
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

        private void btnEntrance_Click(object sender, EventArgs e)
        {
            EntranceFaceDetector efd = new EntranceFaceDetector();
            efd.ShowDialog();
            btnRefresh.PerformClick();
        }

        DataTable EntranceLogTable = new DataTable();
        private void bwGetEntranceLogs_DoWork(object sender, DoWorkEventArgs e)
        {
            EntranceLogTable = Entrance.GetLogs(dateFrom,dateTo);
            bwGetEntranceLogs.CancelAsync();
        }

        private void bwGetEntranceLogs_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Entrance.GetLogsSuccessful)
            {
                //EntranceLogTable = EntranceLogTable.AsEnumerable().Where(row => row.Field<string>("type") == PublicVariables.AccountType).Count() > 0 ?
                //    EntranceLogTable.AsEnumerable().Where(row => row.Field<string>("type") == PublicVariables.AccountType).CopyToDataTable() : new DataTable();
                dtLogs.DataSource = EntranceLogTable;
            }
            else
                Msgbox.Error(Entrance.GetLogsErrorMessage);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dateFrom = Convert.ToDateTime(dtpFrom.EditValue);
            dateTo = Convert.ToDateTime(dtpTo.EditValue);
            LoadData();
            pnlDates.Visible = false;
            layoutControlGroup1.Enabled = true;
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

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (gvLogs.RowCount > 0)
            {
                if (PublicVariables.AccountType == "Bisu")
                {
                    BisuEntranceLogsReport belr = new BisuEntranceLogsReport();
                    belr.lblDate.Text = "Entrance Report for: " + dtpFrom.Text + " - " + dtpTo.Text;
                    belr.DataSource = EntranceLogTable;
                    belr.DataMember = "CustomSqlQuery";
                    belr.ShowPreviewDialog();
                }
                else
                {
                    CongressionalEntranceLogsReport celr = new CongressionalEntranceLogsReport();
                    celr.lblDate.Text = "Entrance Report for: " + dtpFrom.Text + " - " + dtpTo.Text;
                    celr.DataSource = dtLogs.DataSource;
                    celr.DataMember = "CustomSqlQuery";
                    celr.ShowPreviewDialog();
                }
            }
            else
                Msgbox.Information("Nothing to print ");
        }
    }
}