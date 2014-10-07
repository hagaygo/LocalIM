using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Model
{
    public class Contact : INotifyPropertyChanged
    {
        public Contact()
        {
            _messages = new List<Message>();
        }

        public string Username { get; set; }
        public string Address { get; set; }
        public DateTime LastAction { get; set; }
        List<Message> _messages { get; set; }

        public ReadOnlyCollection<Message> Messages
        {
            get { return _messages.AsReadOnly(); }
        }

        public void AddMessage(Message m)
        {
            _messages.Add(m);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("MessagesCount"));
                if (m is IncomingMessage && !((IncomingMessage)m).IsRead)
                    PropertyChanged(this, new PropertyChangedEventArgs("UnreadMessagesCount"));
            }
        }

        public string LastActionText
        {
            get { return string.Format("Last action : {0}", LastAction.ToString("hh:mm:ss")); }
        }

        public int MessagesCount
        {
            get { return _messages.Count; }
        }

        public int UnreadMessagesCount
        {
            get
            {                
                return _messages.Where(x => x is IncomingMessage).OfType<IncomingMessage>().Count(x => !x.IsRead);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
