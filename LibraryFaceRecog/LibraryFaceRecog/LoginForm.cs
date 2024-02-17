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
using LibraryFaceRecog.Sop;

namespace LibraryFaceRecog
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
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
        private void LoginForm_Load(object sender, EventArgs e)
        {
            PublicVariables.ConnectionString = !string.IsNullOrEmpty(Properties.Settings.Default.DBString)? Properties.Settings.Default.DBString.DecryptString(): null;
        }

        public static bool Userlogout = false;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    LoginSuccess();
                }
                else
                {
                    Msgbox.Exclamation("Please input password.");
                    txtPassword.Focus();
                }
            }
            else
            {
                Msgbox.Exclamation("Please input username.");
                txtUsername.Focus();
            }
        }

        DataTable UserData = new DataTable();
        private void LoginSuccess()
        {
            if (!bwGetUserData.IsBusy)
            {
                ShowLoading("Checking Credentials...");
                bwGetUserData.RunWorkerAsync();
            }
         
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (btnShowPass.Text == "S")
            {
                btnShowPass.Text = "H";
                txtPassword.Properties.PasswordChar = '\0';
            }
            else
            {
                btnShowPass.Text = "S";
                txtPassword.Properties.PasswordChar = '*';
            }
        }

        bool IsConGood = false;
        private void LoginForm_Shown(object sender, EventArgs e)
        {
            if (!bwCheckConnection.IsBusy)
            {
                ShowLoading("Checking Connection...");
                bwCheckConnection.RunWorkerAsync();
            }
        }

        #region CheckConnection
        private void bwCheckConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            IsConGood = Login.testconnection(PublicVariables.ConnectionString);
            bwCheckConnection.CancelAsync();
        }

        private void bwCheckConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (!IsConGood)
            {
                lblConnectionError.Visible = true;
                txtPassword.Enabled = false;
                btnlogin.Enabled = false;
                btnShowPass.Enabled = false;
            }
            else
                txtUsername.Focus();
        }
        #endregion

        #region GetuserData
        private void bwGetUserData_DoWork(object sender, DoWorkEventArgs e)
        {
            UserData = Login.Userlogin(txtUsername.Text, txtPassword.Text);
            bwGetUserData.CancelAsync();
        }

        private void bwGetUserData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Login.LoginIsSuccessful)
            {
                if (UserData != null && UserData.Rows.Count > 0)
                {
                    PublicVariables.UserName = txtUsername.Text;
                    PublicVariables.AccountType = UserData.Rows[0]["privilege"].ToString() == "super-admin"? "Bisu":UserData.Rows[0]["privilege"].ToString();
                    MainForm mf = new MainForm();
                    this.Hide();
                    mf.ShowDialog();
                    if (Userlogout)
                    {
                        txtPassword.Text = "";
                        lblInvalid.Visible = false;
                        this.Show();
                    }
                }
                else
                {
                    lblInvalid.Visible = true;
                    txtUsername.Focus();
                }
            }
            else
                Msgbox.Error(Login.LoginErrorMessage);
        }
        #endregion

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            btnChangeConn.Visible = txtUsername.Text == "Change"? true:false;
        }

        private void btnChangeConn_Click(object sender, EventArgs e)
        {
            DatabaseConnectionForm dcf = new DatabaseConnectionForm();
            dcf.ShowDialog();
        }

    }
}