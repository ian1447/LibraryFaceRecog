namespace LibraryFaceRecog
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainRibbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnUserManagement = new DevExpress.XtraBars.BarButtonItem();
            this.btnBooksManagement = new DevExpress.XtraBars.BarButtonItem();
            this.btnBookBorrow = new DevExpress.XtraBars.BarButtonItem();
            this.btnRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnEntry = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemAccountType = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItemDateTime = new DevExpress.XtraBars.BarStaticItem();
            this.rpgMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgFunctions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainRibbon
            // 
            this.MainRibbon.ExpandCollapseItem.Id = 0;
            this.MainRibbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.MainRibbon.ExpandCollapseItem,
            this.btnLogout,
            this.btnUserManagement,
            this.btnBooksManagement,
            this.btnBookBorrow,
            this.btnRegister,
            this.btnEntry,
            this.barStaticItemAccountType,
            this.barStaticItemDateTime});
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.MaxItemId = 7;
            this.MainRibbon.Name = "MainRibbon";
            this.MainRibbon.PageHeaderItemLinks.Add(this.btnLogout);
            this.MainRibbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpgMenu});
            this.MainRibbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.TabletOffice;
            this.MainRibbon.Size = new System.Drawing.Size(962, 80);
            this.MainRibbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Logout";
            this.btnLogout.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLogout.Glyph")));
            this.btnLogout.Id = 11;
            this.btnLogout.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnLogout.LargeGlyph")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnUserManagement
            // 
            this.btnUserManagement.Caption = "User Management";
            this.btnUserManagement.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUserManagement.Glyph")));
            this.btnUserManagement.Id = 12;
            this.btnUserManagement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUserManagement.LargeGlyph")));
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUserManagement_ItemClick);
            // 
            // btnBooksManagement
            // 
            this.btnBooksManagement.Caption = "Books Management";
            this.btnBooksManagement.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBooksManagement.Glyph")));
            this.btnBooksManagement.Id = 1;
            this.btnBooksManagement.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBooksManagement.LargeGlyph")));
            this.btnBooksManagement.Name = "btnBooksManagement";
            this.btnBooksManagement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBooksManagement_ItemClick);
            // 
            // btnBookBorrow
            // 
            this.btnBookBorrow.Caption = "Book Borrowing";
            this.btnBookBorrow.Glyph = ((System.Drawing.Image)(resources.GetObject("btnBookBorrow.Glyph")));
            this.btnBookBorrow.Id = 2;
            this.btnBookBorrow.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnBookBorrow.LargeGlyph")));
            this.btnBookBorrow.Name = "btnBookBorrow";
            this.btnBookBorrow.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBookBorrow_ItemClick);
            // 
            // btnRegister
            // 
            this.btnRegister.Caption = "Register";
            this.btnRegister.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRegister.Glyph")));
            this.btnRegister.Id = 3;
            this.btnRegister.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRegister.LargeGlyph")));
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegister_ItemClick);
            // 
            // btnEntry
            // 
            this.btnEntry.Caption = "Entrance Management";
            this.btnEntry.Glyph = ((System.Drawing.Image)(resources.GetObject("btnEntry.Glyph")));
            this.btnEntry.Id = 4;
            this.btnEntry.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnEntry.LargeGlyph")));
            this.btnEntry.Name = "btnEntry";
            this.btnEntry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEntry_ItemClick);
            // 
            // barStaticItemAccountType
            // 
            this.barStaticItemAccountType.Caption = "Account Type:";
            this.barStaticItemAccountType.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItemAccountType.Glyph")));
            this.barStaticItemAccountType.Id = 5;
            this.barStaticItemAccountType.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barStaticItemAccountType.LargeGlyph")));
            this.barStaticItemAccountType.Name = "barStaticItemAccountType";
            this.barStaticItemAccountType.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItemDateTime
            // 
            this.barStaticItemDateTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemDateTime.Caption = "Time and Data:";
            this.barStaticItemDateTime.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItemDateTime.Glyph")));
            this.barStaticItemDateTime.Id = 6;
            this.barStaticItemDateTime.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barStaticItemDateTime.LargeGlyph")));
            this.barStaticItemDateTime.Name = "barStaticItemDateTime";
            this.barStaticItemDateTime.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // rpgMenu
            // 
            this.rpgMenu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgFunctions});
            this.rpgMenu.Image = ((System.Drawing.Image)(resources.GetObject("rpgMenu.Image")));
            this.rpgMenu.Name = "rpgMenu";
            this.rpgMenu.Text = "Main menu";
            // 
            // rpgFunctions
            // 
            this.rpgFunctions.ItemLinks.Add(this.btnRegister);
            this.rpgFunctions.ItemLinks.Add(this.btnBooksManagement);
            this.rpgFunctions.ItemLinks.Add(this.btnEntry);
            this.rpgFunctions.ItemLinks.Add(this.btnBookBorrow);
            this.rpgFunctions.ItemLinks.Add(this.btnUserManagement);
            this.rpgFunctions.Name = "rpgFunctions";
            this.rpgFunctions.Text = "Functions";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemAccountType);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemDateTime);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 494);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.MainRibbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(962, 31);
            // 
            // documentManager
            // 
            this.documentManager.MdiParent = this;
            this.documentManager.MenuManager = this.MainRibbon;
            this.documentManager.View = this.tabbedView1;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // MainTimer
            // 
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 525);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.MainRibbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.MainRibbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Library Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainRibbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl MainRibbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpgMenu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgFunctions;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnUserManagement;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem btnBooksManagement;
        private DevExpress.XtraBars.BarButtonItem btnBookBorrow;
        private DevExpress.XtraBars.BarButtonItem btnRegister;
        private DevExpress.XtraBars.BarButtonItem btnEntry;
        private DevExpress.XtraBars.BarStaticItem barStaticItemAccountType;
        private DevExpress.XtraBars.BarStaticItem barStaticItemDateTime;
        private System.Windows.Forms.Timer MainTimer;
    }
}