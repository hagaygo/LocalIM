using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Model
{
    public abstract class Message
    {
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public Guid Guid { get; set; }
    }

    public class IncomingMessage : Message
    {
        public bool ConfirmSent { get; set; }
        public bool IsRead { get; set; }
    }

    public class OutgoingMessage : Message
    {
        public bool SendConfirm { get; set; }
        public int SendCounter { get; set; }
        public DateTime? LastSentTimeStamp { get; set; }
    }
}
