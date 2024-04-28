namespace LibraryFaceRecog
{
    partial class ImportFromExcel
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.dtRegistered = new DevExpress.XtraGrid.GridControl();
            this.gvRegistered = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.course = new DevExpress.XtraGrid.Columns.GridColumn();
            this.year_and_section = new DevExpress.XtraGrid.Columns.GridColumn();
            this.added_on = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contact_number = new DevExpress.XtraGrid.Columns.GridColumn();
            this.student_id_no = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegistered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegistered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtRegistered);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(648, 360, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(669, 544);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(669, 544);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(649, 64);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // dtRegistered
            // 
            this.dtRegistered.Location = new System.Drawing.Point(12, 76);
            this.dtRegistered.MainView = this.gvRegistered;
            this.dtRegistered.Name = "dtRegistered";
            this.dtRegistered.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dtRegistered.Size = new System.Drawing.Size(645, 456);
            this.dtRegistered.TabIndex = 9;
            this.dtRegistered.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRegistered});
            // 
            // gvRegistered
            // 
            this.gvRegistered.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id,
            this.name,
            this.course,
            this.year_and_section,
            this.added_on,
            this.sex,
            this.contact_number,
            this.student_id_no});
            this.gvRegistered.GridControl = this.dtRegistered;
            this.gvRegistered.Name = "gvRegistered";
            this.gvRegistered.OptionsBehavior.Editable = false;
            this.gvRegistered.OptionsView.RowAutoHeight = true;
            this.gvRegistered.OptionsView.ShowGroupPanel = false;
            this.gvRegistered.OptionsView.ShowIndicator = false;
            // 
            // id
            // 
            this.id.Caption = "id";
            this.id.FieldName = "id";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.Caption = "Name";
            this.name.FieldName = "name";
            this.name.Name = "name";
            this.name.Visible = true;
            this.name.VisibleIndex = 1;
            // 
            // course
            // 
            this.course.Caption = "Course";
            this.course.FieldName = "course";
            this.course.Name = "course";
            this.course.Visible = true;
            this.course.VisibleIndex = 4;
            // 
            // year_and_section
            // 
            this.year_and_section.Caption = "Year and Section";
            this.year_and_section.FieldName = "year_and_section";
            this.year_and_section.Name = "year_and_section";
            this.year_and_section.Visible = true;
            this.year_and_section.VisibleIndex = 5;
            // 
            // added_on
            // 
            this.added_on.Caption = "Added On";
            this.added_on.FieldName = "added_on";
            this.added_on.Name = "added_on";
            this.added_on.Visible = true;
            this.added_on.VisibleIndex = 6;
            // 
            // sex
            // 
            this.sex.Caption = "Sex";
            this.sex.FieldName = "sex";
            this.sex.Name = "sex";
            this.sex.Visible = true;
            this.sex.VisibleIndex = 3;
            // 
            // contact_number
            // 
            this.contact_number.Caption = "Contact Number";
            this.contact_number.FieldName = "contact_number";
            this.contact_number.Name = "contact_number";
            this.contact_number.Visible = true;
            this.contact_number.VisibleIndex = 2;
            // 
            // student_id_no
            // 
            this.student_id_no.Caption = "Student ID No.";
            this.student_id_no.FieldName = "student_id_no";
            this.student_id_no.Name = "student_id_no";
            this.student_id_no.Visible = true;
            this.student_id_no.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtRegistered;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 64);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(649, 460);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // ImportFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 544);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportFromExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImportFromExcel";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtRegistered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRegistered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl dtRegistered;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRegistered;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn name;
        private DevExpress.XtraGrid.Columns.GridColumn course;
        private DevExpress.XtraGrid.Columns.GridColumn year_and_section;
        private DevExpress.XtraGrid.Columns.GridColumn added_on;
        private DevExpress.XtraGrid.Columns.GridColumn sex;
        private DevExpress.XtraGrid.Columns.GridColumn contact_number;
        private DevExpress.XtraGrid.Columns.GridColumn student_id_no;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}