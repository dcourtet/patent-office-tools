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

namespace enovating.POT.MSW.Providers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Providers.OPS;

    /// <summary>
    ///     Patent provider from multiple sources.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class PatentProvider : IDisposable
    {
        private readonly OPSClient _opsClient;

        public PatentProvider(string opsConsumerKey)
        {
            _opsClient = new OPSClient(opsConsumerKey);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _opsClient?.Dispose();
        }

        /// <summary>
        ///     Retrieves the patent document corresponding to the publication number.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The patent document corresponding to the publication number.</returns>
        public async Task<Patent> Retrieve(PatentNumber number, CancellationToken cancellationToken = default)
        {
            var patent = await _opsClient.RetrievePatent(number, cancellationToken);

            patent.Family = await _opsClient.RetrieveFamily(number, cancellationToken);
            patent.Picture = await _opsClient.RetrieveFirstPicture(number, cancellationToken);

            return patent;
        }
    }
}
