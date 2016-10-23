using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class Vtx
    {
        [XmlAttribute]
        public uint Seq { get; set; }
        [XmlAttribute]
        public float X { get; set; }
        [XmlAttribute]
        public float Y { get; set; }
    }
}