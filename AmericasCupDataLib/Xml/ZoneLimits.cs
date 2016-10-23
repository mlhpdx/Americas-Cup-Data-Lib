using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class ZoneLimits
    {
        [XmlAttribute]
        public float Limit1 { get; set; }
        [XmlAttribute]
        public float Limit2 { get; set; }
        [XmlAttribute]
        public float Limit3 { get; set; }
        [XmlAttribute]
        public float Limit4 { get; set; }
        [XmlAttribute]
        public float Limit5 { get; set; }
    }
}