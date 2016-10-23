using System;

namespace AmericasCup.Data.Xml
{
    public class RegattaConfig
    {
        public uint RegattaID { get; set; }
        public string RegattaName { get; set; }
        public string CourseName { get; set; }
        public float CentralLatitude { get; set; }
        public float CentralLongitude { get; set; }
        public float CentralAltitude { get; set; }
        public float UtcOffset { get; set; } // hours -> Timespan
        public float MagneticVariation { get; set; }
        public string ShorelineName { get; set; }
    }
}
