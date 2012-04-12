using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class BoatStatus
    {
        static public int Read(byte[] buf, int c, BoatStatus b)
        {
            b.BoatId = BitConverter.ToUInt32(buf, c);
            c += 4;

            b.Status = (BoatStatusEnum)buf[c++];
            b.LegNumber = buf[c++];
            b.PenaltiesAwarded = buf[c++];
            b.PenaltiesServed = buf[c++];

            b.ExpectedTimeAtNextMark = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));

            b.EstimatedTimeAtFinish = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            
            return c;
        }

        public uint BoatId;

        public BoatStatusEnum Status;

        public byte LegNumber; // 0 = prestart
        public byte PenaltiesAwarded;
        public byte PenaltiesServed;

        public DateTime ExpectedTimeAtNextMark;
        public DateTime EstimatedTimeAtFinish;
    }
}
