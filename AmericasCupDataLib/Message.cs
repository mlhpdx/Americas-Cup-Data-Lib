using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class Message
    {
        public static int Read(byte[] buf, int c, Message msg)
        {
            msg.Content = new byte[msg.Header.MessageLength];

            for (int i = 0; i < msg.Header.MessageLength; ++i, c++)
                msg.Content[i] = buf[c];

            return c;
        }

        public MessageHeader Header = new MessageHeader();
        public byte[] Content { get; set; }
        public uint Crc { get; set; }
    }
}
