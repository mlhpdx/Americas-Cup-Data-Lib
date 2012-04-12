using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class MarkRounding
    {
        public static MarkRounding Read(byte[] buf)
        {
            var mr = new MarkRounding();
            Read(buf, 0, mr);
            return mr;
        }
        public static int Read(byte[] buf, int c, MarkRounding mr)
        {
            mr.MessageVersionNumber = buf[c++];
            mr.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            mr.AckNumber = BitConverter.ToUInt16(buf, c);
            c += 2;
            mr.RaceId = BitConverter.ToUInt32(buf, c);
            c += 4;
            mr.SourceId = BitConverter.ToUInt32(buf, c);
            c += 4;
            mr.BoatStatus = (BoatStatusEnum)buf[c++];
            mr.RoundingSide = (RoundingSideEnum)buf[c++];
            mr.MarkType = (MarkTypeEnum)buf[c++];
            mr.MarkId = buf[c++];

            return c;
        }

        public byte MessageVersionNumber;
        public DateTime Time;
        public ushort AckNumber;
        public uint RaceId;
        public uint SourceId;

        public enum BoatStatusEnum { Unknown = 0, Racing = 1, Disqualified = 2, Withdrawn = 3 }
        public BoatStatusEnum BoatStatus;

        public enum RoundingSideEnum { Unknown = 0, Port = 1, Starboard = 2 }
        public RoundingSideEnum RoundingSide;

        public enum MarkTypeEnum { Unknown = 0, RoundingMark = 1, Gate = 2 }
        public MarkTypeEnum MarkType;

        public byte MarkId;
    }
}
