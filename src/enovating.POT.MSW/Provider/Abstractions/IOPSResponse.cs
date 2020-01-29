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

namespace enovating.POT.MSW.Provider.Abstractions
{
    /// <summary>
    ///     Defines a response provided by Open Patent Services (OPS).
    /// </summary>
    /// <typeparam name="TContent">The type of content of the response.</typeparam>
    public interface IOPSResponse<out TContent>
    {
        /// <summary>
        ///     Gets the status code (HTTP directive).
        /// </summary>
        int Code { get; }

        /// <summary>
        ///     Gets the content.
        /// </summary>
        TContent Content { get; }

        /// <summary>
        ///     Gets the type of the content.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        ///     Gets the error.
        /// </summary>
        IOPSError Error { get; }

        /// <summary>
        ///     Gets the state.
        /// </summary>
        bool Success { get; }
    }
}
