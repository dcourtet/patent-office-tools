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
            this._templateDirectoryTitle = new System.Windows.Forms.Label();
            this._templateDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this._opsConsumerKeys = new System.Windows.Forms.TextBox();
            this._opsConsumerKeysTitle = new System.Windows.Forms.Label();
            this._patentPDFServerTextBox = new System.Windows.Forms.TextBox();
            this._patentPDFServerTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(952, 145);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(200, 44);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _applyButton
            // 
            this._applyButton.Location = new System.Drawing.Point(744, 145);
            this._applyButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._applyButton.Name = "_applyButton";
            this._applyButton.Size = new System.Drawing.Size(200, 44);
            this._applyButton.TabIndex = 1;
            this._applyButton.Text = "Apply";
            this._applyButton.UseVisualStyleBackColor = true;
            this._applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // _templateDirectoryTitle
            // 
            this._templateDirectoryTitle.AutoSize = true;
            this._templateDirectoryTitle.Location = new System.Drawing.Point(37, 109);
            this._templateDirectoryTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._templateDirectoryTitle.Name = "_templateDirectoryTitle";
            this._templateDirectoryTitle.Size = new System.Drawing.Size(199, 25);
            this._templateDirectoryTitle.TabIndex = 2;
            this._templateDirectoryTitle.Text = "Template Directory:";
            // 
            // _templateDirectoryTextBox
            // 
            this._templateDirectoryTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._templateDirectoryTextBox.Location = new System.Drawing.Point(260, 106);
            this._templateDirectoryTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._templateDirectoryTextBox.Name = "_templateDirectoryTextBox";
            this._templateDirectoryTextBox.ReadOnly = true;
            this._templateDirectoryTextBox.Size = new System.Drawing.Size(892, 31);
            this._templateDirectoryTextBox.TabIndex = 3;
            this._templateDirectoryTextBox.Click += new System.EventHandler(this.TemplateDirectoryTextBox_Click);
            // 
            // _opsConsumerKeys
            // 
            this._opsConsumerKeys.Location = new System.Drawing.Point(260, 28);
            this._opsConsumerKeys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this._opsConsumerKeys.Name = "_opsConsumerKeys";
            this._opsConsumerKeys.Size = new System.Drawing.Size(892, 31);
            this._opsConsumerKeys.TabIndex = 5;
            // 
            // _opsConsumerKeysTitle
            // 
            this._opsConsumerKeysTitle.AutoSize = true;
            this._opsConsumerKeysTitle.Location = new System.Drawing.Point(37, 31);
            this._opsConsumerKeysTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._opsConsumerKeysTitle.Name = "_opsConsumerKeysTitle";
            this._opsConsumerKeysTitle.Size = new System.Drawing.Size(220, 25);
            this._opsConsumerKeysTitle.TabIndex = 4;
            this._opsConsumerKeysTitle.Text = "OPS Consumer Keys:";
            // 
            // _patentPDFServerTextBox
            // 
            this._patentPDFServerTextBox.Location = new System.Drawing.Point(260, 67);
            this._patentPDFServerTextBox.Margin = new System.Windows.Forms.Padding(4);
            this._patentPDFServerTextBox.Name = "_patentPDFServerTextBox";
            this._patentPDFServerTextBox.Size = new System.Drawing.Size(892, 31);
            this._patentPDFServerTextBox.TabIndex = 7;
            // 
            // _patentPDFServerTitle
            // 
            this._patentPDFServerTitle.AutoSize = true;
            this._patentPDFServerTitle.Location = new System.Drawing.Point(37, 70);
            this._patentPDFServerTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._patentPDFServerTitle.Name = "_patentPDFServerTitle";
            this._patentPDFServerTitle.Size = new System.Drawing.Size(197, 25);
            this._patentPDFServerTitle.TabIndex = 6;
            this._patentPDFServerTitle.Text = "Patent PDF Server:";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 219);
            this.Controls.Add(this._patentPDFServerTextBox);
            this.Controls.Add(this._patentPDFServerTitle);
            this.Controls.Add(this._opsConsumerKeys);
            this.Controls.Add(this._opsConsumerKeysTitle);
            this.Controls.Add(this._templateDirectoryTextBox);
            this.Controls.Add(this._templateDirectoryTitle);
            this.Controls.Add(this._applyButton);
            this.Controls.Add(this._cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(33, 31, 33, 31);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings - Office Patent Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.Button _applyButton;
        private System.Windows.Forms.Label _templateDirectoryTitle;
        private System.Windows.Forms.TextBox _templateDirectoryTextBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox _opsConsumerKeys;
        private System.Windows.Forms.Label _opsConsumerKeysTitle;
        private System.Windows.Forms.TextBox _patentPDFServerTextBox;
        private System.Windows.Forms.Label _patentPDFServerTitle;
    }
}