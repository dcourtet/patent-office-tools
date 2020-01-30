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
    using System;
    using System.IO;

    using enovating.POT.MSW.Core;
    using enovating.POT.MSW.Models;

    using Microsoft.Office.Core;
    using Microsoft.Office.Interop.Word;

    /// <inheritdoc />
    public class PictureWriter : IWriter<Patent>
    {
        private const string _pictureFormat = ".png";
        private const float _pictureWidth = 250f;

        /// <inheritdoc />
        public bool Can(string code, Patent value)
        {
            return code == "Picture" && value.Picture != null;
        }

        /// <summary>
        ///     Deletes the temporary picture.
        /// </summary>
        /// <param name="target">The target path.</param>
        private void DeleteTemporaryTarget(string target)
        {
            try
            {
                File.Delete(target);
            }
            catch
            {
                // ignored
            }
        }

        /// <summary>
        ///     Gets the temporary target path.
        /// </summary>
        /// <param name="number">The publication number.</param>
        /// <returns>The temporary target path.</returns>
        private string GetTemporaryTarget(PatentNumber number)
        {
            var filename = string.Concat(number.Format(), _pictureFormat).ToLower();
            return Path.Combine(ToolsContext.Current.TemporaryDirectory, filename);
        }

        /// <inheritdoc />
        public void Write(string code, Patent value, Range target)
        {
            var temporary = GetTemporaryTarget(value.PublicationNumber);
            WriteTemporaryTarget(temporary, value.Picture);

            try
            {
                var element = target.InlineShapes.AddPicture(temporary, false, true);

                element.LockAspectRatio = MsoTriState.msoCTrue;
                element.Width = _pictureWidth;
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("failed to merge picture into the document", exception);
            }

            DeleteTemporaryTarget(temporary);
        }

        /// <summary>
        ///     Writes the temporary picture.
        /// </summary>
        /// <param name="target">The target path.</param>
        /// <param name="content">The picture content.</param>
        private void WriteTemporaryTarget(string target, byte[] content)
        {
            try
            {
                File.WriteAllBytes(target, content);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException($"cannot write temporary picture to <{target}>", exception);
            }
        }
    }
}
