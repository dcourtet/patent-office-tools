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

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Close(true);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close(false);
        }

        private void Close(bool write)
        {
            try
            {
                if (write)
                {
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
    }
}
