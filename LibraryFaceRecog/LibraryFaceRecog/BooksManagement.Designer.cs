namespace LibraryFaceRecog
{
    partial class BooksManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BooksManagement));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeac = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.dtBooks = new DevExpress.XtraGrid.GridControl();
            this.gvBooks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.section = new DevExpress.XtraGrid.Columns.GridColumn();
            this.call_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.account_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.no_of_copies = new DevExpress.XtraGrid.Columns.GridColumn();
            this.author = new DevExpress.XtraGrid.Columns.GridColumn();
            this.title = new DevExpress.XtraGrid.Columns.GridColumn();
            this.place_and_publisher = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edition = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cost_price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.copyright_year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMarqueeProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::LibraryFaceRecog.WaitForm1), true, true);
            this.bwGetBooks = new System.ComponentModel.BackgroundWorker();
            this.bwDeac = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnRefresh);
            this.layoutControl1.Controls.Add(this.btnDeac);
            this.layoutControl1.Controls.Add(this.btnEdit);
            this.layoutControl1.Controls.Add(this.btnAdd);
            this.layoutControl1.Controls.Add(this.dtBooks);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(781, 298, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1135, 575);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(383, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(116, 22);
            this.btnRefresh.StyleController = this.layoutControl1;
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeac
            // 
            this.btnDeac.Image = ((System.Drawing.Image)(resources.GetObject("btnDeac.Image")));
            this.btnDeac.Location = new System.Drawing.Point(253, 12);
            this.btnDeac.Name = "btnDeac";
            this.btnDeac.Size = new System.Drawing.Size(126, 22);
            this.btnDeac.StyleController = this.layoutControl1;
            this.btnDeac.TabIndex = 9;
            this.btnDeac.Text = "Deactivate";
            this.btnDeac.Click += new System.EventHandler(this.btnDeac_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(130, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(119, 22);
            this.btnEdit.StyleController = this.layoutControl1;
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit Book";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 22);
            this.btnAdd.StyleController = this.layoutControl1;
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add Book";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dtBooks
            // 
            this.dtBooks.Location = new System.Drawing.Point(24, 69);
            this.dtBooks.MainView = this.gvBooks;
            this.dtBooks.Name = "dtBooks";
            this.dtBooks.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMarqueeProgressBar1,
            this.repositoryItemMemoEdit1});
            this.dtBooks.Size = new System.Drawing.Size(1087, 482);
            this.dtBooks.TabIndex = 6;
            this.dtBooks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBooks});
            // 
            // gvBooks
            // 
            this.gvBooks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.section,
            this.call_no,
            this.account_no,
            this.no_of_copies,
            this.author,
            this.title,
            this.place_and_publisher,
            this.edition,
            this.cost_price,
            this.copyright_year});
            this.gvBooks.GridControl = this.dtBooks;
            this.gvBooks.Name = "gvBooks";
            this.gvBooks.OptionsBehavior.Editable = false;
            this.gvBooks.OptionsFind.AlwaysVisible = true;
            this.gvBooks.OptionsView.RowAutoHeight = true;
            this.gvBooks.OptionsView.ShowGroupPanel = false;
            this.gvBooks.OptionsView.ShowIndicator = false;
            this.gvBooks.ColumnFilterChanged += new System.EventHandler(this.gvBooks_ColumnFilterChanged);
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // section
            // 
            this.section.Caption = "Section";
            this.section.FieldName = "section";
            this.section.MaxWidth = 75;
            this.section.MinWidth = 75;
            this.section.Name = "section";
            this.section.Visible = true;
            this.section.VisibleIndex = 0;
            // 
            // call_no
            // 
            this.call_no.Caption = "Class No.";
            this.call_no.ColumnEdit = this.repositoryItemMemoEdit1;
            this.call_no.FieldName = "call_no";
            this.call_no.MaxWidth = 75;
            this.call_no.MinWidth = 75;
            this.call_no.Name = "call_no";
            this.call_no.Visible = true;
            this.call_no.VisibleIndex = 1;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // account_no
            // 
            this.account_no.Caption = "Accesion No.";
            this.account_no.ColumnEdit = this.repositoryItemMemoEdit1;
            this.account_no.FieldName = "account_no";
            this.account_no.Name = "account_no";
            this.account_no.Visible = true;
            this.account_no.VisibleIndex = 2;
            this.account_no.Width = 104;
            // 
            // no_of_copies
            // 
            this.no_of_copies.Caption = "No. of copies";
            this.no_of_copies.FieldName = "no_of_copies";
            this.no_of_copies.MaxWidth = 80;
            this.no_of_copies.MinWidth = 75;
            this.no_of_copies.Name = "no_of_copies";
            this.no_of_copies.Visible = true;
            this.no_of_copies.VisibleIndex = 3;
            this.no_of_copies.Width = 80;
            // 
            // author
            // 
            this.author.Caption = "Author";
            this.author.ColumnEdit = this.repositoryItemMemoEdit1;
            this.author.FieldName = "author";
            this.author.Name = "author";
            this.author.Visible = true;
            this.author.VisibleIndex = 4;
            this.author.Width = 148;
            // 
            // title
            // 
            this.title.Caption = "Title";
            this.title.ColumnEdit = this.repositoryItemMemoEdit1;
            this.title.FieldName = "title";
            this.title.Name = "title";
            this.title.Visible = true;
            this.title.VisibleIndex = 5;
            this.title.Width = 203;
            // 
            // place_and_publisher
            // 
            this.place_and_publisher.Caption = "Place and Publisher";
            this.place_and_publisher.ColumnEdit = this.repositoryItemMemoEdit1;
            this.place_and_publisher.FieldName = "place_and_publisher";
            this.place_and_publisher.Name = "place_and_publisher";
            this.place_and_publisher.Visible = true;
            this.place_and_publisher.VisibleIndex = 6;
            this.place_and_publisher.Width = 127;
            // 
            // edition
            // 
            this.edition.Caption = "Edition";
            this.edition.FieldName = "edition";
            this.edition.Name = "edition";
            this.edition.Visible = true;
            this.edition.VisibleIndex = 7;
            this.edition.Width = 42;
            // 
            // cost_price
            // 
            this.cost_price.Caption = "Cost Price";
            this.cost_price.FieldName = "cost_price";
            this.cost_price.MaxWidth = 100;
            this.cost_price.MinWidth = 100;
            this.cost_price.Name = "cost_price";
            this.cost_price.Visible = true;
            this.cost_price.VisibleIndex = 8;
            this.cost_price.Width = 100;
            // 
            // copyright_year
            // 
            this.copyright_year.Caption = "Copyright";
            this.copyright_year.FieldName = "copyright_year";
            this.copyright_year.MaxWidth = 80;
            this.copyright_year.MinWidth = 80;
            this.copyright_year.Name = "copyright_year";
            this.copyright_year.Visible = true;
            this.copyright_year.VisibleIndex = 9;
            this.copyright_year.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemMarqueeProgressBar1
            // 
            this.repositoryItemMarqueeProgressBar1.Name = "repositoryItemMarqueeProgressBar1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlGroup2,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1135, 575);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(491, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(624, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 26);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1115, 529);
            this.layoutControlGroup2.Text = "Books";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtBooks;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1091, 486);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnAdd;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(118, 26);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(118, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(118, 26);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnEdit;
            this.layoutControlItem3.Location = new System.Drawing.Point(118, 0);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(123, 26);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(123, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(123, 26);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnDeac;
            this.layoutControlItem4.Location = new System.Drawing.Point(241, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(130, 26);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(130, 26);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(130, 26);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnRefresh;
            this.layoutControlItem5.Location = new System.Drawing.Point(371, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(120, 26);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(120, 26);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(120, 26);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // bwGetBooks
            // 
            this.bwGetBooks.WorkerSupportsCancellation = true;
            this.bwGetBooks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwGetBooks_DoWork);
            this.bwGetBooks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwGetBooks_RunWorkerCompleted);
            // 
            // bwDeac
            // 
            this.bwDeac.WorkerSupportsCancellation = true;
            this.bwDeac.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDeac_DoWork);
            this.bwDeac.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDeac_RunWorkerCompleted);
            // 
            // BooksManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 575);
            this.Controls.Add(this.layoutControl1);
            this.Name = "BooksManagement";
            this.Text = "Books Management";
            this.Shown += new System.EventHandler(this.BooksManagement_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMarqueeProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl dtBooks;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBooks;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn section;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn call_no;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn account_no;
        private DevExpress.XtraGrid.Columns.GridColumn no_of_copies;
        private DevExpress.XtraGrid.Columns.GridColumn author;
        private DevExpress.XtraGrid.Columns.GridColumn title;
        private DevExpress.XtraGrid.Columns.GridColumn place_and_publisher;
        private DevExpress.XtraGrid.Columns.GridColumn edition;
        private DevExpress.XtraGrid.Columns.GridColumn cost_price;
        private DevExpress.XtraGrid.Columns.GridColumn copyright_year;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDeac;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.ComponentModel.BackgroundWorker bwGetBooks;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMarqueeProgressBar repositoryItemMarqueeProgressBar1;
        private System.ComponentModel.BackgroundWorker bwDeac;
    }
}