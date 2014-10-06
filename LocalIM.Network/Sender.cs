using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Network
{
    public abstract class Sender
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
        protected void SendRaw(byte[] bytes,string address)
        {
            using (var client = new UdpClient())
            {
                client.Send(bytes, bytes.Length, address, Listener.PORT);
            }
        }

        protected void SendMessage(string targetAddress, byte[] message, string myUser)
        {
            var pp = new Packet(Headers.Message.MESSAGE, myUser, Listener.Instance.LocalIP, message);
            SendRaw(pp.ToRaw(), targetAddress);
        }

        protected void SendConfirmMessage(string targetAddress, byte[] message, string myUser)
        {
            var pp = new Packet(Headers.Message.MESSAGE_ACCEPTED, myUser, Listener.Instance.LocalIP, message);
            SendRaw(pp.ToRaw(), targetAddress);
        }
    }
}
