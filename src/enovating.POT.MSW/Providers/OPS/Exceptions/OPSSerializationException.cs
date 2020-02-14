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

namespace enovating.POT.MSW.Providers.OPS.Exceptions
{
    using System;
    using System.IO;

    /// <inheritdoc />
    public class OPSSerializationException : OPSClientException
    {
        /// <summary>
        ///     Gets the content as a string.
        /// </summary>
        public string Content { get; }

        /// <summary>
        ///     Gets the status of the content.
        /// </summary>
        public bool HasContent { get; }

        /// <inheritdoc />
        public OPSSerializationException(Stream content, Exception innerException)
            : base("content extraction failure", innerException)
        {
            if (content != null)
            {
                try
                {
                    using (var reader = new StreamReader(content))
                    {
                        Content = reader.ReadToEnd();
                    }
                }
                catch
                {
                    // ignored
                }
            }

            HasContent = !string.IsNullOrWhiteSpace(Content);
        }
    }
}