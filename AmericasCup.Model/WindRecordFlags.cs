using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    [Flags]
    public enum WindRecordFlags
    {
        Direction = 0x01,
        Speed = 0x04,
        BestUpwindAngle = 0x10,
        BestDownwindAngle = 0x40
    }
}
