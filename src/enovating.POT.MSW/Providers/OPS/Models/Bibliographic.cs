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

namespace enovating.POT.MSW.Providers.OPS.Models
{
    using System.Xml.Serialization;

    public class Bibliographic
    {
        [XmlElement("application-reference")]
        public ApplicationReference ApplicationReference { get; set; }

        [XmlArray("patent-classifications")]
        [XmlArrayItem("patent-classification")]
        public PatentClassification[] Classifications { get; set; }

        [XmlArray("classifications-ipcr")]
        [XmlArrayItem("classification-ipcr")]
        public InternationalPatentClassificationR[] IPC { get; set; }

        [XmlElement("parties")]
        public Parties Parties { get; set; }

        [XmlArray("priority-claims")]
        [XmlArrayItem("priority-claim")]
        public PriorityClaim[] PriorityClaims { get; set; }

        [XmlElement("invention-title")]
        public InventionTitle[] Titles { get; set; }

        [XmlElement("publication-reference")]
        public PublicationReference PublicationReference { get; set; }
    }
}
