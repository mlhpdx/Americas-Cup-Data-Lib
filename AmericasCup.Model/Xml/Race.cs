using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AmericasCup.Data.Xml
{
    [XmlType("Race")]
    public class RaceConfig
    {
        public uint RaceID { get; set; }
        public RaceTypeEnum RaceType { get; set; }
        public string CreationTimeDate { get; set; }
        public RaceStartTime RaceStartTime { get; set; }
        public Yacht[] Participants { get; set; }
        public CompoundMark[] Course { get; set; }
        public Corner[] CompoundMarkSequence { get; set; }
        public Limit[] CourseLimit { get; set; }
    }
}
