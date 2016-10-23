using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class Boat
    {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public uint SourceID { get; set; }
        [XmlAttribute]
        public uint ShapeID { get; set; }
        [XmlAttribute]
        public string HullNum { get; set; }
        [XmlAttribute]
        public string StoweName { get; set; }
        [XmlAttribute]
        public string ShortName { get; set; }
        [XmlAttribute]
        public string BoatName { get; set; }
        [XmlAttribute]
        public string Country;
        public BoatEquipmentPosition GPSposition { get; set; }
        public BoatEquipmentPosition FlagPosition { get; set; }
    }
}