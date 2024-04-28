namespace LibraryFaceRecog
{
    partial class BookBorrowedSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookBorrowedSearchForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.lblBarcode = new DevExpress.XtraEditors.LabelControl();
            this.dtBorrowedBooks = new DevExpress.XtraGrid.GridControl();
            this.gvBorrowedBooks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this._barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::LibraryFaceRecog.WaitForm1), true, true);
            this.bwGetBorrowedBooks = new System.ComponentModel.BackgroundWorker();
            this.no_of_copies = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBorrowedBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorrowedBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnSelect);
            this.layoutControl1.Controls.Add(this.lblBarcode);
            this.layoutControl1.Controls.Add(this.dtBorrowedBooks);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(601, 296, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(367, 480);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(203, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(152, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(12, 446);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(187, 22);
            this.btnSelect.StyleController = this.layoutControl1;
            this.btnSelect.TabIndex = 11;
            this.btnSelect.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblBarcode
            // 
            this.lblBarcode.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblBarcode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblBarcode.Location = new System.Drawing.Point(12, 12);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(343, 16);
            this.lblBarcode.StyleController = this.layoutControl1;
            this.lblBarcode.TabIndex = 10;
            this.lblBarcode.Text = "Barcode: ";
            // 
            // dtBorrowedBooks
            // 
            this.dtBorrowedBooks.Location = new System.Drawing.Point(12, 32);
            this.dtBorrowedBooks.MainView = this.gvBorrowedBooks;
            this.dtBorrowedBooks.Name = "dtBorrowedBooks";
            this.dtBorrowedBooks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.dtBorrowedBooks.Size = new System.Drawing.Size(343, 410);
            this.dtBorrowedBooks.TabIndex = 9;
            this.dtBorrowedBooks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBorrowedBooks});
            // 
            // gvBorrowedBooks
            // 
            this.gvBorrowedBooks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._title,
            this._barcode,
            this.no_of_copies});
            this.gvBorrowedBooks.GridControl = this.dtBorrowedBooks;
            this.gvBorrowedBooks.Name = "gvBorrowedBooks";
            this.gvBorrowedBooks.OptionsBehavior.Editable = false;
            this.gvBorrowedBooks.OptionsFind.AllowFindPanel = false;
            this.gvBorrowedBooks.OptionsView.RowAutoHeight = true;
            this.gvBorrowedBooks.OptionsView.ShowGroupPanel = false;
            this.gvBorrowedBooks.OptionsView.ShowIndicator = false;
            this.gvBorrowedBooks.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvBorrowedBooks_FocusedRowChanged);
            // 
            // _title
            // 
            this._title.Caption = "Book Title";
            this._title.ColumnEdit = this.repositoryItemMemoEdit1;
            this._title.FieldName = "title";
            this._title.Name = "_title";
            this._title.Visible = true;
            this._title.VisibleIndex = 0;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // _barcode
            // 
            this._barcode.Caption = "Barcode";
            this._barcode.ColumnEdit = this.repositoryItemMemoEdit1;
            this._barcode.FieldName = "barcode";
            this._barcode.Name = "_barcode";
            this._barcode.Visible = true;
            this._barcode.VisibleIndex = 1;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(367, 480);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtBorrowedBooks;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 20);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(347, 414);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lblBarcode;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(347, 20);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSelect;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 434);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(191, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnCancel;
            this.layoutControlItem4.Location = new System.Drawing.Point(191, 434);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(156, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // bwGetBorrowedBooks
            // 
            this.bwGetBorrowedBooks.WorkerSupportsCancellation = true;
            this.bwGetBorrowedBooks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetBorrowedBooks_DoWork);
            this.bwGetBorrowedBooks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetBorrowedBooks_RunWorkerCompleted);
            // 
            // no_of_copies
            // 
            this.no_of_copies.Caption = "no_of_copies";
            this.no_of_copies.FieldName = "no_of_copies";
            this.no_of_copies.Name = "no_of_copies";
            // 
            // BookBorrowedSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 480);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BookBorrowedSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Book Borrowed Search";
            this.Shown += new System.EventHandler(this.BookBorrowedSearchForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtBorrowedBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorrowedBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl dtBorrowedBooks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBorrowedBooks;
        private DevExpress.XtraGrid.Columns.GridColumn _title;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn _barcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        public DevExpress.XtraEditors.LabelControl lblBarcode;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSelect;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.ComponentModel.BackgroundWorker bwGetBorrowedBooks;
        private DevExpress.XtraGrid.Columns.GridColumn no_of_copies;
    }
}