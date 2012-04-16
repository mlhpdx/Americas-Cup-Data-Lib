using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class Heartbeat
    {
        public static Heartbeat Read(byte[] buf)
        {
            var hb = new Heartbeat();
            Read(buf, 0, hb);
            return hb;
        }
        public static int Read(byte[] buf, int c, Heartbeat hb)
        {
            hb.SequenceNum = BitConverter.ToUInt32(buf, 0);
            c += 4;
            return c;
        }
        public UInt32 SequenceNum;
    }
}
