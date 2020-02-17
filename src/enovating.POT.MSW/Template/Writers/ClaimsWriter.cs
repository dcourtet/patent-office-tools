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
    public class ClaimsWriter : IWriter<Patent>
    {
        private const string _empty = "no claims are available for {0}";
        private const string _unavailable = "unavailable with {0}/{1} document";

        /// <inheritdoc />
        public bool Can(string code, Patent value)
        {
            return new[] { "Claims", "FirstClaim" }.Contains(code);
        }

        /// <summary>
        ///     Insert the values into the target document.
        /// </summary>
        /// <param name="target">The target document.</param>
        /// <param name="values">The values.</param>
        private void Insert(Range target, params PatentClaim[] values)
        {
            for (var index = 0; index < values.Length; index++)
            {
                target.Text += string.Concat(values[index].Number, ". ", values[index].Text);

                if (index + 1 < values.Length)
                {
                    target.Text += Environment.NewLine;
                }
            }
        }

        /// <inheritdoc />
        public void Write(string code, Patent value, Range target)
        {
            var current = value.PublicationNumber;

            if (current.C != "EP" || !current.K.StartsWith("B"))
            {
                target.Text = string.Format(_unavailable, current.C, current.K);
            }
            else if (value.Claims == null || value.Claims.Length == 0)
            {
                target.Text = string.Format(_empty, current);
            }
            else
            {
                switch (code)
                {
                    case "Claims":
                        Insert(target, value.Claims);
                        break;
                    case "FirstClaim":
                        Insert(target, value.Claims[0]);
                        break;
                    default:
                        throw new InvalidOperationException("wrong writer state");
                }
            }
        }
    }
}
