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
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using enovating.POT.MSW.Core;
    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Template;

    using Microsoft.Office.Interop.Word;

    using Task = System.Threading.Tasks.Task;

    /// <inheritdoc />
    public partial class InsertForm : Form
    {
        /// <inheritdoc />
        public InsertForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async Task Insert()
        {
            SetUIState(false);

            var patents = await Retrieve(1);

            if (patents.Length != 0)
            {
                await Merge(patents);
            }

            SetUIState(true);
        }

        private async void InsertButton_Click(object sender, EventArgs e)
        {
            await Insert();
            Close();
        }

        private void InsertExplorerToolsDropDownButton(string name, string target)
        {
            var element = new ToolStripMenuItem();

            element.Click += OnToolStripMenuItemClick;

            element.Tag = target;
            element.Text = $"Open {name} in Windows Explorer";
            element.RightToLeft = RightToLeft.No;

            _toolsDropDownButton.DropDownItems.Add(element);
        }

        private async void InsertForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.Enter)
            {
                return;
            }

            await Insert();
            Close();
        }

        private void InsertForm_Load(object sender, EventArgs e)
        {
            ToolsContext.Current.TemplateManager.RefreshAvailableTemplate();

            InsertExplorerToolsDropDownButton("Temporary Directory", ToolsContext.Current.TemporaryDirectory);
            InsertExplorerToolsDropDownButton("Working Directory", ToolsContext.Current.WorkingDirectory);

            _toolsDropDownButton.DropDownItems.Add(new ToolStripSeparator());

            foreach (var directory in ToolsContext.Current.Settings.TemplateDirectories)
            {
                if (directory.Available)
                {
                    InsertExplorerToolsDropDownButton(directory.Name, directory.Path);
                }
            }

            if (ToolsContext.Current.TemplateManager.Available.Length != 0)
            {
                // sort directions
                _directionListBox.SelectedIndex = 0;
                // templates
                _templatesListBox.DataSource = ToolsContext.Current.TemplateManager.Available;
                _templatesListBox.SelectedItem = 0;
            }
            else
            {
                MessageBox.Show("No template is available.");
                Close();
            }
        }

        private async Task Merge(Patent[] values)
        {
            await UpdateProgression("merging template", 150);

            switch (_directionListBox.Text.Substring(0, 2))
            {
                case "02":
                    values = values.OrderBy(x => x.Title).ToArray();
                    break;
                case "03":
                    values = values.OrderBy(x => x.PublicationDate).ToArray();
                    break;
                case "04":
                    values = values.OrderByDescending(x => x.PublicationDate).ToArray();
                    break;
                case "05":
                    values = values.OrderBy(x => x.PublicationNumber?.C).ToArray();
                    break;
            }

            var template = (TemplateReference) _templatesListBox.SelectedItem;
            ToolsContext.Current.TemplateManager.Merge(template, values);

            await UpdateProgression(2500);
        }

        private void OnToolStripMenuItemClick(object sender, EventArgs e)
        {
            var target = (string) ((ToolStripMenuItem) sender).Tag;
            Process.Start("explorer.exe", target);
        }

        private async void PreviewButton_Click(object sender, EventArgs e)
        {
            SetUIState(false);
            await Retrieve();
            SetUIState(true);
        }

        private async Task<Patent[]> Retrieve(int offset = 0)
        {
            var lines = _numbersTextBox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (lines.Length == 0)
            {
                return new Patent[0];
            }

            _previewListBox.Items.Clear();

            _progressBar.Maximum = lines.Length + offset;
            _progressLabel.Text = "parsing numbers";

            var output = new List<string>();
            var results = new List<Patent>();

            foreach (var line in lines)
            {
                try
                {
                    var number = PatentNumber.Parse(line);

                    await UpdateProgression(number.ToString());

                    var patent = await ToolsContext.Current.Provider.Retrieve(number);
                    var patentTitle = string.Concat(number, '\t', patent.Title?.ToUpper() ?? "N/A");

                    _previewListBox.Items.Add(patentTitle);

                    output.Add(number.ToString());
                    results.Add(patent);
                }
                catch
                {
                    if (!line.StartsWith("*"))
                    {
                        output.Add(string.Concat("*", line));
                    }
                }
                finally
                {
                    await UpdateProgression();
                }
            }

            _numbersTextBox.Text = string.Join(Environment.NewLine, output);
            return results.ToArray();
        }

        private void SetUIState(bool state)
        {
            if (state)
            {
                _progressBar.Value = 0;
                _progressLabel.Text = null;
            }

            _cancelButton.Enabled = state;
            _directionListBox.Enabled = state;
            _insertButton.Enabled = state;
            _numbersTextBox.Enabled = state;
            _previewButton.Enabled = state;
            _previewListBox.Enabled = state;
            _templatesListBox.Enabled = state;

            Globals.ThisAddIn.Application.System.Cursor = state
                ? WdCursorType.wdCursorNormal
                : WdCursorType.wdCursorWait;
        }

        private async Task UpdateProgression(string text, int delay = 0)
        {
            _progressLabel.Text = text;
            await Task.Delay(delay);
        }

        private async Task UpdateProgression(int delay = 0)
        {
            _progressBar.PerformStep();
            await Task.Delay(delay);
        }
    }
}
