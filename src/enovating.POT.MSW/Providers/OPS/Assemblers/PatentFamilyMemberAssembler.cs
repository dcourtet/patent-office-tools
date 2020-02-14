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

namespace enovating.POT.MSW.Providers.OPS.Assemblers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using enovating.POT.MSW.Models;
    using enovating.POT.MSW.Providers.OPS.Models;

    /// <inheritdoc />
    internal class PatentFamilyMemberAssembler : Assembler<PatentFamilyMember, FamilyMember>
    {
        private DocumentID ExtractDocumentID(IEnumerable<DocumentID> sources, string type = "docdb")
        {
            return sources?.FirstOrDefault(x => x.Type == type);
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

        /// <inheritdoc />
        protected override void MergeCore(PatentFamilyMember target, FamilyMember source)
        {
            // publication
            var publication = ExtractDocumentID(source.PublicationReference?.DocumentID) ?? throw new ArgumentException("missing publication reference");
            target.PublicationNumber = new PatentNumber(publication.Country, publication.Number, publication.Kind);
            target.PublicationDate = ExtractReferenceDate(source.PublicationReference?.DocumentID);

            // application
            var application = ExtractDocumentID(source.ApplicationReference?.DocumentID) ?? throw new ArgumentException("missing application reference");
            target.ApplicationNumber = new PatentNumber(application.Country, application.Number);
            target.ApplicationDate = ExtractReferenceDate(source.PublicationReference?.DocumentID);
        }
    }
}
