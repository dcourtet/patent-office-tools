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

namespace enovating.POT.MSW.Providers.OPS.Internals
{
    using System.IO;
    using System.Xml.Serialization;

    using enovating.POT.MSW.Providers.OPS.Abstractions;

    /// <inheritdoc />
    [XmlRoot("fault", Namespace = OPSConstants.XML.OPS)]
    public class ServiceError : IOPSError
    {
        /// <inheritdoc />
        [XmlElement("code")]
        public string Code { get; set; }

        /// <inheritdoc />
        [XmlElement("message")]
        public string Message { get; set; }

        /// <summary>
        ///     Extracts the error from the XML content.
        /// </summary>
        /// <param name="content">The XML content.</param>
        /// <returns>The error from the XML content..</returns>
        public static IOPSError Parse(Stream content)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ServiceError));
                return serializer.Deserialize(content) as ServiceError;
            }
            catch
            {
                return null;
            }
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.IsNullOrEmpty(Message) ? Code : $"{Message} ({Code})";
        }
    }
}
