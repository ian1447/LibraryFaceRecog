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
            this.rpgMenu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgFunctions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
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
            this.btnUserManagement});
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.MaxItemId = 1;
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
            this.rpgFunctions.ItemLinks.Add(this.btnUserManagement);
            this.rpgFunctions.Name = "rpgFunctions";
            this.rpgFunctions.Text = "Functions";
            // 
            // ribbonStatusBar
            // 
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 525);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.MainRibbon);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.MainRibbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Library Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
    }
}