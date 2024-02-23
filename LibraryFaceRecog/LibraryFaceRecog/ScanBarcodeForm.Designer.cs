namespace LibraryFaceRecog
{
    partial class ScanBarcodeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanBarcodeForm));
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lnkRefocus = new System.Windows.Forms.LinkLabel();
            this.lblBlinker = new DevExpress.XtraEditors.LabelControl();
            this.txtInput = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.pbxBarcodeImage = new DevExpress.XtraEditors.PictureEdit();
            this.pbxLoading = new DevExpress.XtraEditors.PictureEdit();
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.bwGetBarcodeDetails = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBarcodeImage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 144);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(70, 15);
            this.lblStatus.TabIndex = 320;
            this.lblStatus.Text = "Status Here!";
            this.lblStatus.Visible = false;
            // 
            // lnkRefocus
            // 
            this.lnkRefocus.AutoSize = true;
            this.lnkRefocus.Location = new System.Drawing.Point(155, 64);
            this.lnkRefocus.Name = "lnkRefocus";
            this.lnkRefocus.Size = new System.Drawing.Size(88, 13);
            this.lnkRefocus.TabIndex = 319;
            this.lnkRefocus.TabStop = true;
            this.lnkRefocus.Text = "Refocus Barcode";
            this.lnkRefocus.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRefocus_LinkClicked);
            // 
            // lblBlinker
            // 
            this.lblBlinker.Appearance.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlinker.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.lblBlinker.Location = new System.Drawing.Point(156, 11);
            this.lblBlinker.Name = "lblBlinker";
            this.lblBlinker.Size = new System.Drawing.Size(156, 44);
            this.lblBlinker.TabIndex = 318;
            this.lblBlinker.Text = "PLEASE SCAN \r\nTHE DOCUMENT";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(156, 109);
            this.txtInput.Name = "txtInput";
            this.txtInput.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Properties.Appearance.Options.UseFont = true;
            this.txtInput.Size = new System.Drawing.Size(153, 36);
            this.txtInput.TabIndex = 317;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl2.Location = new System.Drawing.Point(155, 89);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 316;
            this.labelControl2.Text = "Scanned Code";
            // 
            // pbxBarcodeImage
            // 
            this.pbxBarcodeImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxBarcodeImage.EditValue = ((object)(resources.GetObject("pbxBarcodeImage.EditValue")));
            this.pbxBarcodeImage.Location = new System.Drawing.Point(12, 11);
            this.pbxBarcodeImage.Name = "pbxBarcodeImage";
            this.pbxBarcodeImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pbxBarcodeImage.Size = new System.Drawing.Size(135, 136);
            this.pbxBarcodeImage.TabIndex = 315;
            // 
            // pbxLoading
            // 
            this.pbxLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbxLoading.EditValue = ((object)(resources.GetObject("pbxLoading.EditValue")));
            this.pbxLoading.Location = new System.Drawing.Point(12, 217);
            this.pbxLoading.Name = "pbxLoading";
            this.pbxLoading.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pbxLoading.Size = new System.Drawing.Size(45, 35);
            this.pbxLoading.TabIndex = 321;
            this.pbxLoading.Visible = false;
            // 
            // timerBlink
            // 
            this.timerBlink.Interval = 1500;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // bwGetBarcodeDetails
            // 
            this.bwGetBarcodeDetails.WorkerSupportsCancellation = true;
            this.bwGetBarcodeDetails.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetBarcodeDetails_DoWork);
            this.bwGetBarcodeDetails.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetBarcodeDetails_RunWorkerCompleted);
            // 
            // ScanBarcodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 159);
            this.Controls.Add(this.pbxLoading);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lnkRefocus);
            this.Controls.Add(this.lblBlinker);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.pbxBarcodeImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ScanBarcodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ScanBarcodeForm";
            this.Load += new System.EventHandler(this.ScanBarcodeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBarcodeImage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblStatus;
        private System.Windows.Forms.LinkLabel lnkRefocus;
        private DevExpress.XtraEditors.LabelControl lblBlinker;
        private DevExpress.XtraEditors.TextEdit txtInput;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.PictureEdit pbxBarcodeImage;
        private DevExpress.XtraEditors.PictureEdit pbxLoading;
        private System.Windows.Forms.Timer timerBlink;
        private System.ComponentModel.BackgroundWorker bwGetBarcodeDetails;
    }
}