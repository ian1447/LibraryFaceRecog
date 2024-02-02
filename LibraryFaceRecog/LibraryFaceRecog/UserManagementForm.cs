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

        private bool SelectionPass()
        {
            try
            {
                if (!gvUsers.IsGroupRow(gvUsers.FocusedRowHandle))
                {
                    if (gvUsers.SelectedRowsCount > 0)
                    {
                        int selectedRowId = Convert.ToInt32(gvUsers.GetRowCellValue(gvUsers.FocusedRowHandle, "id"));
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

        #region Variables
        DataTable UserListLegacy = new DataTable();
        DataTable UserActiveList = new DataTable();
        DataTable UserInactiveList = new DataTable();

        bool IsAdd = false;
        string user_id;
        int mode;
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
                dtUsers.DataSource = chkShowInactive.Checked ? UserInactiveList : UserActiveList;
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
            btnDeact.Text = chkShowInactive.Checked ? "Activate" : "Deactivate";
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
            if (IsAdd)
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
            btnAdd.Enabled = state;
            btnEdit.Enabled = state;
            btnDeact.Enabled = state;
            btnRefresh.Enabled = state;
            chkShowInactive.Enabled = state;
            lcgUserList.Enabled = state;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IsAdd = false;
            lcgUser.Enabled = false;
            ButtonState(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    if (IsAdd)
                    {
                        if (!bwAddUser.IsBusy)
                        {
                            ShowLoading("Adding User...");
                            bwAddUser.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        if (!bwEditUser.IsBusy)
                        {
                            ShowLoading("Editing User...");
                            bwEditUser.RunWorkerAsync();
                        }
                    }
                }
                else
                    Msgbox.Exclamation("Password should not be empty.");
            }
            else
                Msgbox.Exclamation("Username should not be empty.");
        }

        private void bwAddUser_DoWork(object sender, DoWorkEventArgs e)
        {
            User.AddUser(txtUsername.Text, txtPassword.Text, cmbPrivilege.Text);
            bwAddUser.CancelAsync();
        }

        private void bwAddUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (User.AddUserSuccessful)
            {
                Msgbox.Information("User Added Successfully");
                IsAdd = false;
                lcgUser.Enabled = false;
                ButtonState(true);
                btnRefresh.PerformClick();
            }
            else
                Msgbox.Exclamation(User.AddUserErrorMessage);
        }

        private void gvUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvUsers.GetFocusedRow();
                txtUsername.Text = focusRowView[1].ToString();
                cmbPrivilege.Text = focusRowView[4].ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var focusRowView = (DataRowView)gvUsers.GetFocusedRow();
            user_id = focusRowView[0].ToString();
            IsAdd = false;
            btnSave.Text = "Edit";
            lcgUser.Enabled = true;
            ButtonState(false);
        }

        private void bwEditUser_DoWork(object sender, DoWorkEventArgs e)
        {
            User.Edituser(txtUsername.Text, txtPassword.Text, cmbPrivilege.Text, user_id);
            bwEditUser.CancelAsync();
        }

        private void bwEditUser_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (User.EdituserSuccessful)
            {
                Msgbox.Information("Edit Successful");
                IsAdd = false;
                lcgUser.Enabled = false;
                ButtonState(true);
                btnRefresh.PerformClick();
            }
            else
                Msgbox.Error(User.EdituserErrorMessage);
        }

        private void btnDeact_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvUsers.GetFocusedRow();
                user_id = focusRowView[0].ToString();
                mode = btnDeact.Text == "Activate" ? 1 : 0;
                Msgbox.QuestionYesNo("Are you sure to " + btnDeact.Text + " user?");
                if (Msgbox.isYes)
                {
                    if (!bwUpdateUserStatus.IsBusy)
                    {
                        ShowLoading(btnDeact.Text + "ing user...");
                        bwUpdateUserStatus.RunWorkerAsync();
                    }
                }
            }
            else
                Msgbox.Exclamation("No row selected");
        }

        private void bwUpdateUserStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            User.UpdateUserStatus(user_id, mode);
            bwUpdateUserStatus.CancelAsync();
        }

        private void bwUpdateUserStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (User.UpdateUserStatusSuccessful)
            {
                Msgbox.Information("User status updated successfully.");
                btnRefresh.PerformClick();
            }
            else
                Msgbox.Error(User.UpdateIsactiveUserErrorMessage);
        }

    }
}