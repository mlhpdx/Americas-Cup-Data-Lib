using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class WindRecord
    {
        static public WindRecord Read(byte[] buf)
        {
            var w = new WindRecord();
            Read(buf, 0, w);
            return w;
        }

        static public int Read(byte[] buf, int c, WindRecord w)
        {
            w.WindId = buf[c++];
            w.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));
            w.RaceId = BitConverter.ToUInt32(buf, c);
            c += 4;

            w.WindDirection = BitConverter.ToInt16(buf, c) * 180.0f / 32768.0f;
            c += 2;
            w.WindSpeed = BitConverter.ToUInt16(buf, c) / 1000.0f;
            c += 2;
            w.BestUpwindAngle = BitConverter.ToInt16(buf, c) * 180.0f / 32768.0f;
            c += 2;
            w.BestDownwindAngle = BitConverter.ToInt16(buf, c) * 180.0f / 32768.0f;
            c += 2;

            w.Flags = (WindRecordFlags)buf[c++];

            return c;
        }

        public byte WindId;
        public DateTime Time;
        public uint RaceId;
        public float WindDirection;
        public float WindSpeed;
        public float BestUpwindAngle;
        public float BestDownwindAngle;
        public WindRecordFlags Flags;
    }
}
