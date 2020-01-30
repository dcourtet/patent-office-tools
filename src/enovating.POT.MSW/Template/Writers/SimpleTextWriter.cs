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
    public class SimpleTextWriter : IWriter<Patent>
    {
        private const string _empty = "N/A";

        /// <inheritdoc />
        public bool Can(string code, Patent value)
        {
            return new[] { "Abstract", "AppCC", "AppDN", "AppDT", "AppFN", "Applicants", "CPC", "IPC", "Inventors", "PubCC", "PubDN", "PubDT", "PubFN", "PubKC", "Title" }.Contains(code);
        }

        /// <summary>
        ///     Formats the input value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The output string.</returns>
        private string Format(string input)
        {
            return string.IsNullOrEmpty(input) ? _empty : input;
        }

        /// <summary>
        ///     Formats the input value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The output string.</returns>
        private string Format(DateTime? input)
        {
            return input.HasValue ? input.Value.ToShortDateString() : _empty;
        }

        /// <summary>
        ///     Formats the input value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The output string.</returns>
        private string Format(string[] input)
        {
            return input == null || input.Length == 0 ? _empty : string.Join(" ; ", input);
        }

        /// <summary>
        ///     Formats the input value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <returns>The output string.</returns>
        private string Format(PatentNumber input)
        {
            return input != null ? input.Format(' ') : _empty;
        }

        /// <inheritdoc />
        public void Write(string code, Patent value, Range target)
        {
            switch (code)
            {
                case "Abstract":
                    target.Text = Format(value.Abstract);
                    break;
                case "AppCC":
                    target.Text = Format(value.ApplicationNumber.C);
                    break;
                case "AppDN":
                    target.Text = Format(value.ApplicationNumber?.N);
                    break;
                case "AppDT":
                    target.Text = Format(value.ApplicationDate);
                    break;
                case "AppFN":
                    target.Text = Format(value.ApplicationNumber);
                    break;
                case "Applicants":
                    target.Text = Format(value.Applicants);
                    break;
                case "CPC":
                    target.Text = Format(value.CPC);
                    break;
                case "IPC":
                    target.Text = Format(value.IPC);
                    break;
                case "Inventors":
                    target.Text = Format(value.Inventors);
                    break;
                case "PubCC":
                    target.Text = Format(value.PublicationNumber?.C);
                    break;
                case "PubDN":
                    target.Text = Format(value.PublicationNumber?.N);
                    break;
                case "PubDT":
                    target.Text = Format(value.PublicationDate);
                    break;
                case "PubFN":
                    target.Text = Format(value.PublicationNumber);
                    break;
                case "PubKC":
                    target.Text = Format(value.PublicationNumber?.K);
                    break;
                case "Title":
                    target.Text = Format(value.Title);
                    break;
                default:
                    throw new ArgumentException($"code '{code}' is not supported");
            }
        }
    }
}
