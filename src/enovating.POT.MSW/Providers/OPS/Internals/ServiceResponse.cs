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
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;

    using enovating.POT.MSW.Providers.OPS.Abstractions;

    /// <inheritdoc />
    internal class ServiceResponse<TContent> : IOPSResponse<TContent>
    {
        /// <inheritdoc />
        public int Code { get; }

        /// <inheritdoc />
        public TContent Content { get; }

        /// <inheritdoc />
        public string ContentType { get; }

        /// <inheritdoc />
        public IOPSError Error { get; }

        /// <inheritdoc />
        public bool Success { get; }

        public ServiceResponse(HttpResponseMessage response, Stream responseContent, Func<Stream, TContent> convert)
        {
            Code = (int) response.StatusCode;
            Success = response.IsSuccessStatusCode;
            ContentType = response.Content.Headers.ContentType.ToString();

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    Content = convert(responseContent);
                    break;

                case HttpStatusCode.Forbidden:
                    Error = AuthenticationError.Parse(responseContent);
                    break;

                case HttpStatusCode.BadRequest:
                    Error = AuthenticationError.Parse(responseContent) ?? ServiceError.Parse(responseContent);
                    break;

                default:
                    Error = ServiceError.Parse(responseContent);
                    break;
            }
        }
    }
}
