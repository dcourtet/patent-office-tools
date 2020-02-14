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
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using enovating.POT.MSW.Providers.OPS.Abstractions;
    using enovating.POT.MSW.Providers.OPS.Exceptions;

    /// <summary>
    ///     Client request manager.
    /// </summary>
    /// <seealso cref="IDisposable" />
    internal class RequestManager : IDisposable
    {
        private readonly HttpClient _client;
        private readonly string _consumer;

        private OAuthToken _cacheToken;

        /// <inheritdoc />
        public RequestManager(string keys)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _client = new HttpClient { BaseAddress = new Uri(OPSConstants.Server) };
            _consumer = OPSConverter.ToBase64(keys);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _client?.Dispose();
        }

        /// <summary>
        ///     Executes the request.
        /// </summary>
        /// <typeparam name="TContent">The type of the result content.</typeparam>
        /// <param name="target">The target URL.</param>
        /// <param name="format">The accepted format.</param>
        /// <param name="convert">The convert function.</param>
        /// <param name="content">The request payload.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The response from the service.</returns>
        public async Task<IOPSResponse<TContent>> Execute<TContent>(string target, string format, Func<Stream, TContent> convert, string content = null, CancellationToken cancellationToken = default)
        {
            await Task.Delay(OPSConstants.Throttling, cancellationToken);

            var address = string.Concat("rest-services/", target);
            var method = content == null ? HttpMethod.Get : HttpMethod.Post;

            using (var request = new HttpRequestMessage(method, address))
            {
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(format));

                var token = await GetToken(cancellationToken);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token?.Value);

                if (content != null)
                {
                    request.Content = new StringContent(content, Encoding.UTF8, "text/plain");
                }

                using (var response = await _client.SendAsync(request, cancellationToken))
                {
                    using (var responseContent = await response.Content.ReadAsStreamAsync())
                    {
                        return new ServiceResponse<TContent>(response, responseContent, convert);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets a valid access token.
        /// </summary>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>A valid access token.</returns>
        private async Task<OAuthToken> GetToken(CancellationToken cancellationToken)
        {
            if (_cacheToken != null && _cacheToken.Validate())
            {
                return _cacheToken;
            }

            using (var request = new HttpRequestMessage(HttpMethod.Post, "auth/accesstoken"))
            {
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", _consumer);
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string> { { "grant_type", "client_credentials" } });

                using (var response = await _client.SendAsync(request, cancellationToken))
                using (var responseContent = await response.Content.ReadAsStreamAsync())
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var error = AuthenticationError.Parse(responseContent);
                        throw new OPSAuthenticationException(error);
                    }

                    try
                    {
                        var serializer = new DataContractJsonSerializer(typeof(OAuthToken));
                        return _cacheToken = serializer.ReadObject(responseContent) as OAuthToken;
                    }
                    catch (Exception exception)
                    {
                        throw new OPSSerializationException(responseContent, exception);
                    }
                }
            }
        }
    }
}
