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

    using enovating.POT.MSW.Models;

    using Microsoft.Office.Interop.Word;

    /// <inheritdoc />
    public class FamilyWriter : IWriter<Patent>
    {
        private const string _empty = "N/A";

        /// <inheritdoc />
        public bool Can(string code, Patent value)
        {
            return value.Family != null && (code == "Family" || code == "FamilyLK");
        }

        /// <summary>
        ///     Inserts the value into the document target range.
        /// </summary>
        /// <param name="target">The document target range.</param>
        /// <param name="value">The value.</param>
        private void Insert(Range target, string value)
        {
            target.Text = string.IsNullOrEmpty(value) ? _empty : value;
        }

        /// <summary>
        ///     Inserts the value into the document target range.
        /// </summary>
        /// <param name="target">The document target range.</param>
        /// <param name="value">The value.</param>
        /// <param name="address">The URL address.</param>
        private void Insert(Range target, string value, string address)
        {
            var previous = target.Font.Size;
            var element = target.Hyperlinks.Add(target, address, TextToDisplay: value);
            element.Range.Font.Size = previous;
        }

        /// <summary>
        ///     Inserts the value into the document target range.
        /// </summary>
        /// <param name="target">The document target range.</param>
        /// <param name="value">The value.</param>
        /// <param name="address">The URL address.</param>
        private void Insert(Range target, PatentNumber value, string address)
        {
            Insert(target, value.ToString(), address);
        }

        /// <summary>
        ///     Inserts the value into the document target range.
        /// </summary>
        /// <param name="target">The document target range.</param>
        /// <param name="value">The value.</param>
        private void Insert(Range target, PatentNumber value)
        {
            Insert(target, value?.ToString());
        }

        /// <summary>
        ///     Inserts the value into the document target range.
        /// </summary>
        /// <param name="target">The document target range.</param>
        /// <param name="value">The value.</param>
        private void Insert(Range target, DateTime? value)
        {
            Insert(target, value?.ToShortDateString());
        }

        /// <inheritdoc />
        public void Write(string code, Patent value, Range target)
        {
            var table = target.Tables.Add(target, value.Family.Length, 5);

            for (var index = 0; index < table.Rows.Count; index++)
            {
                var current = value.Family[index];

                if (code == "FamilyLK")
                {
                    Insert(table.Cell(index + 1, 1).Range, current.PublicationNumber, current.Links.Espacenet);
                }
                else
                {
                    Insert(table.Cell(index + 1, 1).Range, current.PublicationNumber);
                }

                Insert(table.Cell(index + 1, 2).Range, current.PublicationDate);
                Insert(table.Cell(index + 1, 3).Range, current.ApplicationNumber);
                Insert(table.Cell(index + 1, 4).Range, current.ApplicationDate);
                Insert(table.Cell(index + 1, 5).Range, "PDF", current.Links.FullText);
            }
        }
    }
}
