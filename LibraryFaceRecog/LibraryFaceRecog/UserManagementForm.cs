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
    public partial class UserManagementForm : DevExpress.XtraEditors.XtraForm
    {
        public UserManagementForm()
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

        #region Variables
        DataTable UserListLegacy = new DataTable();
        DataTable UserActiveList = new DataTable();
        DataTable UserInactiveList = new DataTable();

        bool IsAdd = false;

        #endregion

        private void UserManagementForm_Shown(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void LoadDetails()
        {
            if (!bwGetDetails.IsBusy)
            {
                ShowLoading("Loading Data...");
                bwGetDetails.RunWorkerAsync();
            }
        }

        private void bwGetDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            UserListLegacy = User.GetUsers();
            bwGetDetails.CancelAsync();
        }

        private void bwGetDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (User.GetUsersSuccessful)
            {
                UserActiveList = UserListLegacy.AsEnumerable()
                      .Where(row => row.Field<Boolean>("is_active") == true).Count() > 0 ? UserListLegacy.AsEnumerable()
                      .Where(row => row.Field<Boolean>("is_active") == true).CopyToDataTable() : new DataTable();
                UserInactiveList = UserListLegacy.AsEnumerable()
                    .Where(row => row.Field<Boolean>("is_active") == false).Count() > 0 ? UserListLegacy.AsEnumerable()
                    .Where(row => row.Field<Boolean>("is_active") == false).CopyToDataTable() : new DataTable();
                dtUsers.DataSource = UserActiveList;
                lcgUser.Enabled = false;
            }
            else
                Msgbox.Error(User.GetUsersErrorMessage);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDetails();
        }

        private void chkShowActive_CheckedChanged(object sender, EventArgs e)
        {
            dtUsers.DataSource = chkShowInactive.Checked ? UserInactiveList : UserActiveList;
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Properties.PasswordChar = chkShowPass.Checked ? '\0' : '*';
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsAdd = true;
            lcgUser.Enabled = true;
            ButtonState(false);
        }

        private void ButtonState(bool state)
        {
            btnAdd.Enabled = state;
            btnEdit.Enabled = state;
            btnDeact.Enabled = state;
            btnRefresh.Enabled = state;
            chkShowInactive.Enabled = state;
            lcgUserList.Enabled = state;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lcgUser.Enabled = false;
            ButtonState(true);
        }

    }
}