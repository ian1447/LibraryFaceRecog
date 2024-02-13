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
    public partial class BookBorrowerSearchForm : DevExpress.XtraEditors.XtraForm
    {
        public BookBorrowerSearchForm()
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
                if (!gvBorrower.IsGroupRow(gvBorrower.FocusedRowHandle))
                {
                    if (gvBorrower.SelectedRowsCount > 0)
                    {
                        int selectedRowId = Convert.ToInt32(gvBorrower.GetRowCellValue(gvBorrower.FocusedRowHandle, "id"));
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
        public int BorrowerId = 0;
        DataTable BorrowerTable = new DataTable();
        private void BoorBorrowerSearchForm_Shown(object sender, EventArgs e)
        {
            if (!bwGetBorrower.IsBusy)
            {
                ShowLoading("Loading Borrowers...");
                bwGetBorrower.RunWorkerAsync();
            }
        }        
        
        private void bwGetBorrower_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowerTable = Register.GetRegisteredBorrowers(_type);
            bwGetBorrower.CancelAsync();
        }

        private void bwGetBorrower_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.GetRegisteredBorrowersSuccessful)
            {
                dtBorrower.DataSource = BorrowerTable;
            }
            else
                Msgbox.Error(Register.GetRegisteredBorrowersErrorMessage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
                this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBorrower.GetFocusedRow();
                BorrowerId = Convert.ToInt32(focusRowView.Row[0].ToString());
                this.Close();
            }
            else
                Msgbox.Exclamation("Please select a borrower.");
        }

        private void gvBorrower_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBorrower.GetFocusedRow();
                lblName.Text = focusRowView.Row[4].ToString();
            }
        }

        private void gvBorrower_ColumnFilterChanged(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvBorrower.GetFocusedRow();
                lblName.Text = focusRowView.Row[4].ToString();
            }
        }
    }
}