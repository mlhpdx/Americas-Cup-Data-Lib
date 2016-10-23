using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class Limit
    {
        [XmlAttribute]
        public uint SeqID { get; set; }
        [XmlAttribute]
        public float Lat { get; set; }
        [XmlAttribute]
        public float Lon { get; set; }
    }
}