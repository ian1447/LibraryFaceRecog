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
using DevExpress.XtraLayout.Utils;
using LibraryFaceRecog.Sop;

namespace LibraryFaceRecog
{
    public partial class DatabaseConnectionForm : DevExpress.XtraEditors.XtraForm
    {
        public DatabaseConnectionForm()
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

        string connstring;
        private void btnTestConnection_Click(object sender, EventArgs e)
        {   
            connstring = "SERVER = " + txtServer.Text + "; DATABASE =" + txtDatabase.Text + "; Uid =" + txtUid.Text + "; Pwd =" + txtPassword.Text + "; PORT =" + txtPort.Text + "; AllowZeroDateTime = True;";
            if (!bwCheckConnection.IsBusy)
            {
                ShowLoading("Testing Connection...");
                bwCheckConnection.RunWorkerAsync();
            }
        }

        private void bwCheckConnection_DoWork(object sender, DoWorkEventArgs e)
        {
            Login.testconnection(connstring);
            bwCheckConnection.CancelAsync();
        }

        private void bwCheckConnection_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Login.ConnectionIsGood)
            {
                btnSave.Enabled = true;
                lblConnectionStatus.Visible = true;
                lciStatusLabel.Visibility = LayoutVisibility.Always;
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = "Connection Valid.";
            }
            else
            {
                lciStatusLabel.Visibility = LayoutVisibility.Always;
                lblConnectionStatus.ForeColor = Color.Red;
                lblConnectionStatus.Text = "Connection Invalid!";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close this form?");
            if (Msgbox.isYes)
                this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DBString = connstring.EncryptString();
            Properties.Settings.Default.Save();
            Msgbox.Information("Connection String Saved. Restarting Application.");
            Application.Restart();
        }
    }
}