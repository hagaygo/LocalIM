using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM
{
    public class MySender : LocalIM.Network.Sender
    {
        public string UserName { get; set; }

        public MySender(string userName)
        {
            UserName = userName;
        }

        public Guid SendMessage(string targetAddress, string message)
        {
            var g = Guid.NewGuid();
            SendMessage(targetAddress,message,g);
            return g;
        }

        public void SendMessage(string targetAddress,string message,Guid g)
        {
            var msgGuid = g.ToByteArray();            
            var textBytes = Encoding.Unicode.GetBytes(message);
            var messageBytes = new byte[msgGuid.Length + textBytes.Length];
            System.Buffer.BlockCopy(msgGuid, 0, messageBytes, 0, msgGuid.Length);
            System.Buffer.BlockCopy(textBytes, 0, messageBytes, msgGuid.Length, textBytes.Length);
            SendMessage(targetAddress, messageBytes, UserName);            
        }

        public void SendConfirmMessage(string targetAddress, Guid g)
        {
            var msg = g.ToByteArray();
            SendConfirmMessage(targetAddress, msg, UserName);
        }
    }
}
