using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class XmlMessage
    {
        public static XmlMessage Read(byte[] xm)
        {
            var mr = new XmlMessage();
            Read(xm, 0, mr);
            return mr;
        }
        public static int Read(byte[] buf, int c, XmlMessage xm)
        {
            xm.MessageVersionNumber = buf[c++];
            xm.AckNumber = BitConverter.ToUInt16(buf, c);
            c += 2;

            xm.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(
                new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 }, 0));

            xm.SubType = (XmlMessageSubTypeEnum)buf[c++];
            xm.SequenceNumber = BitConverter.ToUInt16(buf, c);
            c += 2;
            xm.Length = BitConverter.ToUInt16(buf, c);
            c += 2;

            xm.Text = Encoding.ASCII.GetString(buf, c, xm.Length).Trim('\0'); // null terminated, sometimes?
            c += xm.Length;

            return c;
        }

        public byte MessageVersionNumber;
        public ushort AckNumber;
        public DateTime Time;
        public XmlMessageSubTypeEnum SubType;
        public ushort SequenceNumber;
        public ushort Length;

        public string Text;
    }
}
