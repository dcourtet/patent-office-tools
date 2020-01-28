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
    public class ToolsContext
    {
        /// <summary>
        ///     Gets the current context.
        /// </summary>
        public static ToolsContext Current { get; private set; }

        /// <summary>
        ///     Gets the working directory.
        /// </summary>
        public string WorkingDirectory { get; }

        /// <inheritdoc />
        public ToolsContext(string workingDirectory)
        {
            if (string.IsNullOrEmpty(workingDirectory))
            {
                throw new ArgumentNullException(nameof(workingDirectory));
            }

            Directory.CreateDirectory(workingDirectory);
            WorkingDirectory = workingDirectory;
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
    }
}
