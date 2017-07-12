namespace PrintUserStories
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon1()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPrintStories = this.Factory.CreateRibbonTab();
            this.grpConfiguration = this.Factory.CreateRibbonGroup();
            this.btnRally = this.Factory.CreateRibbonButton();
            this.btnSettings = this.Factory.CreateRibbonButton();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.editBoxWorkspace = this.Factory.CreateRibbonEditBox();
            this.editBoxProject = this.Factory.CreateRibbonEditBox();
            this.btnSelectWrkspProj = this.Factory.CreateRibbonButton();
            this.tabPrintStories.SuspendLayout();
            this.grpConfiguration.SuspendLayout();
            this.group1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrintStories
            // 
            this.tabPrintStories.Groups.Add(this.grpConfiguration);
            this.tabPrintStories.Groups.Add(this.group1);
            this.tabPrintStories.Label = "Print Stories";
            this.tabPrintStories.Name = "tabPrintStories";
            // 
            // grpConfiguration
            // 
            this.grpConfiguration.Items.Add(this.btnRally);
            this.grpConfiguration.Items.Add(this.btnSettings);
            this.grpConfiguration.Label = "Configuration";
            this.grpConfiguration.Name = "grpConfiguration";
            // 
            // btnRally
            // 
            this.btnRally.Label = "Connect to Rally";
            this.btnRally.Name = "btnRally";
            this.btnRally.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ConnectRally);
            // 
            // btnSettings
            // 
            this.btnSettings.Label = "Settings";
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnSettings_Click);
            // 
            // group1
            // 
            this.group1.Items.Add(this.editBoxWorkspace);
            this.group1.Items.Add(this.editBoxProject);
            this.group1.Items.Add(this.btnSelectWrkspProj);
            this.group1.Label = "Scope Selection";
            this.group1.Name = "group1";
            // 
            // editBoxWorkspace
            // 
            this.editBoxWorkspace.Enabled = false;
            this.editBoxWorkspace.Label = "Workspace";
            this.editBoxWorkspace.Name = "editBoxWorkspace";
            this.editBoxWorkspace.SizeString = "123456789012345678901234567890";
            this.editBoxWorkspace.Text = null;
            // 
            // editBoxProject
            // 
            this.editBoxProject.Enabled = false;
            this.editBoxProject.Label = " Project";
            this.editBoxProject.Name = "editBoxProject";
            this.editBoxProject.SizeString = "123456789012345678901234567890";
            this.editBoxProject.Text = null;
            // 
            // btnSelectWrkspProj
            // 
            this.btnSelectWrkspProj.Enabled = false;
            this.btnSelectWrkspProj.Label = "Select Workspace and Project";
            this.btnSelectWrkspProj.Name = "btnSelectWrkspProj";
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tabPrintStories);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tabPrintStories.ResumeLayout(false);
            this.tabPrintStories.PerformLayout();
            this.grpConfiguration.ResumeLayout(false);
            this.grpConfiguration.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabPrintStories;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpConfiguration;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRally;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxWorkspace;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBoxProject;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSelectWrkspProj;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
