using LocalIM.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalIM.Model
{
    public class Contact
    {
        public Contact()
        {
            Messages = new ObservableCollection<Message>();            
        }        

        public string Username { get; set; }
        public string Address { get; set; }

        public ObservableCollection<Message> Messages { get; private set; }
        
        public int MessagesCount
        {
            get { return Messages.Count; }
        }

        public int UnreadMessagesCount
        {
            get
            {
                return Messages.Where(x => x is IncomingMessage).OfType<IncomingMessage>().Count(x => !x.IsRead);
            }
        }
    }
}

