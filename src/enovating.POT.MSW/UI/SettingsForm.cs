// -------------------------------------------------------------------------------------
// This file is part of 'Patent Office Tools' source code.
// 
// Patent Office Tools is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but without any warranty; without even the implied warranty of
// merchantability or fitness for a particular purpose. See the
// GNU Affero General Public License for more details.
// 
// Copyright 2019-2020 enovating SA <https://www.enovating.com/>
// -------------------------------------------------------------------------------------

namespace enovating.POT.MSW.UI
{
    using System;
    using System.Windows.Forms;

    using enovating.POT.MSW.Core;

    /// <inheritdoc />
    public partial class SettingsForm : Form
    {
        /// <inheritdoc />
        public SettingsForm()
        {
            InitializeComponent();
            InitializeComponentValue();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Close(true);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close(false);
        }

        /// <summary>
        ///     Close the window.
        /// </summary>
        /// <param name="write">If <c>true</c>, writes the settings.</param>
        private void Close(bool write)
        {
            try
            {
                if (write)
                {
                    SetSettings();
                    ToolsContext.Current.Settings.Write();
                }
            }
            catch
            {
                MessageBox.Show("Failed to save settings.");
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        ///     Initialize components value.
        /// </summary>
        private void InitializeComponentValue()
        {
            if (!ToolsContext.Current.Settings.Ready)
            {
                return;
            }

            _opsConsumerKeys.Text = ToolsContext.Current.Settings.OPSConsumerKeys;
            _templateDirectoryTextBox.Text = ToolsContext.Current.Settings.TemplateDirectory;
        }

        /// <summary>
        ///     Sets the current settings from the components.
        /// </summary>
        private void SetSettings()
        {
            ToolsContext.Current.Settings.OPSConsumerKeys = _opsConsumerKeys.Text;
            ToolsContext.Current.Settings.TemplateDirectory = _templateDirectoryTextBox.Text;
        }

        private void TemplateDirectoryTextBox_Click(object sender, EventArgs e)
        {
            using (var target = new FolderBrowserDialog())
            {
                target.RootFolder = Environment.SpecialFolder.MyComputer;
                target.ShowNewFolderButton = false;

                if (!string.IsNullOrEmpty(_templateDirectoryTextBox.Text))
                {
                    target.SelectedPath = _templateDirectoryTextBox.Text;
                }

                if (target.ShowDialog() == DialogResult.OK)
                {
                    _templateDirectoryTextBox.Text = target.SelectedPath;
                }
            }
        }
    }
}
