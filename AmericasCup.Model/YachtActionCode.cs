using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class YachtActionCode
    {
        public static YachtActionCode Read(byte[] buf)
        {
            var ya = new YachtActionCode();
            Read(buf, 0, ya);
            return ya;
        }
        public static int Read(byte[] buf, int c, YachtActionCode ya)
        {
            ya.MessageVersionNumber = buf[c++];
            ya.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            ya.AckNumber = BitConverter.ToUInt16(buf, c);
            c += 2;
            ya.OriginatorBoatId = BitConverter.ToUInt32(buf, c);
            c += 4;
            ya.IncidentId = BitConverter.ToUInt32(buf, c);
            c += 4;

         ya.Event = (YachtActionEnum)buf[c++];

            return c;
        }

        public byte MessageVersionNumber;
        public DateTime Time;
        public ushort AckNumber;
        public uint OriginatorBoatId;
        public uint IncidentId;

        public YachtActionEnum Event;
    }
}
