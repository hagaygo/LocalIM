using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Network
{
    public class Sender
    {
        public void BroadcastRaw(byte[] bytes)
        {
            using (var client = new UdpClient())
            {
                var ip = new IPEndPoint(IPAddress.Broadcast, Listener.PORT);
                client.Send(bytes, bytes.Length, ip);             
            }
        }

        /// <summary>
        /// send to specific addresss
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="address"></param>
        public void SendRaw(byte[] bytes,string address)
        {
            using (var client = new UdpClient())
            {
                client.Send(bytes, bytes.Length, address, Listener.PORT);
            }
        }
    }
}
