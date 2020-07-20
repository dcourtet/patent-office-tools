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
    using System;
    using System.IO;
    using System.Windows.Forms;

    using enovating.POT.MSW.Core;

    /// <summary>
    ///     Represents the current Microsoft Word Add-in.
    /// </summary>
    public partial class ThisAddIn
    {
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            ToolsContext.Destroy();
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            var rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var workingDirectory = Path.Combine(rootDirectory, "enovating", "patent-office-tools");

            try
            {
                ToolsContext.Initialize(workingDirectory);
            }
            catch (UserSettingsException)
            {
                ToolsContext.Reset(workingDirectory);
                ToolsContext.Initialize(workingDirectory);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Fatal error during module initialization: " + exception.Message, "Patent Office Tools");
            }
        }
    }
}
