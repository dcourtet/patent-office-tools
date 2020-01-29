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

namespace enovating.POT.MSW.Provider
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Provider.Assemblers;
    using enovating.POT.MSW.Provider.Internals;

    /// <summary>
    ///     Client for Open Patent Services.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class OPSClient : IDisposable
    {
        private readonly RequestManager _requestManager;

        /// <summary>
        ///     Gets the current version.
        /// </summary>
        public string Version => OPSConstants.Version;

        /// <inheritdoc />
        public OPSClient(string keys)
        {
            _requestManager = new RequestManager(keys);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _requestManager?.Dispose();
        }

        /// <summary>
        ///     Retrieves the patent document corresponding to the publication number.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The patent document corresponding to the publication number.</returns>
        public async Task<Patent> Retrieve(PatentNumber number, CancellationToken cancellationToken = default)
        {
            if (number == null)
            {
                throw new ArgumentNullException(nameof(number));
            }

            var patentAssembler = new PatentAssembler();

            var result = await _requestManager.Execute("published-data/publication/docdb/biblio", "application/xml", OPSConverter.ToWPD, number.ToString(), cancellationToken);

            if (!result.Success && result.Content.ExchangeDocuments.Length != 0)
            {
                throw new InvalidOperationException($"cannot retrieve root document for {number}: ${result.Error.Code}");
            }

            return patentAssembler.Convert(result.Content.ExchangeDocuments[0]);
        }
    }
}
