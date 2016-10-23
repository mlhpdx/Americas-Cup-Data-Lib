using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class RaceBoatType
    {
        [XmlAttribute]
        public string Type { get; set; }
    }
}