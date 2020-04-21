namespace enovating.POT.MSW.UI
{
    partial class SettingsForm
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
            this._cancelButton = new System.Windows.Forms.Button();
            this._applyButton = new System.Windows.Forms.Button();
            this._templateDirectoriesTitle = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this._opsConsumerKeys = new System.Windows.Forms.TextBox();
            this._opsConsumerKeysTitle = new System.Windows.Forms.Label();
            this._patentPDFServerTextBox = new System.Windows.Forms.TextBox();
            this._patentPDFServerTitle = new System.Windows.Forms.Label();
            this._templateDirectoryDataGridView = new System.Windows.Forms.DataGridView();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._templateDirectoryDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(715, 293);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(150, 35);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _applyButton
            // 
            this._applyButton.Location = new System.Drawing.Point(559, 293);
            this._applyButton.Name = "_applyButton";
            this._applyButton.Size = new System.Drawing.Size(150, 35);
            this._applyButton.TabIndex = 1;
            this._applyButton.Text = "Apply";
            this._applyButton.UseVisualStyleBackColor = true;
            this._applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // _templateDirectoriesTitle
            // 
            this._templateDirectoriesTitle.AutoSize = true;
            this._templateDirectoriesTitle.Location = new System.Drawing.Point(28, 87);
            this._templateDirectoriesTitle.Name = "_templateDirectoriesTitle";
            this._templateDirectoriesTitle.Size = new System.Drawing.Size(159, 20);
            this._templateDirectoriesTitle.TabIndex = 2;
            this._templateDirectoriesTitle.Text = "Template Directories:";
            // 
            // _opsConsumerKeys
            // 
            this._opsConsumerKeys.Location = new System.Drawing.Point(195, 22);
            this._opsConsumerKeys.Name = "_opsConsumerKeys";
            this._opsConsumerKeys.Size = new System.Drawing.Size(670, 26);
            this._opsConsumerKeys.TabIndex = 5;
            // 
            // _opsConsumerKeysTitle
            // 
            this._opsConsumerKeysTitle.AutoSize = true;
            this._opsConsumerKeysTitle.Location = new System.Drawing.Point(28, 25);
            this._opsConsumerKeysTitle.Name = "_opsConsumerKeysTitle";
            this._opsConsumerKeysTitle.Size = new System.Drawing.Size(161, 20);
            this._opsConsumerKeysTitle.TabIndex = 4;
            this._opsConsumerKeysTitle.Text = "OPS Consumer Keys:";
            // 
            // _patentPDFServerTextBox
            // 
            this._patentPDFServerTextBox.Location = new System.Drawing.Point(195, 54);
            this._patentPDFServerTextBox.Name = "_patentPDFServerTextBox";
            this._patentPDFServerTextBox.Size = new System.Drawing.Size(670, 26);
            this._patentPDFServerTextBox.TabIndex = 7;
            // 
            // _patentPDFServerTitle
            // 
            this._patentPDFServerTitle.AutoSize = true;
            this._patentPDFServerTitle.Location = new System.Drawing.Point(28, 56);
            this._patentPDFServerTitle.Name = "_patentPDFServerTitle";
            this._patentPDFServerTitle.Size = new System.Drawing.Size(146, 20);
            this._patentPDFServerTitle.TabIndex = 6;
            this._patentPDFServerTitle.Text = "Patent PDF Server:";
            // 
            // _templateDirectoryDataGridView
            // 
            this._templateDirectoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._templateDirectoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameColumn,
            this.PathColumn});
            this._templateDirectoryDataGridView.Location = new System.Drawing.Point(195, 87);
            this._templateDirectoryDataGridView.Name = "_templateDirectoryDataGridView";
            this._templateDirectoryDataGridView.RowHeadersVisible = false;
            this._templateDirectoryDataGridView.RowHeadersWidth = 62;
            this._templateDirectoryDataGridView.RowTemplate.Height = 28;
            this._templateDirectoryDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._templateDirectoryDataGridView.Size = new System.Drawing.Size(670, 200);
            this._templateDirectoryDataGridView.TabIndex = 8;
            this._templateDirectoryDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TemplateDirectoryDataGridView_CellClick);
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.MaxInputLength = 10;
            this.NameColumn.MinimumWidth = 8;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Width = 150;
            // 
            // PathColumn
            // 
            this.PathColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PathColumn.HeaderText = "Path";
            this.PathColumn.MinimumWidth = 8;
            this.PathColumn.Name = "PathColumn";
            this.PathColumn.ReadOnly = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 345);
            this.Controls.Add(this._templateDirectoryDataGridView);
            this.Controls.Add(this._patentPDFServerTextBox);
            this.Controls.Add(this._patentPDFServerTitle);
            this.Controls.Add(this._opsConsumerKeys);
            this.Controls.Add(this._opsConsumerKeysTitle);
            this.Controls.Add(this._templateDirectoriesTitle);
            this.Controls.Add(this._applyButton);
            this.Controls.Add(this._cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(25);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings - Office Patent Tools";
            ((System.ComponentModel.ISupportInitialize)(this._templateDirectoryDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _applyButton;
        private System.Windows.Forms.Label _templateDirectoriesTitle;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox _opsConsumerKeys;
        private System.Windows.Forms.Label _opsConsumerKeysTitle;
        private System.Windows.Forms.TextBox _patentPDFServerTextBox;
        private System.Windows.Forms.Label _patentPDFServerTitle;
        private System.Windows.Forms.DataGridView _templateDirectoryDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathColumn;
    }
}
