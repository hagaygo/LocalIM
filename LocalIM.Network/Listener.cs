using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Network
{
    public class Listener
    {
        UdpClient _udpClient;
        IPEndPoint _endPoint;
        public const int PORT = 60000;

        protected Listener()
        {
            _udpClient = new UdpClient(PORT);
            _endPoint = new IPEndPoint(IPAddress.Any, PORT);
        }

        public byte[] Receive()
        {            
            return _udpClient.Receive(ref _endPoint);
        }

        public void Stop()
        {
            _udpClient.Close();
        }

        static Listener _listener;

        public static Listener Instance
        {
            get
            {
                if (_listener == null)
                {
                    _listener = new Listener();
                }

                return _listener;
            }
        }
    }
}
