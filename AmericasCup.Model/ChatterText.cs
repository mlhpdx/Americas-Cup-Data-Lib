using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class ChatterText
    {
        public static ChatterText Read(byte[] buf)
        {
            var ct = new ChatterText();
            Read(buf, 0, ct);
            return ct;
        }
        public static int Read(byte[] buf, int c, ChatterText ct)
        {
            ct.MessageVersionNumber = buf[c++];
            ct.Source = (ChatterSourceEnum)buf[c++];
            ct.Length = buf[c++];
            ct.Text = Encoding.ASCII.GetString(buf, c, ct.Length);
            c += ct.Length;
            return c;
        }

        public byte MessageVersionNumber;
        public ChatterSourceEnum Source;
        public byte Length;
        public string Text;
    }
}
