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
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using enovating.POT.MSW.Core;
    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Template;

    /// <inheritdoc />
    public partial class InsertForm : Form
    {
        /// <inheritdoc />
        public InsertForm()
        {
            InitializeComponent();
            InitializeSource();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private PatentNumber[] ExtractNumbers(string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(PatentNumber.Parse).Distinct(new PatentNumberComparer()).ToArray();
        }

        private void InitializeSource()
        {
            if (ToolsContext.Current.TemplateManager.Available.Length == 0)
            {
                MessageBox.Show("No template is available.");
            }

            _templatesListBox.DataSource = ToolsContext.Current.TemplateManager.Available;
            _templatesListBox.SelectedItem = 0;

            _directionListBox.SelectedIndex = 0;
        }

        private async void InsertButton_Click(object sender, EventArgs e)
        {
            var numbers = ExtractNumbers(_numbersTextBox.Text);

            if (numbers.Length == 0)
            {
                return;
            }

            SetControlsState(false, true, numbers.Length + 1);
            var patents = await Retrieve(numbers);

            if (patents.Length == 0)
            {
                return;
            }

            switch (_directionListBox.Text.Substring(0, 2))
            {
                case "02":
                    patents = patents.OrderBy(x => x.Title).ToArray();
                    break;
                case "03":
                    patents = patents.OrderBy(x => x.PublicationDate).ToArray();
                    break;
                case "04":
                    patents = patents.OrderByDescending(x => x.PublicationDate).ToArray();
                    break;
                case "05":
                    patents = patents.OrderBy(x => x.PublicationNumber?.C).ToArray();
                    break;
            }

            var template = (TemplateReference) _templatesListBox.SelectedItem;

            _progressLabel.Text = $"merging template {template.Name}";
            ToolsContext.Current.TemplateManager.Merge(template, patents);

            await Task.Delay(500);
            _progressBar.PerformStep();
            await Task.Delay(150);
            
            Cursor.Current = Cursors.Default;

            Close();
        }

        private async void PreviewButton_Click(object sender, EventArgs e)
        {
            var numbers = ExtractNumbers(_numbersTextBox.Text);

            if (numbers.Length == 0)
            {
                return;
            }

            SetControlsState(false, true, numbers.Length);
            await Retrieve(numbers);
            SetControlsState(true, false);
        }

        private async Task<Patent[]> Retrieve(IReadOnlyCollection<PatentNumber> numbers)
        {
            if (numbers.Count == 0)
            {
                return new Patent[0];
            }

            _previewListBox.Items.Clear();
            var results = new List<Patent>();

            foreach (var number in numbers)
            {
                try
                {
                    _progressLabel.Text = number.Format('.');

                    var patent = await ToolsContext.Current.Provider.Retrieve(number);
                    var patentTitle = string.Concat(number, '\t', patent.Title.ToUpper());

                    _previewListBox.Items.Add(patentTitle);
                    _progressBar.PerformStep();
                    
                    results.Add(patent);
                }
                catch
                {
                    MessageBox.Show($"{number} is not available", "Patent Office Tools");
                }
            }

            return results.ToArray();
        }

        private void SetControlsState(bool enabled, bool reset, int maximum = 0)
        {
            _progressBar.Maximum = maximum;

            if (reset)
            {
                _progressBar.Value = 0;
                _previewListBox.Items.Clear();
            }

            _cancelButton.Enabled = enabled;
            _insertButton.Enabled = enabled;
            _numbersTextBox.Enabled = enabled;
            _previewButton.Enabled = enabled;
            _previewListBox.Enabled = enabled;
            _templatesListBox.Enabled = enabled;

            Cursor.Current = enabled ? Cursors.Default : Cursors.WaitCursor;
        }
    }
}
