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
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    using enovating.POT.MSW.Models;

    /// <summary>
    ///     Client for the European Publication Server.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class EPSClient : IDisposable
    {
        private const string _language = "en";

        private readonly HttpClient _client;

        public EPSClient()
        {
            _client = new HttpClient { BaseAddress = new Uri(EPSConstants.Server) };
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _client?.Dispose();
        }

        /// <summary>
        ///     Execute the request.
        /// </summary>
        /// <typeparam name="TContent">The type to the content.</typeparam>
        /// <param name="address">The </param>
        /// <param name="convert">The convert function.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The response from the service.</returns>
        private async Task<TContent> Execute<TContent>(string address, Func<Stream, TContent> convert, CancellationToken cancellationToken)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, address))
            {
                request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/xml"));

                using (var response = await _client.SendAsync(request, cancellationToken))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        return default;
                    }

                    using (var responseContent = await response.Content.ReadAsStreamAsync())
                    {
                        return convert(responseContent);
                    }
                }
            }
        }

        /// <summary>
        ///     Retrieves the claims of the document.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The claims of the document.</returns>
        public async Task<PatentClaim[]> RetrieveClaims(PatentNumber number, CancellationToken cancellationToken)
        {
            if (number == null)
            {
                throw new ArgumentNullException(nameof(number));
            }

            var address = $"patents/{number.C}{number.N}NW{number.K}/document.xml";
            var document = await Execute(address, EPSConverter.ToEPPatentDocument, cancellationToken);

            if (document == null || document.Claims.Length == 0)
            {
                return null;
            }

            var results = document.Claims.Where(x => x.Language == _language).SelectMany(x => x.Values);
            return results.Select(current => new PatentClaim { Number = current.Number, Text = current.Text.InnerText }).ToArray();
        }
    }
}
