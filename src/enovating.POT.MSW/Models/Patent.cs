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
    ///     Represents a patent document.
    /// </summary>
    public class Patent
    {
        /// <summary>
        ///     Gets or sets the abstract.
        /// </summary>
        public string Abstract { get; set; }

        /// <summary>
        ///     Gets or sets the applicants.
        /// </summary>
        public string[] Applicants { get; set; }

        /// <summary>
        ///     Gets or sets the application date.
        /// </summary>
        public DateTime? ApplicationDate { get; set; }

        /// <summary>
        ///     Gets or sets the application number.
        /// </summary>
        public PatentNumber ApplicationNumber { get; set; }

        /// <summary>
        ///     Gets or sets the claims.
        /// </summary>
        public PatentClaim[] Claims { get; set; }

        /// <summary>
        ///     Gets or sets the Cooperative Patent Classification (CPC).
        /// </summary>
        public string[] CPC { get; set; }

        /// <summary>
        ///     Gets or sets the family members.
        /// </summary>
        public PatentFamilyMember[] Family { get; set; }

        /// <summary>
        ///     Gets or sets the first priority date.
        /// </summary>
        public DateTime? FirstPriorityDate { get; set; }

        /// <summary>
        ///     Gets or sets the first priority number.
        /// </summary>
        public PatentNumber FirstPriorityNumber { get; set; }

        /// <summary>
        ///     Gets or sets the inventors.
        /// </summary>
        public string[] Inventors { get; set; }

        /// <summary>
        ///     Gets or sets the International Patent Classification (IPC).
        /// </summary>
        public string[] IPC { get; set; }

        /// <summary>
        ///     Gets the external links.
        /// </summary>
        public PatentLinks Links => new PatentLinks(PublicationNumber);

        /// <summary>
        ///     Gets or sets the picture content.
        /// </summary>
        public byte[] Picture { get; set; }

        /// <summary>
        ///     Gets or sets the publication date.
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        ///     Gets or sets the publication number.
        /// </summary>
        public PatentNumber PublicationNumber { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }
    }
}
