using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmericasCup.Data
{
    public class BoatLocation
    {
        public static BoatLocation Read(byte[] buf)
        {
            var bl = new BoatLocation();
            Read(buf, 0, bl);
            return bl;
        }
        public static int Read(byte[] buf, int c, BoatLocation loc)
        {
            loc.MessageVersionNumber = buf[c++];

            var t = new byte[] { buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], buf[c++], 0, 0 };
            loc.Time = new DateTime(1970, 1, 1).AddMilliseconds(BitConverter.ToUInt64(t, 0));

            loc.BoatId = BitConverter.ToUInt32(buf, c);
            c += 4;

            loc.SequenceNumber = BitConverter.ToUInt32(buf, c);
            c += 4;

            loc.DeviceType = (DeviceTypeEnum)buf[c++];
            loc.Latitude = BitConverter.ToInt32(buf, c) * 180.0 / 2147483648.0;
            c += 4;
            loc.Longitude = BitConverter.ToInt32(buf, c) * 180.0 / 2147483648.0;
            c += 4;
            loc.Altitude = BitConverter.ToInt32(buf, c) * 180.0 / 2147483648.0;
            c += 4;

            loc.Heading = BitConverter.ToInt16(buf, c) * 360.0f / 65536.0f;
            c += 2;
            loc.Pitch = BitConverter.ToInt16(buf, c) * 360.0f / 65536.0f;
            c += 2;
            loc.Roll = BitConverter.ToInt16(buf, c) * 360.0f / 65536.0f;
            c += 2;

            loc.BoatSpeed = BitConverter.ToUInt16(buf, c) / 1000.0f;
            c += 2;

            loc.COG = BitConverter.ToInt16(buf, c) * 360.0f / 65536.0f;
            c += 2;

            loc.SOG = BitConverter.ToUInt16(buf, c) / 1000.0f;
            c += 2;

            loc.ApparentWindSpeed = BitConverter.ToUInt16(buf, c) / 1000.0f;
            c += 2;

            loc.ApparentWindAngle = BitConverter.ToInt16(buf, c) * 180.0f / 32768.0f;
            c += 2;

            loc.TrueWindSpeed = BitConverter.ToUInt16(buf, c) / 1000.0f;
            c += 2;

            loc.TrueWindDirection = BitConverter.ToInt16(buf, c) * 360.0f / 65536.0f;
            c += 2;

            loc.TrueWindAngle = BitConverter.ToInt16(buf, c) * 180.0f / 32768.0f;
            c += 2;

            loc.CurrentDrift = BitConverter.ToUInt16(buf, c) / 1000.0f;
            c += 2;

            loc.CurrentSet = BitConverter.ToInt16(buf, c) * 360.0f / 65536.0f;
            c += 2;

            loc.RudderAngle = BitConverter.ToInt16(buf, c) * 180.0f / 32768.0f;
            c += 2;

            return c;
        }

        public byte MessageVersionNumber;
        public DateTime Time;
        public uint BoatId; // boat id
        public uint SequenceNumber; // msg serial number originates at boat

        public DeviceTypeEnum DeviceType;

        public double Latitude; // -180 = 2^31, 180 = 2^31
        public double Longitude;
        public double Altitude; // cm above MSL

        public float Heading; // 0x0000 = North, 0x4000 = East, 0x8000 = South
        public float Pitch; // -180 = 2^15, 180 = 2^15, bow down = positive
        public float Roll; // port down = positive

        public float BoatSpeed; // m/sec
        public float COG; // Course over ground, see heading
        public float SOG; // Speed over ground, mm/sec

        public float ApparentWindSpeed; // mm/sec
        public float ApparentWindAngle; // wind over Starboard = positive
        public float TrueWindSpeed; // mm/sec
        public float TrueWindDirection;
        public float TrueWindAngle;

        public float CurrentDrift; // mm/sec
        public float CurrentSet; // heading?
        public float RudderAngle; // positive rudder is set to turn yacht to port
    }
}
