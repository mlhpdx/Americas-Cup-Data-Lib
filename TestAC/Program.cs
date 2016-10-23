using AmericasCup.Feed;
using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestAC
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Client();
            var e = new FeedEvents();

            e.OnRegattaConfig += regatta => {
                Console.WriteLine("Welcome to the regatta {0}", regatta.RegattaName);
            };
            e.OnBoatConfig += boats => {
                Console.Write("The configuration for {0} boats arrived.", boats.Boats.Count());
            };
            e.OnRaceConfig += race => {
                Console.Write("Race of type {0} starts at {1} with participants {2}", race.RaceType, race.RaceStartTime.Start, string.Join(", ", race.Participants.Select(p => p.SourceID)));
            };

            e.OnHeartbeat += h => Console.WriteLine(string.Format("Heartbeat {0}", h.SequenceNum));
            e.OnRaceStatus += rs => Console.WriteLine(string.Format("{0} race {1} is {2} with {3} boats.", rs.RaceType, rs.RaceId, rs.Status, rs.NumberOfBoatsInRace));
            e.OnDisplayTextMessage += tm =>
            {
                Console.WriteLine(string.Format("Display {0} text messages:", tm.LinesOfText));
                tm.TextMessages.ForEach(m => Console.WriteLine(string.Format("  {0}", m.Text)));
            };
            e.OnChatterText += ch => Console.WriteLine(string.Format("{0}: {1}", ch.Source, ch.Text));
            e.OnBoatLocation += bl =>
            {
                if (bl.DeviceType == AmericasCup.Data.DeviceTypeEnum.RacingYacht && bl.BoatId == 104)
                    Console.WriteLine(string.Format("{0} {1} is rolled {2:0.0} and going {3:0.00} m/s", bl.DeviceType, bl.BoatId, bl.Roll, bl.BoatSpeed));
            };
            e.OnMarkRounding += mr => Console.WriteLine(string.Format("Boat {0} just rounded {1} {2}.", mr.SourceId, mr.MarkType, mr.MarkId));
            e.OnYachtEventCode += ye => Console.WriteLine(string.Format("Boat {0} event {1}", ye.DestinationBoatId, ye.Event));
            e.OnYachtActionCode += ya => Console.WriteLine(string.Format("Boat {0} action {1}", ya.OriginatorBoatId, ya.Event));
            e.OnCourseWind += w =>
            {
                foreach (var r in w.WindRecords)
                {
                    var sb = new StringBuilder(string.Format("Wind location {0}", r.WindId));
                    if ((r.Flags & AmericasCup.Data.WindRecordFlags.Speed) == AmericasCup.Data.WindRecordFlags.Speed)
                        sb.AppendFormat(" is {0} m/s", r.WindSpeed);
                    if ((r.Flags & AmericasCup.Data.WindRecordFlags.Direction) == AmericasCup.Data.WindRecordFlags.Direction)
                        sb.AppendFormat(" at {0} degrees", r.WindDirection);
                    Console.WriteLine(sb.ToString());
                }
            };
            e.OnAverageWind += w => Console.WriteLine("Average wind is {0.00}m/s over past {0}s, {0.00}m/s over past {0}s, {0.00}m/s over past {0}s, {0.00}m/s over past {0}s",
                w.RawSpeed, w.RawPeriod, w.Speed2, w.Period2, w.Speed3, w.Period3, w.Speed4, w.Period4);
            e.OnUnsupportedXmlMessage += xm => {
                Console.WriteLine(string.Format("XML {0} message:\n", xm.SubType, xm.Text));
            };
            e.OnUnsupportedMessage += um => Console.WriteLine(string.Format("Unsupported message {0} ({1} bytes) at {2}", um.Header.Type, um.Header.MessageLength, um.Header.TimeStamp));

            c.OnMessage += (h,b,r) => {
                Console.Write(".");
                e.MessageHandler(h, b, r);
            };
            c.Connect(ServerSource.Test);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
