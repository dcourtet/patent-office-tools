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
    /// <summary>
    ///     Constants for the European Publication Server (EPS) client.
    /// </summary>
    internal static class EPSConstants
    {
        /// <summary>
        ///     The server URL.
        /// </summary>
        public const string Server = "https://data.epo.org/publication-server/rest/v1.2/";

        /// <summary>
        ///     The compatible version of the service.
        /// </summary>
        public const string Version = "1.2";
    }
}
