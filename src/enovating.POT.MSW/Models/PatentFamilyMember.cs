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

namespace enovating.POT.MSW.Models
{
    using System;

    /// <summary>
    ///     Represents a patent family member.
    /// </summary>
    public class PatentFamilyMember
    {
        /// <summary>
        ///     Gets or sets the application date.
        /// </summary>
        public DateTime? ApplicationDate { get; set; }

        /// <summary>
        ///     Gets or sets the application number.
        /// </summary>
        public PatentNumber ApplicationNumber { get; set; }

        /// <summary>
        ///     Gets the external links.
        /// </summary>
        public PatentLinks Links => new PatentLinks(PublicationNumber);

        /// <summary>
        ///     Gets or sets the publication date.
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        ///     Gets or sets the publication number.
        /// </summary>
        public PatentNumber PublicationNumber { get; set; }
    }
}
