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

    using enovating.POT.MSW.Providers;
    using enovating.POT.MSW.Template;

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
        ///     Gets the patent provider.
        /// </summary>
        public PatentProvider Provider { get; private set; }

        /// <summary>
        ///     Gets the user settings.
        /// </summary>
        public UserSettings Settings { get; }

        /// <summary>
        ///     Gets the template manager.
        /// </summary>
        public TemplateManager TemplateManager { get; private set; }

        /// <summary>
        ///     Gets the temporary directory.
        /// </summary>
        public string TemporaryDirectory { get; }

        /// <summary>
        ///     Gets the working directory.
        /// </summary>
        public string WorkingDirectory { get; }

        private ToolsContext(string workingDirectory)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            WorkingDirectory = workingDirectory;
            Directory.CreateDirectory(WorkingDirectory);

            TemporaryDirectory = Path.Combine(WorkingDirectory, "temporary");
            Directory.CreateDirectory(TemporaryDirectory);

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

        /// <summary>
        ///     Deletes the temporary directory.
        /// </summary>
        private void DeleteTemporaryDirectory()
        {
            try
            {
                Directory.Delete(TemporaryDirectory);
            }
            catch
            {
                // ignored
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Provider?.Dispose();
            Settings.Wrote -= OnSettingsChange;

            DeleteTemporaryDirectory();
        }

        /// <summary>
        ///     Initialize context components.
        /// </summary>
        private void InitializeComponents()
        {
            if (!Settings.Ready)
            {
                return;
            }

            Provider = new PatentProvider(Settings.OPSConsumerKeys);
            TemplateManager = new TemplateManager(Settings.TemplateDirectory);
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
