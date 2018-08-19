using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class RaceStatus
    {
        public static RaceStatus Read(byte[] buf)
        {
            var rs = new RaceStatus();
            Read(buf, 0, rs);
            return rs;
        }
        public static int Read(byte[] buf, int c, RaceStatus stat)
        {
            stat.MessageVersionNumber = buf[c++];

            var t = new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 };
            stat.CurrentTime = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(t, 0));

            stat.RaceId = BitConverter.ToUInt32(buf, c);
            c += 4;

            stat.Status = (RaceStatusEnum)buf[c++];

            stat.ExpectedStartTime = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));

            stat.RaceCourseWindDirection = BitConverter.ToInt16(buf, c) * 360.0 / 65536.0;
            c += 2;

            stat.RaceCourseWindSpeed = BitConverter.ToUInt16(buf, c) / 1000.0;
            c += 2;

            stat.NumberOfBoatsInRace = buf[c++];
            stat.RaceType = (RaceTypeEnum)buf[c++];

            for (int i = 0; i < stat.NumberOfBoatsInRace; ++i)
            {
                var b = new BoatStatus();
                c = BoatStatus.Read(buf, c, b);
                stat.BoatStatuses.Add(b);
            }

            return c;
        }

        public MessageHeader Header;

        public byte MessageVersionNumber;
        public DateTime CurrentTime;
        public uint RaceId;

        public RaceStatusEnum Status;

        public DateTime ExpectedStartTime;
        public double RaceCourseWindDirection;
        public double RaceCourseWindSpeed;
        public byte NumberOfBoatsInRace;

        public RaceTypeEnum RaceType;

        public List<BoatStatus> BoatStatuses = new List<BoatStatus>();
    }
}
