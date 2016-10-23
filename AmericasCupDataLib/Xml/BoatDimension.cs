using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class BoatDimension
    {
        [XmlAttribute]
        public float BoatLength { get; set; }
        [XmlAttribute]
        public float HullLength { get; set; }
    }
}