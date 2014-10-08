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
    public class Contact : INotifyPropertyChanged
    {
        public Contact()
        {
            _messages = new List<Message>();
            ShowContactChatCommand = new ShowChatCommand(this);
        }

        public string Username { get; set; }
        public string Address { get; set; }

        DateTime _lastAction;
        
        public DateTime LastAction 
        {
            get { return _lastAction; }
            set
            {
                if (_lastAction != value)
                {
                    _lastAction = value;
                    NotifyContactState();
                }
                    
            }
        }
        List<Message> _messages { get; set; }

        public ICommand ShowContactChatCommand { get; private set; }

        public ReadOnlyCollection<Message> Messages
        {
            get { return _messages.AsReadOnly(); }
        }

        public void AddMessage(Message m)
        {
            _messages.Add(m);
            LastAction = DateTime.Now;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Messages"));
                PropertyChanged(this, new PropertyChangedEventArgs("MessagesCount"));
                if (m is IncomingMessage && !((IncomingMessage)m).IsRead)
                    PropertyChanged(this, new PropertyChangedEventArgs("UnreadMessagesCount"));
                NotifyContactState();
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

        public void MarkAsRead(IncomingMessage msg)
        {
            msg.IsRead = true;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("UnreadMessagesCount"));
            }
        }

        public void CheckActivity()
        {
#if DEBUG
            if ((DateTime.Now - LastAction).TotalSeconds < 5)
#else
            if ((DateTime.Now - LastAction).TotalSeconds < 30)
#endif
                return;

            NotifyContactState();
        }

        private void NotifyContactState()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("IsIdle"));
                PropertyChanged(this, new PropertyChangedEventArgs("IsInActive"));
            }
        }

        public bool IsIdle
        {
            get 
            { 
#if DEBUG
                return (DateTime.Now - LastAction).TotalSeconds > 8; 
#else
                return (DateTime.Now - LastAction).TotalMinutes > 1; 
#endif
            }
        }

        public bool IsInActive
        {
            get 
            { 
                #if DEBUG
                return (DateTime.Now - LastAction).TotalSeconds > 16; 
#else
                return (DateTime.Now - LastAction).TotalMinutes > 2; 
#endif
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

