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
    using System.Threading;
    using System.Threading.Tasks;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Providers.OPS.Assemblers;
    using enovating.POT.MSW.Providers.OPS.Internals;

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
        ///     Retrieves all the family members of the document.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The family members of the document.</returns>
        public async Task<PatentFamilyMember[]> RetrieveFamily(PatentNumber number, CancellationToken cancellationToken)
        {
            var content = number.Format('.');
            var result = await _requestManager.Execute("family/publication/docdb", OPSConstants.Format.Exchange, OPSConverter.ToWPD, content, cancellationToken);

            if (!result.Success || result.Content.PatentFamily == null)
            {
                throw new InvalidOperationException($"cannot retrieve family members for {number}: ${result.Error.Code}");
            }

            var patentFamilyMemberAssembler = new PatentFamilyMemberAssembler();
            return patentFamilyMemberAssembler.Convert(result.Content.PatentFamily.FamilyMembers);
        }

        /// <summary>
        ///     Retrieves the first picture of the document.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The first picture of the document.</returns>
        public async Task<byte[]> RetrieveFirstPicture(PatentNumber number, CancellationToken cancellationToken)
        {
            var target = $"published-data/images/{number.C}/{number.N}/PA/firstpage";
            var result = await _requestManager.Execute(target, OPSConstants.Format.Picture, OPSConverter.ToByteArray, null, cancellationToken);
            return result.Success && result.Content?.Length > 0 ? result.Content : null;
        }

        /// <summary>
        ///     Retrieves the patent document corresponding to the publication number.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="cancellationToken">The cancellation notification.</param>
        /// <returns>The patent document corresponding to the publication number.</returns>
        public async Task<Patent> RetrievePatent(PatentNumber number, CancellationToken cancellationToken = default)
        {
            if (number == null)
            {
                throw new ArgumentNullException(nameof(number));
            }

            var patentAssembler = new PatentAssembler();

            var content = number.Format('.');
            var result = await _requestManager.Execute("published-data/publication/docdb/biblio", OPSConstants.Format.Exchange, OPSConverter.ToWPD, content, cancellationToken);

            if (!result.Success || result.Content.ExchangeDocuments.Length == 0)
            {
                throw new InvalidOperationException($"cannot retrieve root document for {number}: ${result.Error.Code}");
            }

            return patentAssembler.Convert(result.Content.ExchangeDocuments[0]);
        }
    }
}
