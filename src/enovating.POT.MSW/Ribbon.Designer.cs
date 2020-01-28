namespace enovating.POT.MSW
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
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
            this._ribbonTab = this.Factory.CreateRibbonTab();
            this._mainGroup = this.Factory.CreateRibbonGroup();
            this._ribbonTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ribbonTab
            // 
            this._ribbonTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this._ribbonTab.ControlId.OfficeId = "TabInsert";
            this._ribbonTab.Groups.Add(this._mainGroup);
            this._ribbonTab.Label = "TabInsert";
            this._ribbonTab.Name = "_ribbonTab";
            // 
            // _mainGroup
            // 
            this._mainGroup.Label = "Patent Office Tools";
            this._mainGroup.Name = "_mainGroup";
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this._ribbonTab);
            this._ribbonTab.ResumeLayout(false);
            this._ribbonTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab _ribbonTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup _mainGroup;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
