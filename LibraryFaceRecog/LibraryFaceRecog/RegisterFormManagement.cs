﻿using System;
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
using System.IO;

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
                if (!gvRegistered.IsGroupRow(gvRegistered.FocusedRowHandle))
                {
                    if (gvRegistered.SelectedRowsCount > 0)
                    {
                        int selectedRowId = Convert.ToInt32(gvRegistered.GetRowCellValue(gvRegistered.FocusedRowHandle, "id"));
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
            BorrowersTable = Register.GetRegisteredBorrowers("Bisu");
            bwGetDetails.CancelAsync();
        }

        private void bwGetDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Register.GetRegisteredBorrowersSuccessful)
            {
                dtRegistered.DataSource = BorrowersTable;

            }
            else
                Msgbox.Error(Register.GetRegisteredBorrowersErrorMessage);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm rf = new RegisterForm();
            rf.ShowDialog();
            btnRefresh.PerformClick();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (SelectionPass())
            {
                var focusRowView = (DataRowView)gvRegistered.GetFocusedRow();
                DataTable EditTable = BorrowersTable.AsEnumerable()
                      .Where(row => row.Field<int>("id") == Convert.ToInt32(focusRowView.Row[0].ToString())).CopyToDataTable();
                RegisterForm rf = new RegisterForm();
                rf.EditId = Convert.ToInt32(focusRowView.Row[0].ToString());
                rf.txtFirstName.Text = EditTable.Rows[0]["first_name"].ToString();
                rf.txtMiddleInitial.Text = EditTable.Rows[0]["middle_name"].ToString();
                rf.txtFamilyName.Text = EditTable.Rows[0]["last_name"].ToString();
                rf.cmbSex.Text = EditTable.Rows[0]["sex"].ToString();
                rf.txtCourse.Text = EditTable.Rows[0]["course"].ToString();
                rf.txtSection.Text = EditTable.Rows[0]["section"].ToString();
                rf.txtYear.Text = EditTable.Rows[0]["year"].ToString();
                byte[] img = (byte[])EditTable.Rows[0]["image"];
                MemoryStream ms = new MemoryStream(img);
                rf.peCapturedImage.Image = Image.FromStream(ms);
                rf.IsAdd = false;
                rf.ShowDialog();
                btnRefresh.PerformClick();
            }
            else
                Msgbox.Exclamation("Please select a borrower to edit.");
        }

        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;
        //}
    }
}