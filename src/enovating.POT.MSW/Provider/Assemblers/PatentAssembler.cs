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

namespace enovating.POT.MSW.Provider.Assemblers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Provider.Models;

    /// <inheritdoc />
    internal class PatentAssembler : Assembler<Patent, ExchangeDocument>
    {
        private string ExtractAbstract(ExchangeDocument source)
        {
            var abstracts = source.Abstracts;

            if (abstracts == null || abstracts.Length == 0)
            {
                return null;
            }

            var english = abstracts.FirstOrDefault(e => e.Language == "en");
            var texts = english == null ? abstracts.FirstOrDefault()?.Text : english.Text;
            return texts != null ? string.Join("<br>", texts) : null;
        }

        private string ExtractApplicants(ExchangeDocument source)
        {
            var parties = source.Bibliographic.Parties;

            if (parties?.Applicants == null || parties.Applicants.Length <= 0)
            {
                return null;
            }

            var values = parties.Applicants.Where(e => e.Format == "epodoc").OrderBy(e => e.Sequence);
            var result = string.Join(";", values.Select(e => e.Name.Value.Replace(' ', ' ').Trim()));
            return string.IsNullOrWhiteSpace(result) ? null : result;
        }

        private string ExtractCPC(ExchangeDocument source)
        {
            var classifications = source.Bibliographic.Classifications;

            if (classifications == null || classifications.Length <= 0)
            {
                return null;
            }

            var values = classifications.Where(e => e.Scheme.Name == "CPCI").OrderBy(e => e.Sequence).ToList();

            if (values.Count <= 0)
            {
                return null;
            }

            var builder = new StringBuilder();

            foreach (var value in values)
            {
                builder.Append(value.Section);
                builder.Append(value.Class).Append(value.SubClass);
                builder.Append(value.MainGroup).Append('/').Append(value.SubGroup);
                builder.Append(';');
            }

            builder.Length -= 1;
            return builder.ToString();
        }

        private DocumentID ExtractDocumentID(IEnumerable<DocumentID> sources, string type = "docdb")
        {
            return sources?.FirstOrDefault(x => x.Type == type);
        }

        private string ExtractInventors(ExchangeDocument source)
        {
            var parties = source.Bibliographic.Parties;

            if (parties?.Inventors == null || parties.Inventors.Length <= 0)
            {
                return null;
            }

            var values = parties.Inventors.Where(e => e.Format == "epodoc").OrderBy(e => e.Sequence);
            var result = string.Join(";", values.Select(e => e.Name.Value.Replace(' ', ' ').Trim()));
            return string.IsNullOrWhiteSpace(result) ? null : result;
        }

        private string ExtractIPC(ExchangeDocument source)
        {
            var classifications = source.Bibliographic.IPC;

            if (classifications == null || classifications.Length <= 0)
            {
                return null;
            }

            var values = classifications.OrderBy(e => e.Sequence).ToList();

            var builder = new StringBuilder();
            var regex = new Regex(@"\s+");

            foreach (var value in values)
            {
                // supprime les esapces
                var code = regex.Replace(value.Text, ";").Split(';');
                // construit la structure
                builder.Append(code[0]).Append(code[1]).Append(code[2]).Append(';');
            }

            builder.Length -= 1;
            return builder.ToString();
        }

        private DateTime? ExtractReferenceDate(DocumentID[] sources)
        {
            if (sources == null || sources.Length == 0)
            {
                return null;
            }

            var target = ExtractDocumentID(sources);
            var output = OPSConverter.ToDateTime(target?.Date);

            if (output.HasValue)
            {
                return output;
            }

            target = ExtractDocumentID(sources, "epodoc");
            return OPSConverter.ToDateTime(target?.Date);
        }

        private string ExtractTitle(ExchangeDocument source)
        {
            var titles = source.Bibliographic.Titles;

            if (titles == null || titles.Length <= 0)
            {
                return null;
            }

            var english = titles.FirstOrDefault(e => e.Language == "en");
            return english == null ? titles.FirstOrDefault()?.Text : english.Text;
        }

        /// <inheritdoc />
        protected override void MergeCore(Patent target, ExchangeDocument source)
        {
            // publication
            var publication = ExtractDocumentID(source.Bibliographic.PublicationReference?.DocumentID) ?? throw new ArgumentException("missing publication reference");
            target.PublicationNumber = new PatentNumber(publication.Country, publication.Number, publication.Kind);
            target.PublicationDate = ExtractReferenceDate(source.Bibliographic.PublicationReference?.DocumentID);

            // application
            var application = ExtractDocumentID(source.Bibliographic.ApplicationReference?.DocumentID) ?? throw new ArgumentException("missing application reference");
            target.ApplicationNumber = new PatentNumber(application.Country, application.Number);
            target.ApplicationDate = ExtractReferenceDate(source.Bibliographic.PublicationReference?.DocumentID);

            // texts
            target.Abstract = ExtractAbstract(source);
            target.Title = ExtractTitle(source);

            // classifications
            target.CPC = ExtractCPC(source)?.Split(';');
            target.IPC = ExtractIPC(source)?.Split(';');

            // parties
            target.Applicants = ExtractApplicants(source)?.Split(';');
            target.Inventors = ExtractInventors(source)?.Split(';');
        }
    }
}
