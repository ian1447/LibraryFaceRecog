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
    public partial class ScanBarcodeForm : DevExpress.XtraEditors.XtraForm
    {
        public ScanBarcodeForm()
        {
            InitializeComponent();
        }

        #region UTIL
        private void ShowLoading(string message)
        {
            pbxLoading.Visible = true;
            pbxLoading.Dock = DockStyle.Fill;
            pbxLoading.BringToFront();
            pbxLoading.Refresh();

            lblStatus.Text = message;
            lblStatus.Visible = true;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.BringToFront();
            lblStatus.Refresh();
        }

        private void HideLoading()
        {
            pbxLoading.Visible = false;
            pbxLoading.Refresh();

            lblStatus.Visible = false;
            lblStatus.Refresh();
        }
        #endregion

        public string Barcode;
        public bool TransactionIsSuccessfull = false;
        public DataTable BorrowDetails = new DataTable();
        private void timerBlink_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 4);  // month: >= 1 and < 4

            lblBlinker.ForeColor = randomNumber.Equals(1) ? Color.IndianRed
                : randomNumber.Equals(2) ? Color.Gray : Color.Green;
        }

        private void ScanBarcodeForm_Load(object sender, EventArgs e)
        {
            timerBlink.Start();
        }

        private void lnkRefocus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TextRefocus();
        }

        private void TextRefocus()
        {
            txtInput.Focus();
            txtInput.Select();
            txtInput.SelectAll();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Barcode = txtInput.Text;
                if (!string.IsNullOrEmpty(Barcode))
                {
                    ShowLoading("Verifying the barcode...");
                    bwGetBarcodeDetails.RunWorkerAsync();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                TransactionIsSuccessfull = false;
                this.Close();
            }
        }

        private void bwGetBarcodeDetails_DoWork(object sender, DoWorkEventArgs e)
        {
            BorrowDetails = Borrower.GetBorrowedBooksbyBarcode(Barcode);
            bwGetBarcodeDetails.CancelAsync();
        }

        private void bwGetBarcodeDetails_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HideLoading();
            if (Borrower.GetBorrowedBooksbyBarcodeSuccessful)
            {
                if (BorrowDetails.Rows.Count > 0)
                {
                    TransactionIsSuccessfull = true;
                    this.Close();
                }
                else
                {
                    Msgbox.Exclamation("No data found with the barcode " + Barcode + "!");
                    txtInput.Focus();
                }
            }
            else
                Msgbox.Error(Borrower.GetBorrowedBooksbyBarcodeErrorMessage);
        }
    }
}