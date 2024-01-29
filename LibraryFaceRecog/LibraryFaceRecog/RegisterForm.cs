﻿using System;
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
    public partial class RegisterForm : DevExpress.XtraEditors.XtraForm
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            CaptureImage ci = new CaptureImage();
            ci.ShowDialog();
        }
    }
}