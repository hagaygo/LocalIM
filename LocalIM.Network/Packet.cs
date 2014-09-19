using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Network
{
    public class Packet
    {
        public byte[] Header { get; private set; }
        public byte[] SourceAddress { get; private set; }
        public byte[] UserId { get; private set; }
        public byte[] Data { get; private set; }

        public string UserIdText { get; private set; }

        const int Total_Header_Length = 52;

        public Packet(byte[] rawData)
        {
            if (rawData.Length < Total_Header_Length)
                throw new ApplicationException("raw data too short");
            Header = rawData.Take(8).ToArray();
            SourceAddress = rawData.Skip(8).Take(4).ToArray();
            UserId = rawData.Skip(12).Take(40).ToArray();
            Data = rawData.Skip(Total_Header_Length).ToArray();

            UserIdText = Encoding.Unicode.GetString(UserId);
        }

        public Packet(byte[] header, string user, string sourceAddress, byte[] data)
        {
            Header = header;
            Data = data;
            UserId =  Encoding.Unicode.GetBytes(user);
            var ip = IPAddress.Parse(sourceAddress);
            SourceAddress = ip.GetAddressBytes();
        }

        public byte[] ToRaw()
        {
            var raw = new Byte[Total_Header_Length + Data.Length];
            System.Buffer.BlockCopy(Header,0,raw,0,Header.Length);
            System.Buffer.BlockCopy(SourceAddress, 0, raw, Header.Length, SourceAddress.Length);
            System.Buffer.BlockCopy(UserId, 0, raw, 12, UserId.Length);
            System.Buffer.BlockCopy(Data, 0, raw, 52, Data.Length);
            return raw;
        }
    }
}
