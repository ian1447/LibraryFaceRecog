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

namespace LibraryFaceRecog
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
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

        private void LoginSuccess()
        {
            if (txtUsername.Text != "hehe")
            {
                lblInvalid.Visible = true;
            }
            else
            {
                MainForm mf = new MainForm();
                this.Hide();
                mf.ShowDialog();
                if (Userlogout)
                {
                    txtPassword.Text = "";
                    this.Show();
                }
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
    }
}