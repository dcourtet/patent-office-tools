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

namespace enovating.POT.MSW.Template.Writers
{
    using System;
    using System.Linq;

    using enovating.POT.MSW.Models;

    using Microsoft.Office.Interop.Word;

    /// <inheritdoc />
    public class LinkWriter : IWriter<Patent>
    {
        /// <inheritdoc />
        public bool Can(string code, Patent value)
        {
            return new[] { "LKEspacenet", "LKFullText", "LKGPatents" }.Contains(code);
        }

        private void InsertLink(Range target, string address, string text)
        {
            var previous = target.Font.Size;
            var element = target.Hyperlinks.Add(target, address, TextToDisplay: text);
            element.Range.Font.Size = previous;
        }

        /// <inheritdoc />
        public void Write(string code, Patent value, Range target)
        {
            switch (code)
            {
                case "LKEspacenet":
                    InsertLink(target, value.Links.Espacenet, "Espacenet");
                    break;
                case "LKFullText":
                    InsertLink(target, value.Links.FullText, "Full text (PDF)");
                    break;
                case "LKGPatents":
                    InsertLink(target, value.Links.GooglePatents, "Google Patents");
                    break;
                default:
                    throw new ArgumentException($"link code '{code}' is not supported");
            }
        }
    }
}
