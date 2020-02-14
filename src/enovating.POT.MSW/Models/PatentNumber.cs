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
    using System.Text.RegularExpressions;

    /// <summary>
    ///     Represents a patent number.
    /// </summary>
    public class PatentNumber
    {
        /// <summary>
        ///     Gets the country code.
        /// </summary>
        public string C { get; private set; }

        /// <summary>
        ///     Gets the kind code.
        /// </summary>
        public string K { get; private set; }

        /// <summary>
        ///     Gets the document number.
        /// </summary>
        public string N { get; private set; }

        public PatentNumber(string c, string n, string k = null)
        {
            C = c ?? throw new ArgumentNullException(nameof(c));
            N = n ?? throw new ArgumentNullException(nameof(n));
            K = k;
        }

        private PatentNumber() { }

        /// <summary>
        ///     Parses the input to a patent number.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The patent number.</returns>
        public static PatentNumber Parse(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input));
            }

            // first clean
            input = input.ToUpper().Trim();

            // remove non alphanumeric characters
            var regex = new Regex("[^a-zA-Z0-9]");
            input = regex.Replace(input, string.Empty);

            // validation
            if (input.Length <= 3)
            {
                throw new ArgumentException("number is too short");
            }

            var result = new PatentNumber();
            var size = input.Length;

            // country code
            result.C = input.Substring(0, 2);

            // kind code
            result.K = char.IsLetter(input[size - 2])
                ? string.Concat(input[size - 2], input[size - 1])
                : string.Concat(input[size - 1]);

            // document number
            result.N = input.Substring(result.C.Length, size - result.C.Length - result.K.Length);

            return result;
        }

        /// <summary>
        ///     Formats the number.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns>The number formated.</returns>
        public string Format(char? separator = null)
        {
            return string.IsNullOrEmpty(K)
                ? string.Concat(C, separator, N)
                : string.Concat(C, separator, N, separator, K);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Format(' ');
        }
    }
}
