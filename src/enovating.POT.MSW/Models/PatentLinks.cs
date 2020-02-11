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

    using enovating.POT.MSW.Core;

    /// <summary>
    ///     Represents patent external links.
    /// </summary>
    public class PatentLinks
    {
        /// <summary>
        ///     Gets the link to Espacenet.
        /// </summary>
        public string Espacenet { get; }

        /// <summary>
        ///     Gets the link to the PDF.
        /// </summary>
        public string FullText { get; }

        /// <summary>
        ///     Gets the link to Google Patents.
        /// </summary>
        public string GooglePatents { get; }

        /// <inheritdoc />
        public PatentLinks(PatentNumber number)
        {
            if (number == null)
            {
                throw new ArgumentNullException(nameof(number));
            }

            Espacenet = string.Concat("https://worldwide.espacenet.com/patent/search/publication/", number.Format());
            FullText = string.Format(ToolsContext.Current.Settings.PatentPDFServer, number.Format());
            GooglePatents = string.Concat("https://patents.google.com/?q=", number.Format());
        }
    }
}
