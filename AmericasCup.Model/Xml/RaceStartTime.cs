using System;
using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class RaceStartTime
    {
        [XmlAttribute("Start")]
        public string Start { get; set; }
        [XmlAttribute("Postpone")]
        public string Postpone { get; set; }
    }
}