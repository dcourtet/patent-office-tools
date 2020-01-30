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
            this._progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._progressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._mainPanel = new System.Windows.Forms.Panel();
            this._directionListBox = new System.Windows.Forms.ListBox();
            this._insertButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._templatesListBox = new System.Windows.Forms.ListBox();
            this._previewButton = new System.Windows.Forms.Button();
            this._previewListBox = new System.Windows.Forms.ListBox();
            this._numbersTextBox = new System.Windows.Forms.TextBox();
            this._statusStrip.SuspendLayout();
            this._mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _progressBar
            // 
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(175, 20);
            this._progressBar.Step = 1;
            // 
            // _statusStrip
            // 
            this._statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._progressBar,
            this._progressLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 599);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._statusStrip.Size = new System.Drawing.Size(916, 28);
            this._statusStrip.SizingGrip = false;
            this._statusStrip.TabIndex = 1;
            // 
            // _progressLabel
            // 
            this._progressLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._progressLabel.Name = "_progressLabel";
            this._progressLabel.Size = new System.Drawing.Size(0, 21);
            // 
            // _mainPanel
            // 
            this._mainPanel.Controls.Add(this._directionListBox);
            this._mainPanel.Controls.Add(this._insertButton);
            this._mainPanel.Controls.Add(this._cancelButton);
            this._mainPanel.Controls.Add(this._templatesListBox);
            this._mainPanel.Controls.Add(this._previewButton);
            this._mainPanel.Controls.Add(this._previewListBox);
            this._mainPanel.Controls.Add(this._numbersTextBox);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(0, 0);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Padding = new System.Windows.Forms.Padding(25);
            this._mainPanel.Size = new System.Drawing.Size(916, 599);
            this._mainPanel.TabIndex = 2;
            // 
            // _directionListBox
            // 
            this._directionListBox.FormattingEnabled = true;
            this._directionListBox.ItemHeight = 20;
            this._directionListBox.Items.AddRange(new object[] {
            "01 - Default",
            "02 - Title alphabetically",
            "03 - Earliest publication",
            "04 - Latest publication",
            "05 - Country alphabetically"});
            this._directionListBox.Location = new System.Drawing.Point(638, 334);
            this._directionListBox.Name = "_directionListBox";
            this._directionListBox.Size = new System.Drawing.Size(250, 204);
            this._directionListBox.TabIndex = 6;
            // 
            // _insertButton
            // 
            this._insertButton.Location = new System.Drawing.Point(582, 544);
            this._insertButton.Name = "_insertButton";
            this._insertButton.Size = new System.Drawing.Size(150, 35);
            this._insertButton.TabIndex = 5;
            this._insertButton.Text = "Insert";
            this._insertButton.UseVisualStyleBackColor = true;
            this._insertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(738, 544);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(150, 35);
            this._cancelButton.TabIndex = 4;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _templatesListBox
            // 
            this._templatesListBox.FormattingEnabled = true;
            this._templatesListBox.ItemHeight = 20;
            this._templatesListBox.Location = new System.Drawing.Point(28, 334);
            this._templatesListBox.Name = "_templatesListBox";
            this._templatesListBox.Size = new System.Drawing.Size(604, 204);
            this._templatesListBox.TabIndex = 3;
            // 
            // _previewButton
            // 
            this._previewButton.Location = new System.Drawing.Point(788, 298);
            this._previewButton.Name = "_previewButton";
            this._previewButton.Size = new System.Drawing.Size(100, 30);
            this._previewButton.TabIndex = 2;
            this._previewButton.Text = "Preview";
            this._previewButton.UseVisualStyleBackColor = true;
            this._previewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // _previewListBox
            // 
            this._previewListBox.FormattingEnabled = true;
            this._previewListBox.ItemHeight = 20;
            this._previewListBox.Location = new System.Drawing.Point(284, 28);
            this._previewListBox.Name = "_previewListBox";
            this._previewListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this._previewListBox.Size = new System.Drawing.Size(604, 264);
            this._previewListBox.TabIndex = 1;
            // 
            // _numbersTextBox
            // 
            this._numbersTextBox.Location = new System.Drawing.Point(28, 28);
            this._numbersTextBox.Multiline = true;
            this._numbersTextBox.Name = "_numbersTextBox";
            this._numbersTextBox.Size = new System.Drawing.Size(250, 264);
            this._numbersTextBox.TabIndex = 0;
            // 
            // InsertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 627);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insert - Patent Office Tools";
            this.Load += new System.EventHandler(this.InsertForm_Load);
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this._mainPanel.ResumeLayout(false);
            this._mainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripProgressBar _progressBar;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.Panel _mainPanel;
        private System.Windows.Forms.Button _previewButton;
        private System.Windows.Forms.ListBox _previewListBox;
        private System.Windows.Forms.TextBox _numbersTextBox;
        private System.Windows.Forms.Button _insertButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ListBox _templatesListBox;
        private System.Windows.Forms.ToolStripStatusLabel _progressLabel;
        private System.Windows.Forms.ListBox _directionListBox;
    }
}
