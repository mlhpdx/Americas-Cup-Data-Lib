using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class Mark
    {
        [XmlAttribute]
        public uint SeqID { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public float TargetLat { get; set; }
        [XmlAttribute]
        public float TargetLng { get; set; }
        [XmlAttribute]
        public uint SourceId { get; set; }
    }
}