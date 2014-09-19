using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Network
{
    public static class Headers
    {
        public static class Init
        {
            /// <summary>
            /// broadcast my location to all network 
            /// </summary>
            public static readonly byte[] WHO_IS_THERE = new byte[] { 255, 255, 255, 255 , 0 , 251 , 77 , 22 };
            /// <summary>
            /// request PONG Reply
            /// </summary>
            public static readonly byte[] PING = new byte[] { 255, 255, 255, 255 , 0 ,251, 78 , 22 };
            /// <summary>
            /// respone to a ping request
            /// </summary>
            public static readonly byte[] PONG = new byte[] { 255, 255, 255, 255, 0, 251, 78, 22 };
        }

        public static class Message
        {
            /// <summary>
            /// message header
            /// </summary>
            public static readonly byte[] MESSAGE = new byte[] { 255, 255, 255, 255, 0, 251, 88, 21 };

            /// <summary>
            /// message header
            /// </summary>
            public static readonly byte[] MESSAGE_ACCEPTED = new byte[] { 255, 255, 255, 255, 0, 251, 88, 22 };
        }
    }
}
