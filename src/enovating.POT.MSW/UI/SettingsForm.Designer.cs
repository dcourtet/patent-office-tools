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
            this.SuspendLayout();
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(715, 86);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(150, 35);
            this._cancelButton.TabIndex = 0;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // _applyButton
            // 
            this._applyButton.Location = new System.Drawing.Point(559, 86);
            this._applyButton.Name = "_applyButton";
            this._applyButton.Size = new System.Drawing.Size(150, 35);
            this._applyButton.TabIndex = 1;
            this._applyButton.Text = "Apply";
            this._applyButton.UseVisualStyleBackColor = true;
            this._applyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // _templateDirectoryTitle
            // 
            this._templateDirectoryTitle.AutoSize = true;
            this._templateDirectoryTitle.Location = new System.Drawing.Point(28, 57);
            this._templateDirectoryTitle.Name = "_templateDirectoryTitle";
            this._templateDirectoryTitle.Size = new System.Drawing.Size(146, 20);
            this._templateDirectoryTitle.TabIndex = 2;
            this._templateDirectoryTitle.Text = "Template Directory:";
            // 
            // _templateDirectoryTextBox
            // 
            this._templateDirectoryTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._templateDirectoryTextBox.Location = new System.Drawing.Point(195, 54);
            this._templateDirectoryTextBox.Name = "_templateDirectoryTextBox";
            this._templateDirectoryTextBox.ReadOnly = true;
            this._templateDirectoryTextBox.Size = new System.Drawing.Size(670, 26);
            this._templateDirectoryTextBox.TabIndex = 3;
            this._templateDirectoryTextBox.Click += new System.EventHandler(this.TemplateDirectoryTextBox_Click);
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
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 149);
            this.Controls.Add(this._opsConsumerKeys);
            this.Controls.Add(this._opsConsumerKeysTitle);
            this.Controls.Add(this._templateDirectoryTextBox);
            this.Controls.Add(this._templateDirectoryTitle);
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
    }
}