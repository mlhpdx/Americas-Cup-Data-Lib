using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class ZoneSize
    {
        [XmlAttribute]
        public float MarkZoneSize { get; set; }
        [XmlAttribute]
        public float CourseZoneSize { get; set; }
    }
}