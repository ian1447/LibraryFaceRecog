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
    public partial class BookBorrowForm : DevExpress.XtraEditors.XtraForm
    {
        public BookBorrowForm()
        {
            InitializeComponent();
        }

        private void txtBookTitle_Click(object sender, EventArgs e)
        {
            BookSearchForm bsf = new BookSearchForm();
            bsf.ShowDialog();
        }
    }
}