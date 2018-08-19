using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class MessageHeader
    {
        public static int Read(byte[] buf, int c, MessageHeader msg)
        {
            if (buf[c] != 0x47 || buf[c + 1] != 0x83)
                return c;
            c += 2;

            msg.Type = (MessageTypeEnum)buf[c++];

            var ts = new byte[] { buf[c++], buf[c++], buf[c++],
                buf[c++], buf[c++], buf[c++], 0, 0 };
            var ticks = BitConverter.ToInt64(ts, 0);
            msg.TimeStamp = new DateTime(1970, 1, 1).AddMilliseconds(ticks);

            var si = new byte[] { buf[c++], buf[c++], buf[c++], buf[c++] };
            msg.SourceId = BitConverter.ToUInt32(si, 0);

            var ml = new byte[] { buf[c++], buf[c++] };
            msg.MessageLength = BitConverter.ToUInt16(ml, 0);

            return c;
        }

        public MessageTypeEnum Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public uint SourceId { get; set; }
        public ushort MessageLength { get; set; }
    }
}
