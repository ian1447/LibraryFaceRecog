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
    public partial class EntranceManagementForm : DevExpress.XtraEditors.XtraForm
    {
        public EntranceManagementForm()
        {
            InitializeComponent();
        }

        DataTable dataPeriod = new DataTable();
        DateTime dateFrom = new DateTime();
        DateTime dateTo = new DateTime();

        private void EntranceManagementForm_Shown(object sender, EventArgs e)
        {
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
                //ViewData();
            }
            else if (luePeriod.Text.Equals("This Week's Record"))
            {
                dtpFrom.EditValue = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddDays(7).AddSeconds(-1);

                dateFrom = baseDate.AddDays(-(int)baseDate.DayOfWeek);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddDays(7).AddSeconds(-1);
               // ViewData();
            }
            else if (luePeriod.Text.Equals("This Month's Record"))
            {
                dtpFrom.EditValue = baseDate.AddDays(1 - baseDate.Day);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddMonths(1).AddSeconds(-1);

                dateFrom = baseDate.AddDays(1 - baseDate.Day);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddMonths(1).AddSeconds(-1);
             //   ViewData();
            }
            else if (luePeriod.Text.Equals("All Records"))
            {
                dtpFrom.EditValue = baseDate.AddYears(-100);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddYears(100);

                dateFrom = baseDate.AddYears(-100);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddYears(100);
               // ViewData();
            }
            else
            {
                dtpFrom.EditValue = baseDate.AddYears(-10);
                dtpTo.EditValue = Convert.ToDateTime(dtpFrom.EditValue).AddYears(10);

                dateFrom = baseDate.AddYears(-10);
                dateTo = Convert.ToDateTime(dtpFrom.EditValue).AddYears(10);
            }
        }

        private void btnEntrance_Click(object sender, EventArgs e)
        {
            EntranceFaceDetector efd = new EntranceFaceDetector();
            efd.ShowDialog();
            if (!string.IsNullOrEmpty(efd.lblName.Text))
            {
                string test = "";
                //BorrowerId = efd.RegisteredUserId;
                //txtBorrowerName.Text = efd.lblName.Text;
                //if (!bwGetBorrowerDetails.IsBusy)
                //{
                //    ShowLoading("Loading Data...");
                //    bwGetBorrowerDetails.RunWorkerAsync();
                //}
            }
        }
    }
}