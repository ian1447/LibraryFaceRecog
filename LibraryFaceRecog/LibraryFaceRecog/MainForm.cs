using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using LibraryFaceRecog;

namespace LibraryFaceRecog
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoginForm.Userlogout = true;
            this.Hide();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static bool UserManagementFormIsOpen = false;
        private void btnUserManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            //UserManagementForm umf = new UserManagementForm();
            //umf.ShowDialog();
            if (!UserManagementFormIsOpen)
            {
                UserManagementFormIsOpen = true;
                UserManagementForm umf = new UserManagementForm();
                umf.MdiParent = this;
                umf.WindowState = FormWindowState.Maximized;
                umf.Show();
            }
            else
            {
                Form fc = Application.OpenForms["UserManagementForm"];
                if (fc == null)
                {
                    UserManagementForm a1 = new UserManagementForm();
                    a1.MdiParent = this;
                    a1.Show();
                }
                else
                    fc.Activate();
            }
        }

        public static bool BookManagementFormIsOpen = false;
        private void btnBooksManagement_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!BookManagementFormIsOpen)
            {
                BookManagementFormIsOpen = true;
                BooksManagement bm = new BooksManagement();
                bm.MdiParent = this;
                bm.WindowState = FormWindowState.Maximized;
                bm.Show();
            }
            else
            {
                Form fc = Application.OpenForms["BooksManagement"];
                if (fc == null)
                {
                    BooksManagement a1 = new BooksManagement();
                    a1.MdiParent = this;
                    a1.Show();
                }
                else
                    fc.Activate();
            }
        }

        bool IsBookBorrowingFormOpen = false;
        private void btnBookBorrow_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsBookBorrowingFormOpen)
            {
                IsBookBorrowingFormOpen = true;
                BookBorrowManagement bbm = new BookBorrowManagement();
                bbm.MdiParent = this;
                bbm.WindowState = FormWindowState.Maximized;
                bbm.Show();
            }
            else
            {
                Form fc = Application.OpenForms["BookBorrowManagement"];
                if (fc == null)
                {
                    BookBorrowManagement a1 = new BookBorrowManagement();
                    a1.MdiParent = this;
                    a1.Show();
                }
                else
                    fc.Activate();
            }
        }

        bool IsRegisterFormOpen = false;
        private void btnRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!IsRegisterFormOpen)
            {
                IsRegisterFormOpen = true;
                RegisterForm rf = new RegisterForm();
                rf.MdiParent = this;
                rf.WindowState = FormWindowState.Maximized;
                rf.Show();
            }
            else
            {
                Form fc = Application.OpenForms["RegisterForm"];
                if (fc == null)
                {
                    RegisterForm a1 = new RegisterForm();
                    a1.MdiParent = this;
                    a1.Show();
                }
                else
                    fc.Activate();
            }
        }
        
    }
}