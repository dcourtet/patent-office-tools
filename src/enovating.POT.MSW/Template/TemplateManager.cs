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
    using System.Linq;

    using enovating.POT.MSW.Core;
    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Template.Writers;

    /// <summary>
    ///     Template manager.
    /// </summary>
    public class TemplateManager
    {
        /// <summary>
        ///     The template search pattern.
        /// </summary>
        private const string _templatePattern = "*.dotx";

        /// <summary>
        ///     The template directories.
        /// </summary>
        private readonly TemplateDirectory[] _templateDirectories;

        /// <summary>
        ///     Gets the available templates.
        /// </summary>
        public TemplateReference[] Available { get; private set; }

        public TemplateManager(TemplateDirectory[] templateDirectories)
        {
            if (templateDirectories == null)
            {
                throw new ArgumentNullException(nameof(templateDirectories));
            }

            _templateDirectories = templateDirectories.Where(x => x.Available).ToArray();

            RefreshAvailableTemplate();
        }

        /// <summary>
        ///     Merge the template with the current document.
        /// </summary>
        /// <param name="template">The template.</param>
        /// <param name="values">The values of the template.</param>
        public void Merge(TemplateReference template, IEnumerable<Patent> values)
        {
            var writingProcessor = new WritingProcessor(new IWriter<Patent>[]
            {
                new ClaimsWriter(), new FamilyWriter(), new LinkWriter(),
                new PictureWriter(), new SimpleTextWriter()
            });

            foreach (var value in values)
            {
                writingProcessor.Write(template, value);
            }
        }

        /// <summary>
        ///     Refresh the available templates.
        /// </summary>
        public void RefreshAvailableTemplate()
        {
            if (_templateDirectories.Length == 0)
            {
                throw new ArgumentException("no available template directory");
            }

            var results = new List<TemplateReference>();

            foreach (var templateDirectory in _templateDirectories)
            {
                var files = Directory.GetFiles(templateDirectory.Path, _templatePattern);
                results.AddRange(files.Select(file => new TemplateReference(templateDirectory.Name, file)));
            }

            Available = results.OrderBy(x => x.Name).ToArray();
        }
    }
}
