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

namespace enovating.POT.MSW.Template
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Template.Writers;

    using Microsoft.Office.Interop.Word;

    /// <summary>
    ///     Writing processor.
    /// </summary>
    public class WritingProcessor
    {
        /// <summary>
        ///     The prefix of the template fields.
        /// </summary>
        private const string _codePrefix = "POT_";

        private readonly Application _target;
        private readonly IEnumerable<IWriter<Patent>> _writers;

        public WritingProcessor(IEnumerable<IWriter<Patent>> writers)
        {
            _target = Globals.ThisAddIn.Application;
            _writers = writers ?? throw new ArgumentNullException(nameof(writers));
        }

        /// <summary>
        ///     Inserts the contents of the template into the current document.
        /// </summary>
        /// <param name="template">The template path.</param>
        private void InsertTemplate(string template)
        {
            if (!File.Exists(template))
            {
                throw new ArgumentException("template not available", nameof(template));
            }

            _target.Selection.InsertFile(template);
        }

        /// <summary>
        ///     Try to extract the code associated with the field.
        /// </summary>
        /// <param name="target">The target field.</param>
        /// <param name="code">The code.</param>
        /// <returns>The result of the operation.</returns>
        private bool TryExtractCode(Field target, out string code)
        {
            code = null;

            if (target == null || string.IsNullOrEmpty(target.Code.Text))
            {
                return false;
            }

            var temporary = target.Code.Text.Trim();

            if (!temporary.StartsWith(_codePrefix))
            {
                return false;
            }

            code = temporary.Substring(_codePrefix.Length);
            return true;
        }

        /// <summary>
        ///     Writes the value in the document using the specified template.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="value">The value.</param>
        public void Write(TemplateReference template, Patent value)
        {
            if (template == null)
            {
                throw new ArgumentNullException(nameof(template));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _target.UndoRecord.StartCustomRecord($"POT {value.PublicationNumber}");

            try
            {
                InsertTemplate(template.Path);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("template insertion failure", exception);
            }

            foreach (Field current in _target.ActiveDocument.Fields)
            {
                if (!TryExtractCode(current, out var code))
                {
                    continue;
                }

                try
                {
                    WriteValue(code, value, current.Result);
                }
                catch
                {
                    // todo: logging
                }
                finally
                {
                    current.Delete();
                }
            }

            _target.UndoRecord.EndCustomRecord();
        }

        /// <summary>
        ///     Writes the value in the target field using the correct writter.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="value">The value.</param>
        /// <param name="target">The target field in the document.</param>
        private void WriteValue(string code, Patent value, Range target)
        {
            foreach (var writer in _writers)
            {
                if (!writer.Can(code, value))
                {
                    continue;
                }

                try
                {
                    writer.Write(code, value, target);
                }
                catch (Exception exception)
                {
                    var message = $"writer '{writer.GetType().FullName}' failure for '{_codePrefix}{code}'";
                    throw new InvalidOperationException(message, exception);
                }
            }
        }
    }
}
