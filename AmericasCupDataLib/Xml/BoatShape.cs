using System.Collections.Generic;
using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    public class BoatShape
    {
        [XmlAttribute]
        public uint ShapeID { get; set; }
        public Vtx[] Vertices { get; set; }
        public Vtx[] Catamaran { get; set; }
        public Vtx[] Bowsprit { get; set; }
        public Vtx[] Trampoline { get; set; }
    }
}