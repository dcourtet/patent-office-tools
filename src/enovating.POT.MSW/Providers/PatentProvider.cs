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
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Providers.EPS;
    using enovating.POT.MSW.Providers.OPS;

    /// <summary>
    ///     Patent provider from multiple sources.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class PatentProvider : IDisposable
    {
        private readonly EPSClient _epsClient;
        private readonly OPSClient _opsClient;
        private readonly string _temporaryDirectory;

        public PatentProvider(string opsConsumerKey, string temporaryDirectory)
        {
            _epsClient = new EPSClient();
            _opsClient = new OPSClient(opsConsumerKey);
            _temporaryDirectory = temporaryDirectory;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _epsClient?.Dispose();
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
            try
            {
                var patent = await _opsClient.RetrievePatent(number, cancellationToken);

                patent.Family = await _opsClient.RetrieveFamily(number, cancellationToken);
                patent.Picture = await _opsClient.RetrieveFirstPicture(number, cancellationToken);

                if (number.C == "EP" && number.K.StartsWith("B"))
                {
                    patent.Claims = await _epsClient.RetrieveClaims(number, cancellationToken);
                }

                return patent;
            }
            catch (Exception exception)
            {
                WriteError(number, exception);
                throw;
            }
        }

        /// <summary>
        ///     Write the error to a text file.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <param name="exception">The exception.</param>
        private void WriteError(PatentNumber number, Exception exception)
        {
            try
            {
                var content = new StringBuilder();
                var filename = Path.Combine(_temporaryDirectory, $"{number.Format()}.txt");

                content.AppendFormat("[{0}] {1}{2}", DateTime.Now, exception.Message, Environment.NewLine);
                content.Append(exception.StackTrace).Append(Environment.NewLine).Append(Environment.NewLine);

                File.AppendAllText(filename, content.ToString());
            }
            catch
            {
                // ignored
            }
        }
    }
}
