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

namespace enovating.POT.MSW.Provider.Internals
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Represents an Open Patent Services (OPS) access token.
    /// </summary>
    [DataContract]
    internal sealed class OAuthToken
    {
        /// <summary>
        ///     Gets the expiration time in seconds.
        /// </summary>
        [DataMember(Name = "expires_in")]
        public int ExpirationDelay { get; private set; }

        /// <summary>
        ///     Gets the issue date in Unix Epoch format (milliseconds).
        /// </summary>
        [DataMember(Name = "issued_at")]
        public long Issue { get; private set; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        [DataMember(Name = "access_token")]
        public string Value { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        ///     Validates the token.
        /// </summary>
        /// <returns>If <c>true</c>, the token is valid.</returns>
        public bool Validate()
        {
            if (string.IsNullOrEmpty(Value))
            {
                return false;
            }

            var expiration = (ExpirationDelay - 30) * 1000 + Issue;
            var reference = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            return expiration > reference;
        }
    }
}
