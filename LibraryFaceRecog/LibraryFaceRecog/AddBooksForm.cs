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
    public partial class AddBooksForm : DevExpress.XtraEditors.XtraForm
    {
        public AddBooksForm()
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

        bool IsGood;
        double cost;
        public bool IsAdd = true;
        public int _edit_id;
        private void AddBooksForm_Load(object sender, EventArgs e)
        {
            btnSave.Text = IsAdd ? "Save" : "Edit";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IsGood = true;
            foreach (Control x in this.layoutControl1.Controls)
            {
                if (x is TextEdit)
                {
                    if ((x as TextEdit).Name.ToString() == "txtEdition" ||
                        (x as TextEdit).Name.ToString() == "txtCost")
                    {
                        continue;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty((x as TextEdit).Text))
                        {
                            Msgbox.Exclamation("Please Input " + (x as TextEdit).Name.ToString().Remove(0, 3).Trim(':') + "!");
                            (x as TextEdit).Focus();
                            (x as TextEdit).Select();
                            IsGood = false;
                            break;
                        }
                    }
                }
                if (x is MemoEdit)
                {
                    if (string.IsNullOrEmpty((x as MemoEdit).Text))
                    {
                        Msgbox.Exclamation("Please Input " + (x as MemoEdit).Name.ToString().Remove(0, 3).Trim(':') + "!");
                        (x as MemoEdit).Focus();
                        (x as MemoEdit).Select();
                        IsGood = false;
                        break;
                    }
                }
            }

            if (IsGood)
            {
                cost = string.IsNullOrEmpty(txtCost.Text) ? 0.00 : Convert.ToDouble(txtCost.Text.Replace(",", ""));
                if (IsAdd)
                {
                    if (!bwSaveDetails.IsBusy)
                    {
                        ShowLoading("Adding Book Details...");
                        bwSaveDetails.RunWorkerAsync();
                    }
                }
                else
                {
                    //Msgbox.Information("To be implemented...");
                    if (!bwEdit.IsBusy)
                    {
                        ShowLoading("Editing Book details...");
                        bwEdit.RunWorkerAsync();
                    }
                }
            }
        }

        private void bwSaveDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            Books.BooksAdd(meTitle.Text, txtAuthor.Text, mePlaceandPublisher.Text, txtSection.Text, txtCallNo.Text, txtAccountNo.Text, Convert.ToInt32(txtNoofCopies.Text), txtEdition.Text, cost, txtCopyrightYear.Text, "Bisu");
            bwSaveDetails.CancelAsync();
        }

        private void bwSaveDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Books.BooksAddSuccessful)
            {
                Msgbox.Information("Successfully Added Book");
                this.Close();
            }
            else
                Msgbox.Error(Books.BooksAddErrorMessage);
        }

        private void bwEdit_DoWork(object sender, DoWorkEventArgs e)
        {
            Books.BookEdit(meTitle.Text, txtAuthor.Text, mePlaceandPublisher.Text, txtSection.Text, txtCallNo.Text, txtAccountNo.Text, Convert.ToInt32(txtNoofCopies.Text), txtEdition.Text, cost, txtCopyrightYear.Text, _edit_id);
            bwEdit.CancelAsync();
        }

        private void bwEdit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Books.BookEditSuccessful)
            {
                Msgbox.Information("Successfully Edited Book");
                this.Close();
            }
            else
                Msgbox.Error(Books.BookEditErrorMessage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to close form?");
            if (Msgbox.isYes)
                this.Close();
        }



    }
}