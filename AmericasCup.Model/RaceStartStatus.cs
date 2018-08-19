using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class RaceStartStatus
    {
        public static RaceStartStatus Read(byte[] rss)
        {
            var ya = new RaceStartStatus();
            Read(rss, 0, ya);
            return ya;
        }
        public static int Read(byte[] buf, int c, RaceStartStatus rss)
        {
            rss.MessageVersionNumber = buf[c++];
            rss.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            rss.AckNumber = BitConverter.ToUInt16(buf, c);
            c += 2;
            
            rss.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            
            rss.RaceId = BitConverter.ToUInt32(buf, c);
            c += 4;

            rss.NotificationType = (RaceStartStatusEnum)buf[c++];

            return c;
        }

        public byte MessageVersionNumber;
        public DateTime Time;
        public ushort AckNumber;
        public DateTime RaceStartTime;
        public uint RaceId;
        public RaceStartStatusEnum NotificationType;
    }
}
