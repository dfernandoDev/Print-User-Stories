namespace Print_Stories
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
            this.tabPrintStories.SuspendLayout();
            this.grpConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrintStories
            // 
            this.tabPrintStories.Groups.Add(this.grpConfiguration);
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
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabPrintStories;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup grpConfiguration;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnRally;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnSettings;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon1 Ribbon1
        {
            get { return this.GetRibbon<Ribbon1>(); }
        }
    }
}
