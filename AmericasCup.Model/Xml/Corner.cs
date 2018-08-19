using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class Corner
    {
        [XmlAttribute]
        public uint SeqID { get; set; }
        [XmlAttribute]
        public uint CompoundMarkID { get; set; }
        [XmlAttribute]
        public RoundingEnum Rounding { get; set; }
        [XmlAttribute]
        public uint ZoneSize { get; set; } // boatlengths
    }
}