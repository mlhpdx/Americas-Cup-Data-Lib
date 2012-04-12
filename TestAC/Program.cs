using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmericasCup.Feed;
using System.Threading;
using System.Diagnostics;
using AmericasCup.Data;

namespace TestAC
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Client();
            var e = new FeedEvents();
//            e.OnHeartbeat += h => Console.WriteLine(string.Format("Heartbeat {0}", h.SequenceNum));
//            e.OnRaceStatus += rs => Console.WriteLine(string.Format("{0} race {1} is {2} with {3} boats.", rs.RaceType, rs.RaceId, rs.Status, rs.NumberOfBoatsInRace));
            e.OnDisplayTextMessage += tm => {
                Console.WriteLine(string.Format("Display {0} text messages:", tm.LinesOfText));
                tm.TextMessages.ForEach(m => Console.WriteLine(string.Format("  {0}", m.Text)));
            };
            e.OnChatterText += ch => Console.WriteLine(string.Format("{0}: {1}", ch.Source, ch.Text));
//            e.OnBoatLocation += bl => Console.WriteLine(string.Format("{0} {1} is rolled {2:0.0} and going {3:0.00} m/s", bl.DeviceType, bl.BoatId, bl.Roll, bl.BoatSpeed));
            e.OnMarkRounding += mr => Console.WriteLine(string.Format("Boat {0} just rounded {1} {2}.", mr.SourceId, mr.MarkType, mr.MarkId));
            e.OnYachtEventCode += ye => Console.WriteLine(string.Format("Boat {0} event {1}", ye.DestinationBoatId, ye.Event));
            e.OnYachtActionCode += ya => Console.WriteLine(string.Format("Boat {0} action {1}", ya.OriginatorBoatId, ya.Event));
            e.OnXmlMessage += xm => Console.WriteLine(string.Format("XML {0} message:\n {1}", xm.SubType, xm.Text));
            e.OnUnsupportedMessage += um => Console.WriteLine(string.Format("Unsupported message {0} ({1} bytes)", um.Header.Type, um.Header.MessageLength));

            c.OnMessage += e.MessageHandler;
            c.Connect();

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
