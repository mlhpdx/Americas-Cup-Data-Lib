using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmericasCup.Data.Xml
{
    public class BoatConfig
    {
        public string Modified { get; set; }
        public string Version { get; set; }
        public BoatConfigSettings Settings { get; set; }
        public BoatShape[] BoatShapes = { };
        public Boat[] Boats = { };
    }
}
