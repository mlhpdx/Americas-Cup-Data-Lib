using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmericasCup.Data;

namespace AmericasCup.Feed
{
    public class FeedEvents
    {
        public FeedEvents() { InitializeMessageHandlers(); }

        public Dictionary<MessageTypeEnum, Action<byte[], byte[]>> MessageTypeHandlers;

        public void InitializeMessageHandlers()
        {
            MessageTypeHandlers = new Dictionary<MessageTypeEnum, Action<byte[], byte[]>>()
            {
                { MessageTypeEnum.Heartbeat, (header, body) => { if (OnHeartbeat != null) OnHeartbeat(Heartbeat.Read(body)); } },
                { MessageTypeEnum.RaceStatus, (header, body) => { if (OnRaceStatus != null) OnRaceStatus(RaceStatus.Read(body)); } },
                { MessageTypeEnum.DisplayTextMessage, (header, body) => { if (OnDisplayTextMessage != null) OnDisplayTextMessage(DisplayTextMessage.Read(body)); } },
                { MessageTypeEnum.XmlMessage, (header, body) => { if (OnXmlMessage != null) OnXmlMessage(XmlMessage.Read(body)); } },
                { MessageTypeEnum.RaceStartStatus, (header, body) => { if (OnRaceStartStatus != null) OnRaceStartStatus(RaceStartStatus.Read(body)); } },
                { MessageTypeEnum.YachtEventCode, (header, body) => { if (OnYachtEventCode != null) OnYachtEventCode(YachtEventCode.Read(body)); } },
                { MessageTypeEnum.YachtActionCode, (header, body) => { if (OnYachtActionCode != null) OnYachtActionCode(YachtActionCode.Read(body)); } },
                { MessageTypeEnum.ChatterText, (header, body) => { if (OnChatterText != null) OnChatterText(ChatterText.Read(body)); } },
                { MessageTypeEnum.BoatLocation, (header, body) => { if (OnBoatLocation != null) OnBoatLocation(BoatLocation.Read(body)); } },
                { MessageTypeEnum.MarkRounding, (header, body) => { if (OnMarkRounding != null) OnMarkRounding(MarkRounding.Read(body)); } },
                { MessageTypeEnum.CourseWind, (header,body) => { if (OnCourseWind != null) OnCourseWind(CourseWind.Read(body)); } },
                { MessageTypeEnum.AverageWind, (header,body) => { if (OnAverageWind != null) OnAverageWind(AverageWind.Read(body)); } }
            };
        }

        public void MessageHandler(byte[] header, byte[] body, byte[] crc)
        {
            var type = (MessageTypeEnum)header[2];

            if (MessageTypeHandlers.ContainsKey(type))
                MessageTypeHandlers[type](header, body);
            else if (OnUnsupportedMessage != null)
            {
                var msg = new Message();
                MessageHeader.Read(header, 0, msg.Header);
                Message.Read(body, 0, msg);
                msg.Crc = BitConverter.ToUInt32(crc, 0);

                OnUnsupportedMessage(msg);
            }
        }

        public event Action<Heartbeat> OnHeartbeat;
        public event Action<RaceStatus> OnRaceStatus;
        public event Action<DisplayTextMessage> OnDisplayTextMessage;
        public event Action<XmlMessage> OnXmlMessage;
        public event Action<RaceStartStatus> OnRaceStartStatus;
        public event Action<YachtEventCode> OnYachtEventCode;
        public event Action<YachtActionCode> OnYachtActionCode;
        public event Action<ChatterText> OnChatterText;
        public event Action<BoatLocation> OnBoatLocation;
        public event Action<MarkRounding> OnMarkRounding;
        public event Action<CourseWind> OnCourseWind;
        public event Action<AverageWind> OnAverageWind;

        public event Action<Message> OnUnsupportedMessage;
    }
}
