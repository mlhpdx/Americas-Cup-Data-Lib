using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class AverageWind
    {
        static public AverageWind Read(byte[] buf)
        {
            var w = new AverageWind();
            Read(buf, 0, w);
            return w;
        }

        static public int Read(byte[] buf, int c, AverageWind w)
        {
            w.MessageVersionNumber = buf[c++];
            w.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));

            w.RawPeriod = TimeSpan.FromSeconds(BitConverter.ToUInt16(buf, c) / 10.0f); // 1/10ths of seconds to TimeSpan 
            c += 2;
            w.RawSpeed = BitConverter.ToUInt16(buf, c) / 1000.0f; // mm/s -> m/s
            c += 2;

            w.Period2 = TimeSpan.FromSeconds(BitConverter.ToUInt16(buf, c) / 10.0f); // 1/10ths of seconds to TimeSpan 
            c += 2;
            w.Speed2 = BitConverter.ToUInt16(buf, c) / 1000.0f; // mm/s -> m/s
            c += 2;

            w.Period3 = TimeSpan.FromSeconds(BitConverter.ToUInt16(buf, c) / 10.0f); // 1/10ths of seconds to TimeSpan 
            c += 2;
            w.Speed3 = BitConverter.ToUInt16(buf, c) / 1000.0f; // mm/s -> m/s
            c += 2;

            w.Period4 = TimeSpan.FromSeconds(BitConverter.ToUInt16(buf, c) / 10.0f); // 1/10ths of seconds to TimeSpan 
            c += 2;
            w.Speed4 = BitConverter.ToUInt16(buf, c) / 1000.0f; // mm/s -> m/s
            c += 2;

            return c;
        }

        public byte MessageVersionNumber;
        public DateTime Time;

        public TimeSpan RawPeriod;
        public float RawSpeed;

        public TimeSpan Period2;
        public float Speed2;

        public TimeSpan Period3;
        public float Speed3;

        public TimeSpan Period4;
        public float Speed4;
    }
}

