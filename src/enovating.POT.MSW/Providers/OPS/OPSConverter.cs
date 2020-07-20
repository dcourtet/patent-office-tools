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

namespace enovating.POT.MSW.Providers.OPS
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    using enovating.POT.MSW.Providers.OPS.Exceptions;
    using enovating.POT.MSW.Providers.OPS.Models;

    /// <summary>
    ///     Converters for Open Patent Services.
    /// </summary>
    internal static class OPSConverter
    {
        /// <summary>
        ///     Encodes entry into <c>base64</c>.
        /// </summary>
        /// <param name="input">The entry.</param>
        /// <returns>The encoded entry.</returns>
        public static string ToBase64(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var bytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        ///     Converts the input to a byte array.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>The byte array.</returns>
        public static byte[] ToByteArray(Stream input)
        {
            if (input == null)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                input.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        /// <summary>
        ///     Converts the input.
        /// </summary>
        /// <param name="input">The string input.</param>
        /// <returns>The output.</returns>
        public static DateTime? ToDateTime(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            if (DateTime.TryParseExact(input, "yyyyMMdd", null, DateTimeStyles.AssumeUniversal, out var result))
            {
                // success
                return result;
            }

            // failure
            return null;
        }

        /// <summary>
        ///     Converts the TIFF input to a PNG picture.
        /// </summary>
        /// <param name="input">The TIFF input.</param>
        /// <returns>The PNG picture.</returns>
        public static byte[] ToPNG(byte[] input)
        {
            using (var inputStream = new MemoryStream(input))
            using (var outputStream = new MemoryStream())
            using (var bitmap = new Bitmap(inputStream))
            {
                bitmap.Save(outputStream, ImageFormat.Png);
                return outputStream.ToArray();
            }
        }

        /// <summary>
        ///     Converts the XML input to a WPD structure.
        /// </summary>
        /// <param name="input">The XML input.</param>
        /// <returns>The WPD structure.</returns>
        public static WPD ToWPD(Stream input)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WPD));
                return serializer.Deserialize(input) as WPD;
            }
            catch (Exception exception)
            {
                throw new OPSSerializationException(input, exception);
            }
        }
    }
}
