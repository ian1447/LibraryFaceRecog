namespace LibraryFaceRecog.Reports
{
    partial class ReturnForm
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code93ExtendedGenerator code93ExtendedGenerator1 = new DevExpress.XtraPrinting.BarCode.Code93ExtendedGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.lblBorrower = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBookTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAuthor = new DevExpress.XtraReports.UI.XRLabel();
            this.lblReturnDay = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblReturnDay,
            this.xrLabel3,
            this.lblAuthor,
            this.xrBarCode,
            this.lblBorrower,
            this.lblBookTitle,
            this.xrLabel2,
            this.xrLabel1});
            this.Detail.HeightF = 295.2084F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrBarCode
            // 
            this.xrBarCode.LocationFloat = new DevExpress.Utils.PointFloat(0F, 195.2084F);
            this.xrBarCode.Name = "xrBarCode";
            this.xrBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 100F);
            this.xrBarCode.SizeF = new System.Drawing.SizeF(419F, 90.00002F);
            this.xrBarCode.Symbology = code93ExtendedGenerator1;
            this.xrBarCode.Text = "K0hmjVyL+v";
            // 
            // lblBorrower
            // 
            this.lblBorrower.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblBorrower.LocationFloat = new DevExpress.Utils.PointFloat(71.875F, 59.45832F);
            this.lblBorrower.Name = "lblBorrower";
            this.lblBorrower.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBorrower.SizeF = new System.Drawing.SizeF(367.125F, 40.54166F);
            this.lblBorrower.StylePriority.UseBorders = false;
            this.lblBorrower.StylePriority.UseTextAlignment = false;
            this.lblBorrower.Text = "Borrower:";
            this.lblBorrower.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // lblBookTitle
            // 
            this.lblBookTitle.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblBookTitle.LocationFloat = new DevExpress.Utils.PointFloat(71.875F, 0F);
            this.lblBookTitle.Multiline = true;
            this.lblBookTitle.Name = "lblBookTitle";
            this.lblBookTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBookTitle.SizeF = new System.Drawing.SizeF(367.125F, 59.45835F);
            this.lblBookTitle.StylePriority.UseBorders = false;
            this.lblBookTitle.StylePriority.UseTextAlignment = false;
            this.lblBookTitle.Text = "Book Title:";
            this.lblBookTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 59.45835F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(71.875F, 40.54166F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Borrower:";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)
                        | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(71.875F, 59.45835F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Book Title:";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblDate});
            this.TopMargin.HeightF = 42F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblDate
            // 
            this.lblDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDate.SizeF = new System.Drawing.SizeF(439F, 23F);
            this.lblDate.StylePriority.UseTextAlignment = false;
            this.lblDate.Text = "lblDate";
            this.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 22.58326F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)
                        | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 99.99997F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(71.875F, 40.54166F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Author:";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblAuthor.LocationFloat = new DevExpress.Utils.PointFloat(71.875F, 99.99997F);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAuthor.SizeF = new System.Drawing.SizeF(367.125F, 40.54166F);
            this.lblAuthor.StylePriority.UseBorders = false;
            this.lblAuthor.StylePriority.UseTextAlignment = false;
            this.lblAuthor.Text = "Book Author:";
            this.lblAuthor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleJustify;
            // 
            // lblReturnDay
            // 
            this.lblReturnDay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnDay.ForeColor = System.Drawing.Color.Red;
            this.lblReturnDay.LocationFloat = new DevExpress.Utils.PointFloat(0.9999911F, 157.25F);
            this.lblReturnDay.Name = "lblReturnDay";
            this.lblReturnDay.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.lblReturnDay.SizeF = new System.Drawing.SizeF(439F, 23F);
            this.lblReturnDay.StylePriority.UseFont = false;
            this.lblReturnDay.StylePriority.UseForeColor = false;
            this.lblReturnDay.Text = "Please Return within 3 Days";
            // 
            // ReturnForm
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(14, 15, 42, 23);
            this.PageHeight = 500;
            this.PageWidth = 469;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.Version = "14.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        public DevExpress.XtraReports.UI.XRLabel lblBorrower;
        public DevExpress.XtraReports.UI.XRLabel lblBookTitle;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        public DevExpress.XtraReports.UI.XRLabel lblDate;
        public DevExpress.XtraReports.UI.XRBarCode xrBarCode;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        public DevExpress.XtraReports.UI.XRLabel lblAuthor;
        public DevExpress.XtraReports.UI.XRLabel lblReturnDay;
    }
}
