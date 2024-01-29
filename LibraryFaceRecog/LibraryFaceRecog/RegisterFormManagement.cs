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
    public partial class RegisterFormManagement : DevExpress.XtraEditors.XtraForm
    {
        public RegisterFormManagement()
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
                if (gvBorrow.GetRowHandle(gvBorrow.FocusedRowHandle) >= 0)
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.ShowDialog();
        }

        DataTable BorrowersTable = new DataTable();
        private void RegisterFormManagement_Shown(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (!bwGetDetails.IsBusy)
            {
                ShowLoading("Loading Data...");
                bwGetDetails.RunWorkerAsync();
            }
        }

        private void bwGetDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowersTable = Register.GetRegisteredBorrowers();
            bwGetDetails.CancelAsync();
        }

        private void bwGetDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.GetRegisteredBorrowersSuccessful)
                dtBorrow.DataSource = BorrowersTable;
            else
                Msgbox.Error(Register.GetRegisteredBorrowersErrorMessage);
        }
    }
}