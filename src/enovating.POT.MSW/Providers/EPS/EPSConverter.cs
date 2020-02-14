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

namespace enovating.POT.MSW.Providers.EPS
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    using enovating.POT.MSW.Providers.EPS.Models;
    using enovating.POT.MSW.Providers.OPS.Exceptions;

    /// <summary>
    ///     Converters for the European Publication Server.
    /// </summary>
    internal static class EPSConverter
    {
        /// <summary>
        ///     Converts the XML input to a WPD structure.
        /// </summary>
        /// <param name="input">The XML input.</param>
        /// <returns>The WPD structure.</returns>
        public static EPPatentDocument ToEPPatentDocument(Stream input)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(EPPatentDocument));
                return serializer.Deserialize(input) as EPPatentDocument;
            }
            catch (Exception exception)
            {
                throw new OPSSerializationException(input, exception);
            }
        }
    }
}
