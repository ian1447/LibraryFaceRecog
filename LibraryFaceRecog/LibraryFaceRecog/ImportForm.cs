using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using LibraryFaceRecog.Core;
using System.Diagnostics;

namespace LibraryFaceRecog
{
    public partial class ImportForm : DevExpress.XtraEditors.XtraForm
    {
        public ImportForm()
        {
            InitializeComponent();
        }

        string filename = (Application.StartupPath + "\\Checker") + "/location.txt";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog v1 = new OpenFileDialog();
            v1.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

            if (v1.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = v1.FileName;
                File.WriteAllText(filename, v1.FileName);
            }
        }

        private void txtLocation_EditValueChanged(object sender, EventArgs e)
        {
            btnImport.Enabled = txtLocation.Text == "" ? false : true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Msgbox.QuestionYesNo("Are you sure you want to import data?");
            if (Msgbox.isYes)
            {
                Process facerecog = new Process()
                {
                    StartInfo = new ProcessStartInfo(PublicVariables.DefaultDirectory + "\\Checker\\Import.exe")
                    {
                        WorkingDirectory = PublicVariables.DefaultDirectory + "\\Checker"
                    }
                };
                facerecog.StartInfo.FileName = PublicVariables.DefaultDirectory + "\\Checker\\Import.exe";
                facerecog.Start();
                facerecog.WaitForExit();
                this.Close();
            }
        }
    }
}