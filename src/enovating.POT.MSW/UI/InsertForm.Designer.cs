namespace enovating.POT.MSW.UI
{
    partial class InsertForm
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
            this._availableTemplates = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // _availableTemplates
            // 
            this._availableTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._availableTemplates.FormattingEnabled = true;
            this._availableTemplates.Location = new System.Drawing.Point(12, 12);
            this._availableTemplates.Name = "_availableTemplates";
            this._availableTemplates.Size = new System.Drawing.Size(776, 28);
            this._availableTemplates.TabIndex = 0;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._availableTemplates);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert - Patent Office Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox _availableTemplates;
    }
}