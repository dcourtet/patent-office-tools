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

namespace enovating.POT.MSW.Template.Writers
{
    using Microsoft.Office.Interop.Word;

    /// <summary>
    ///     Provides functionality for writting value.
    /// </summary>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface IWriter<in TValue>
    {
        /// <summary>
        ///     Identifies if the writter can handle the value.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="value">The value.</param>
        /// <returns>If <c>true</c>, the formatter can handle the value.</returns>
        bool Can(string code, TValue value);

        /// <summary>
        ///     Writes the value into the document.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="value">The value.</param>
        /// <param name="target">The target range in the document.</param>
        void Write(string code, TValue value, Range target);
    }
}
