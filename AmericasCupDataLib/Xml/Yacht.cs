using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class Yacht
    {
        [XmlAttribute]
        public uint SourceID { get; set; }
        [XmlAttribute]
        public EntryEnum Entry { get; set; }
    }
}