using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class CourseWind
    {
        static public CourseWind Read(byte[] buf)
        {
            var w = new CourseWind();
            Read(buf, 0, w);
            return w;
        }
        static public int Read(byte[] buf, int c, CourseWind w)
        {
            w.MessageVersionNumber = buf[c++];
            w.SelectedWindId = buf[c++];
            w.RecordCount = buf[c++];
            for (int i = 0; i < w.RecordCount; ++i)
            {
                var wr = new WindRecord();
                c = WindRecord.Read(buf, c, wr);
                w.WindRecords.Add(wr);
            }
            return c;
        }

        public byte MessageVersionNumber;
        public byte SelectedWindId;
        
        public byte RecordCount;
        public List<WindRecord> WindRecords = new List<WindRecord>();

    }
}
