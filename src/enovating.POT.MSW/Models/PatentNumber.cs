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
    /// <summary>
    ///     Represents a patent number.
    /// </summary>
    public class PatentNumber
    {
        /// <summary>
        ///     Gets the country code.
        /// </summary>
        public string C { get; }

        /// <summary>
        ///     Gets the kind code.
        /// </summary>
        public string K { get; }

        /// <summary>
        ///     Gets the document number.
        /// </summary>
        public string N { get; }

        /// <inheritdoc />
        public PatentNumber(string c, string n, string k = null)
        {
            C = c;
            N = n;
            K = k;
        }

        /// <summary>
        ///     Parses the input to a patent number.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The patent number.</returns>
        public static PatentNumber Parse(string input)
        {
            var array = input.Split('.');
            return new PatentNumber(array[0], array[1], array[2]);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.IsNullOrEmpty(K) ? string.Concat(C, '.', N) : string.Concat(C, '.', N, '.', K);
        }
    }
}
