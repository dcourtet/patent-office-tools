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

    public class PatentClassification
    {
        [XmlElement("classification-scheme")]
        public PatentClassificationScheme Scheme { get; set; }

        [XmlElement("section")]
        public string Section { get; set; }

        [XmlElement("class")]
        public string Class { get; set; }

        [XmlElement("main-group")]
        public string MainGroup { get; set; }

        [XmlElement("subgroup")]
        public string SubGroup { get; set; }

        [XmlElement("classification-value")]
        public string ClassificationValue { get; set; }
        
        [XmlAttribute("sequence")]
        public int Sequence { get; set; }

        [XmlElement("subclass")]
        public string SubClass { get; set; }
        
        [XmlElement("classification-symbol")]
        public string Symbol { get; set; }
    }
}
