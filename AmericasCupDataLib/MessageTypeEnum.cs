using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public enum MessageTypeEnum
    {
        Heartbeat = 1,
        RaceStatus = 12,
        DisplayTextMessage = 20,
        XmlMessage = 26,
        RaceStartStatus = 27,
        YachtEventCode = 29,
        YachtActionCode = 31,
        ChatterText = 36,
        BoatLocation = 37,
        MarkRounding = 38
    }
}
