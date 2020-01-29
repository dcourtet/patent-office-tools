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

namespace enovating.POT.MSW.Core
{
    using System;
    using System.IO;

    /// <summary>
    ///     Office Tools Context.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class ToolsContext : IDisposable
    {
        /// <summary>
        ///     Gets the current context.
        /// </summary>
        public static ToolsContext Current { get; private set; }

        /// <summary>
        ///     Gets the user settings.
        /// </summary>
        public UserSettings Settings { get; }

        /// <summary>
        ///     Gets the working directory.
        /// </summary>
        public string WorkingDirectory { get; }

        /// <inheritdoc />
        private ToolsContext(string workingDirectory)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            Directory.CreateDirectory(workingDirectory);
            WorkingDirectory = workingDirectory;

            var settingsTarget = Path.Combine(WorkingDirectory, "settings.json");
            Settings = UserSettings.Initialize(settingsTarget);
            Settings.Wrote += OnSettingsChange;

            InitializeComponents();
        }

        /// <summary>
        ///     Destroy the current context.
        /// </summary>
        public static void Destroy()
        {
            Current?.Dispose();
            Current = null;
        }

        /// <summary>
        ///     Initialize the context.
        /// </summary>
        /// <param name="workingDirectory">The working directory.</param>
        public static void Initialize(string workingDirectory)
        {
            if (Current != null)
            {
                throw new InvalidOperationException("context is already initialized");
            }

            Current = new ToolsContext(workingDirectory);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Settings.Wrote -= OnSettingsChange;
        }

        /// <summary>
        ///     Initialize context components.
        /// </summary>
        private void InitializeComponents()
        {
            // todo
        }

        /// <summary>
        ///     When settings change.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event argument.</param>
        private void OnSettingsChange(object sender, EventArgs e)
        {
            InitializeComponents();
        }
    }
}
