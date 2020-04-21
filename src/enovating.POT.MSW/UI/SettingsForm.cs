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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
            _patentPDFServerTextBox.Text = ToolsContext.Current.Settings.PatentPDFServer;

            foreach (var current in ToolsContext.Current.Settings.TemplateDirectories)
            {
                _templateDirectoryDataGridView.Rows.Add(current.Name, current.Path);
            }
        }

        /// <summary>
        ///     Sets the current settings from the components.
        /// </summary>
        private void SetSettings()
        {
            ToolsContext.Current.Settings.OPSConsumerKeys = _opsConsumerKeys.Text;
            ToolsContext.Current.Settings.PatentPDFServer = _patentPDFServerTextBox.Text;

            var templateDirectories = new List<TemplateDirectory>();

            foreach (DataGridViewRow current in _templateDirectoryDataGridView.Rows)
            {
                var name = (string) current.Cells[0].Value ?? "Directory";
                var path = (string) current.Cells[1].Value;

                if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
                {
                    continue;
                }

                if (templateDirectories.All(x => x.Path != path))
                {
                    templateDirectories.Add(new TemplateDirectory { Name = name, Path = path });
                }
            }

            ToolsContext.Current.Settings.TemplateDirectories = templateDirectories.ToArray();
        }

        private void TemplateDirectoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                return;
            }

            var current = _templateDirectoryDataGridView[e.ColumnIndex, e.RowIndex];

            using (var target = new FolderBrowserDialog())
            {
                target.RootFolder = Environment.SpecialFolder.MyComputer;
                target.ShowNewFolderButton = false;

                if (!string.IsNullOrEmpty((string) current.Value))
                {
                    target.SelectedPath = (string) current.Value;
                }

                if (target.ShowDialog() == DialogResult.OK)
                {
                    current.Value = target.SelectedPath;
                }
            }
        }
    }
}
