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
    /// <summary>
    ///     Constants for the Open Patent Services (OPS) client.
    /// </summary>
    internal static class OPSConstants
    {
        /// <summary>
        ///     The server URL.
        /// </summary>
        public const string Server = "https://ops.epo.org/3.2/";

        /// <summary>
        ///     The waiting time between requests.
        /// </summary>
        public const int Throttling = 750;

        /// <summary>
        ///     The compatible version of the service.
        /// </summary>
        public const string Version = "3.2";

        /// <summary>
        ///     XML namespaces.
        /// </summary>
        public static class XML
        {
            /// <summary>
            ///     Namespace <c>Exchange</c>.
            /// </summary>
            public const string Exchange = "http://www.epo.org/exchange";

            /// <summary>
            ///     Namespace <c>OPS</c>.
            /// </summary>
            public const string OPS = "http://ops.epo.org";
        }
    }
}
