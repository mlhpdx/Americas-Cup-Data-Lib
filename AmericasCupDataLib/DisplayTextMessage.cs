using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class DisplayTextMessage
    {
        public static DisplayTextMessage Read(byte[] buf)
        {
            var dtm = new DisplayTextMessage();
            Read(buf, 0, dtm);
            return dtm;
        }

        public static int Read(byte[] buf, int c, DisplayTextMessage dtm)
        {
            dtm.MessageVersionNumber = buf[c];
            dtm.AckNumber = BitConverter.ToUInt16(buf, c + 1);
            dtm.LinesOfText = buf[c + 3];

            c += 4;
            for (byte i = 0; i < dtm.LinesOfText; ++i)
            {
                var tm = new TextMessage();
                c = TextMessage.Read(buf, c, tm);
                dtm.TextMessages.Add(tm);
            }

            return c;
        }

        public byte MessageVersionNumber;
        public ushort AckNumber;
        public byte LinesOfText;

        public List<TextMessage> TextMessages = new List<TextMessage>();
    }
}
