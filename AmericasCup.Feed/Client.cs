using AmericasCup.Data;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace AmericasCup.Feed
{
   public enum ServerSource { Test = 4941, Live = 4940 }
   public class Client
   {
      Socket _Socket;
      NetworkStream _Stream;

      public event Action<byte[], byte[], byte[]> OnMessage;

      public void Connect(ServerSource server = ServerSource.Test)
      {
         _Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
         _Socket.Connect("livedata.americascup.com", (int)server);

         _Stream = new NetworkStream(_Socket, System.IO.FileAccess.Read);

         void fillbuffer(byte[] b)
         {
            int total = 0, read = 0;
            while ((read = _Stream.Read(b, total, b.Length - total)) > 0)
            {
               total += read;
            }
         }

         Action receive = null;
         receive = new Action(() =>
          {
             var header = new byte[15];
             fillbuffer(header);

             var c = BitConverter.ToUInt16(header, 13);
             var body = new byte[c];
             fillbuffer(body);

             var crc = new byte[4];
             fillbuffer(crc);

#if DEBUG
             if (header[0] != 0x47 || header[1] != 0x83)
                Debug.WriteLine("Invalid message header");

             uint cm = BitConverter.ToUInt32(crc, 0);
             uint c1 = Crc32.Compute(header.Concat(body).ToArray());

             if (c1 != cm)
             {
                Debug.WriteLine(string.Format("CRC check failed: {1} in message vs. {0} calculated", c1, cm));
                string sheader = string.Join(" ", header.Select(b => b.ToString("X2")));
                string sbody = string.Join(" ", body.Select(b => b.ToString("X2")));
                string scrc = string.Join(" ", crc.Select(b => b.ToString("X2")));
                Debug.Write(string.Format("Header: {0}\nBody: {1}\nCRC: {2}\n", sheader, sbody, scrc));
             }
#endif
             OnMessage?.Invoke(header, body, crc);
             Task.Factory.StartNew(receive);
          });

         Task.Factory.StartNew(receive);
      }
   }
}
