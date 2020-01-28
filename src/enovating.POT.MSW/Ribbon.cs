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

namespace enovating.POT.MSW
{
    using enovating.POT.MSW.Core;
    using enovating.POT.MSW.UI;

    using Microsoft.Office.Tools.Ribbon;

    public partial class Ribbon
    {
        private void InsertButton_Click(object sender, RibbonControlEventArgs e)
        {
            new InsertForm().ShowDialog();
        }

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {
            _insertButton.Enabled = ToolsContext.Current.Settings.Ready;
        }

        private void _insertButton_Click(object sender, RibbonControlEventArgs e)
        {

        }
    }
}
