using System.Collections.Generic;
using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class CompoundMark 
    {
        [XmlAttribute]
        public uint CompoundMarkID { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlElement("Mark")]
        public Mark[] Marks;
    }
}