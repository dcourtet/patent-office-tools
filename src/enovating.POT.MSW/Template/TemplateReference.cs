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

namespace enovating.POT.MSW.Template
{
    using System.IO;

    /// <summary>
    ///     Template reference.
    /// </summary>
    public class TemplateReference
    {
        /// <summary>
        ///     Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Gets the path.
        /// </summary>
        public string Path { get; }

        /// <inheritdoc />
        public TemplateReference(string path)
        {
            Path = path;

            var fileInfo = new FileInfo(path);
            Name = fileInfo.Name.Replace(".dotx", null);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name;
        }
    }
}
