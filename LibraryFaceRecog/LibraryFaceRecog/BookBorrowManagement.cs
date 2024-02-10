using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LibraryFaceRecog
{
    public partial class BookBorrowManagement : DevExpress.XtraEditors.XtraForm
    {
        public BookBorrowManagement()
        {
            InitializeComponent();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            BookBorrowForm bbf = new BookBorrowForm();
            bbf.ShowDialog();
        }
    }
}