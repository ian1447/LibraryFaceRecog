namespace LibraryFaceRecog
{
    partial class BookBorrowManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookBorrowManagement));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDetails = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.luePeriod = new DevExpress.XtraEditors.LookUpEdit();
            this.lueBorrower = new DevExpress.XtraEditors.LookUpEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.btnBorrow = new DevExpress.XtraEditors.SimpleButton();
            this.dtBorrow = new DevExpress.XtraGrid.GridControl();
            this.gvBorrow = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.author = new DevExpress.XtraGrid.Columns.GridColumn();
            this.borrower = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.borrowed_on = new DevExpress.XtraGrid.Columns.GridColumn();
            this.returned_on = new DevExpress.XtraGrid.Columns.GridColumn();
            this.borrower_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::LibraryFaceRecog.WaitForm1), true, true);
            this.bwGetBorrowedDetails = new System.ComponentModel.BackgroundWorker();
            this.bwGetBorrower = new System.ComponentModel.BackgroundWorker();
            this.pnlDates = new DevExpress.XtraEditors.PanelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.dtpTo = new DevExpress.XtraEditors.DateEdit();
            this.dtpFrom = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePeriod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBorrower.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDates)).BeginInit();
            this.pnlDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnDetails);
            this.layoutControl1.Controls.Add(this.btnPrint);
            this.layoutControl1.Controls.Add(this.luePeriod);
            this.layoutControl1.Controls.Add(this.lueBorrower);
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnReturn);
            this.layoutControl1.Controls.Add(this.btnBorrow);
            this.layoutControl1.Controls.Add(this.dtBorrow);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1241, 597);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnDetails
            // 
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(199, 12);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(109, 22);
            this.btnDetails.StyleController = this.layoutControl1;
            this.btnDetails.TabIndex = 18;
            this.btnDetails.Text = "Borrower Details";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.Location = new System.Drawing.Point(1095, 12);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(134, 22);
            this.btnPrint.StyleController = this.layoutControl1;
            this.btnPrint.TabIndex = 17;
            this.btnPrint.Text = "Print Report";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // luePeriod
            // 
            this.luePeriod.Location = new System.Drawing.Point(744, 12);
            this.luePeriod.Name = "luePeriod";
            this.luePeriod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePeriod.Size = new System.Drawing.Size(160, 20);
            this.luePeriod.StyleController = this.layoutControl1;
            this.luePeriod.TabIndex = 16;
            this.luePeriod.Closed += new DevExpress.XtraEditors.Controls.ClosedEventHandler(this.luePeriod_Closed);
            this.luePeriod.EditValueChanged += new System.EventHandler(this.luePeriod_EditValueChanged);
            // 
            // lueBorrower
            // 
            this.lueBorrower.Location = new System.Drawing.Point(522, 12);
            this.lueBorrower.Name = "lueBorrower";
            this.lueBorrower.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lueBorrower.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "Borrower Name")});
            this.lueBorrower.Properties.NullText = "All";
            this.lueBorrower.Size = new System.Drawing.Size(166, 20);
            this.lueBorrower.StyleController = this.layoutControl1;
            this.lueBorrower.TabIndex = 15;
            this.lueBorrower.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lueBorrower_ButtonClick);
            this.lueBorrower.EditValueChanged += new System.EventHandler(this.lueBorrower_EditValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(312, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 22);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.Location = new System.Drawing.Point(106, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(89, 22);
            this.btnReturn.StyleController = this.layoutControl1;
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnBorrow
            // 
            this.btnBorrow.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrow.Image")));
            this.btnBorrow.Location = new System.Drawing.Point(12, 12);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(90, 22);
            this.btnBorrow.StyleController = this.layoutControl1;
            this.btnBorrow.TabIndex = 8;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // dtBorrow
            // 
            this.dtBorrow.Location = new System.Drawing.Point(24, 74);
            this.dtBorrow.MainView = this.gvBorrow;
            this.dtBorrow.Name = "dtBorrow";
            this.dtBorrow.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.dtBorrow.Size = new System.Drawing.Size(1193, 499);
            this.dtBorrow.TabIndex = 7;
            this.dtBorrow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBorrow});
            // 
            // gvBorrow
            // 
            this.gvBorrow.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.title,
            this.author,
            this.borrower,
            this.barcode,
            this.borrowed_on,
            this.returned_on,
            this.borrower_id});
            this.gvBorrow.GridControl = this.dtBorrow;
            this.gvBorrow.Name = "gvBorrow";
            this.gvBorrow.OptionsBehavior.Editable = false;
            this.gvBorrow.OptionsView.RowAutoHeight = true;
            this.gvBorrow.OptionsView.ShowGroupPanel = false;
            this.gvBorrow.OptionsView.ShowIndicator = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // title
            // 
            this.title.Caption = "Book Name";
            this.title.ColumnEdit = this.repositoryItemMemoEdit1;
            this.title.FieldName = "title";
            this.title.Name = "title";
            this.title.Visible = true;
            this.title.VisibleIndex = 1;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // author
            // 
            this.author.Caption = "Author";
            this.author.FieldName = "author";
            this.author.Name = "author";
            this.author.Visible = true;
            this.author.VisibleIndex = 0;
            // 
            // borrower
            // 
            this.borrower.Caption = "Borrower";
            this.borrower.FieldName = "borrower";
            this.borrower.Name = "borrower";
            this.borrower.Visible = true;
            this.borrower.VisibleIndex = 2;
            // 
            // barcode
            // 
            this.barcode.Caption = "Barcode";
            this.barcode.FieldName = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 3;
            // 
            // borrowed_on
            // 
            this.borrowed_on.Caption = "Borrowed On";
            this.borrowed_on.FieldName = "borrowed_on";
            this.borrowed_on.Name = "borrowed_on";
            this.borrowed_on.Visible = true;
            this.borrowed_on.VisibleIndex = 4;
            // 
            // returned_on
            // 
            this.returned_on.Caption = "Returned On";
            this.returned_on.FieldName = "returned_on";
            this.returned_on.Name = "returned_on";
            this.returned_on.Visible = true;
            this.returned_on.VisibleIndex = 5;
            // 
            // borrower_id
            // 
            this.borrower_id.Caption = "Borrower Id";
            this.borrower_id.FieldName = "borrower_id";
            this.borrower_id.Name = "borrower_id";
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
            this.emptySpaceItem2,
            this.splitterItem1,
            this.layoutControlGroup2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1241, 597);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(896, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(187, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(0, 26);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(1221, 5);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 31);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1221, 546);
            this.layoutControlGroup2.Text = "Borrowed Books";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtBorrow;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1197, 503);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnBorrow;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(94, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnReturn;
            this.layoutControlItem3.Location = new System.Drawing.Point(94, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(93, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(93, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(93, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnRefresh;
            this.layoutControlItem5.Location = new System.Drawing.Point(300, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(109, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(109, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(109, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.lueBorrower;
            this.layoutControlItem6.Location = new System.Drawing.Point(409, 0);
            this.layoutControlItem6.MaxSize = new System.Drawing.Size(271, 26);
            this.layoutControlItem6.MinSize = new System.Drawing.Size(271, 26);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(271, 26);
            this.layoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem6.Text = "Borrower Name:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(98, 14);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.luePeriod;
            this.layoutControlItem4.Location = new System.Drawing.Point(680, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(216, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(216, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(216, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.Text = "Period: ";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(47, 14);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnPrint;
            this.layoutControlItem7.Location = new System.Drawing.Point(1083, 0);
            this.layoutControlItem7.MaxSize = new System.Drawing.Size(138, 26);
            this.layoutControlItem7.MinSize = new System.Drawing.Size(138, 26);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(138, 26);
            this.layoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnDetails;
            this.layoutControlItem8.Location = new System.Drawing.Point(187, 0);
            this.layoutControlItem8.MaxSize = new System.Drawing.Size(113, 26);
            this.layoutControlItem8.MinSize = new System.Drawing.Size(113, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(113, 26);
            this.layoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(354, 32);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(354, 455);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // bwGetBorrowedDetails
            // 
            this.bwGetBorrowedDetails.WorkerSupportsCancellation = true;
            this.bwGetBorrowedDetails.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetBorrowedDetails_DoWork);
            this.bwGetBorrowedDetails.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetBorrowedDetails_RunWorkerCompleted);
            // 
            // bwGetBorrower
            // 
            this.bwGetBorrower.WorkerSupportsCancellation = true;
            this.bwGetBorrower.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetBorrower_DoWork);
            this.bwGetBorrower.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetBorrower_RunWorkerCompleted);
            // 
            // pnlDates
            // 
            this.pnlDates.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlDates.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.pnlDates.Appearance.Options.UseBackColor = true;
            this.pnlDates.Appearance.Options.UseFont = true;
            this.pnlDates.Controls.Add(this.labelControl8);
            this.pnlDates.Controls.Add(this.btnSearch);
            this.pnlDates.Controls.Add(this.labelControl6);
            this.pnlDates.Controls.Add(this.dtpTo);
            this.pnlDates.Controls.Add(this.dtpFrom);
            this.pnlDates.Location = new System.Drawing.Point(1247, 15);
            this.pnlDates.Name = "pnlDates";
            this.pnlDates.Size = new System.Drawing.Size(413, 59);
            this.pnlDates.TabIndex = 381;
            this.pnlDates.Visible = false;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Location = new System.Drawing.Point(14, 6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(32, 13);
            this.labelControl8.TabIndex = 370;
            this.labelControl8.Text = "From :";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(326, 23);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 365;
            this.btnSearch.Text = "Load";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Location = new System.Drawing.Point(174, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(19, 13);
            this.labelControl6.TabIndex = 369;
            this.labelControl6.Text = "To :";
            // 
            // dtpTo
            // 
            this.dtpTo.EditValue = null;
            this.dtpTo.Location = new System.Drawing.Point(170, 26);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpTo.Properties.Appearance.Options.UseFont = true;
            this.dtpTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpTo.Properties.DisplayFormat.FormatString = "MMM. dd, yyyy";
            this.dtpTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTo.Properties.EditFormat.FormatString = "MMM. dd, yyyy";
            this.dtpTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpTo.Properties.Mask.EditMask = "MMM. dd, yyyy";
            this.dtpTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtpTo.Size = new System.Drawing.Size(148, 24);
            this.dtpTo.TabIndex = 364;
            // 
            // dtpFrom
            // 
            this.dtpFrom.EditValue = null;
            this.dtpFrom.Location = new System.Drawing.Point(14, 26);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFrom.Properties.Appearance.Options.UseFont = true;
            this.dtpFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrom.Properties.DisplayFormat.FormatString = "MMM. dd, yyyy";
            this.dtpFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFrom.Properties.EditFormat.FormatString = "MMM. dd, yyyy";
            this.dtpFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpFrom.Properties.Mask.EditMask = "MMM. dd, yyyy";
            this.dtpFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.dtpFrom.Size = new System.Drawing.Size(148, 24);
            this.dtpFrom.TabIndex = 362;
            // 
            // BookBorrowManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 597);
            this.Controls.Add(this.pnlDates);
            this.Controls.Add(this.layoutControl1);
            this.Name = "BookBorrowManagement";
            this.Text = "Book Borrowing Management";
            this.Shown += new System.EventHandler(this.BookBorrowManagement_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luePeriod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueBorrower.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBorrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDates)).EndInit();
            this.pnlDates.ResumeLayout(false);
            this.pnlDates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl dtBorrow;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBorrow;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn title;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraEditors.SimpleButton btnBorrow;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn borrower;
        private DevExpress.XtraGrid.Columns.GridColumn borrowed_on;
        private DevExpress.XtraGrid.Columns.GridColumn returned_on;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.ComponentModel.BackgroundWorker bwGetBorrowedDetails;
        private DevExpress.XtraGrid.Columns.GridColumn author;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.ComponentModel.BackgroundWorker bwGetBorrower;
        private DevExpress.XtraEditors.LookUpEdit lueBorrower;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.LookUpEdit luePeriod;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PanelControl pnlDates;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit dtpTo;
        private DevExpress.XtraEditors.DateEdit dtpFrom;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnDetails;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn borrower_id;
    }
}