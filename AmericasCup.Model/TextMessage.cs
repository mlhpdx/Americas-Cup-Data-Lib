using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class TextMessage
    {
        public static int Read(byte[] buf, int c, TextMessage tm)
        {
            tm.LineNumber = buf[c++];
            tm.TextLength = buf[c++];
            tm.Text = Encoding.ASCII.GetString(buf, c, tm.TextLength);
            c += tm.TextLength;
            return c;
        }

        public byte LineNumber;
        public byte TextLength;
        public string Text;
    }
}
