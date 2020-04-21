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
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Template directory.
    /// </summary>
    public class TemplateDirectory
    {
        /// <summary>
        ///     Gets the availability.
        /// </summary>
        [IgnoreDataMember]
        public bool Available => Directory.Exists(Path);

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the path.
        /// </summary>
        [DataMember]
        public string Path { get; set; }
    }
}
