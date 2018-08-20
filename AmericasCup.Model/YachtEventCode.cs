using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class YachtEventCode
    {
        public static YachtEventCode Read(byte[] buf)
        {
            var ye = new YachtEventCode();
            Read(buf, 0, ye);
            return ye;
        }
        public static int Read(byte[] buf, int c, YachtEventCode ye)
        {
            ye.MessageVersionNumber = buf[c++];
            ye.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            ye.AckNumber = BitConverter.ToUInt16(buf, c);
            c += 2;
            ye.RaceId = BitConverter.ToUInt32(buf, c);
            c += 4;
            ye.DestinationBoatId = BitConverter.ToUInt32(buf, c);
            c += 4;
            ye.IncidentId = BitConverter.ToUInt32(buf, c);
            c += 4;

            ye.Event = (YachtEventEnum)buf[c++];

            return c;
        }

        public byte MessageVersionNumber;
        public DateTime Time;
        public ushort AckNumber;
        public uint RaceId;
        public uint DestinationBoatId;
        public uint IncidentId;

        public YachtEventEnum Event;
    }
}
