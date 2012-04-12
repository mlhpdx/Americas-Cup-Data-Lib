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
            return new Heartbeat() { SequenceNum = BitConverter.ToUInt32(buf, 0) };
        }

        public UInt32 SequenceNum;
    }
}
