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
using LibraryFaceRecog.Core;

namespace LibraryFaceRecog
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool isSuperAdmin = false;
        private DateTime serverDateTime = new DateTime();
        private int counterTimer = 0;
        private void MainForm_Load(object sender, EventArgs e)
        {
            MainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            serverDateTime = DateTime.Now;
            barStaticItemAccountType.Caption = "Account Privilege: " + PublicVariables.AccountType;
            counterTimer++;
            DateTime runningDateTime = serverDateTime.AddSeconds(counterTimer);
            barStaticItemDateTime.Caption = "Server Data and Time: " + runningDateTime.ToLongDateString() + " | " + runningDateTime.ToLongTimeString();
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
            if (!isSuperAdmin)
            {
                if (!IsRegisterFormOpen)
                {
                    IsRegisterFormOpen = true;
                    RegisterFormManagement rfm = new RegisterFormManagement();
                    rfm.MdiParent = this;
                    rfm.WindowState = FormWindowState.Maximized;
                    rfm.Show();
                }
                else
                {
                    Form fc = Application.OpenForms["RegisterFormManagement"];
                    if (fc == null)
                    {
                        RegisterFormManagement a1 = new RegisterFormManagement();
                        a1.MdiParent = this;
                        a1.Show();
                    }
                    else
                        fc.Activate();
                }
            }
            else
            {
                RegisterFormManagement rf = new RegisterFormManagement();
                rf.ShowDialog();
            }
        }

        bool IsEntranceManagementOpen = false;
        private void btnEntry_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!isSuperAdmin)
            {
                if (!IsEntranceManagementOpen)
                {
                    IsEntranceManagementOpen = true;
                    EntranceManagementForm emf = new EntranceManagementForm();
                    emf.MdiParent = this;
                    emf.WindowState = FormWindowState.Maximized;
                    emf.Show();
                }
                else
                {
                    Form fc = Application.OpenForms["EntranceManagementForm"];
                    if (fc == null)
                    {
                        EntranceManagementForm a1 = new EntranceManagementForm();
                        a1.MdiParent = this;
                        a1.Show();
                    }
                    else
                        fc.Activate();
                }
            }
            else
            {
                EntranceManagementForm emf = new EntranceManagementForm();
                emf.ShowDialog();
            }
        }
        
    }
}