using LocalIM.Command;
using LocalIM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalIM.ViewModel
{
    public class ContactViewModel : ViewModelBase
    {
        public Contact Contact { get; private set; }

        public ContactViewModel(Contact c)
        {
            Contact = c;
            c.Messages.CollectionChanged += Messages_CollectionChanged;
            ShowContactChatCommand = new ShowChatCommand(this);
            SendNewMessage = new SendNewMessageCommand(this);
        }

        void Messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("Messages");
            NotifyPropertyChanged("MessagesCount");
            foreach (Message m in e.NewItems)
            {
                if (m is IncomingMessage && !((IncomingMessage)m).IsRead)
                {
                    NotifyPropertyChanged("UnreadMessagesCount");
                    return;
                }
            }
        }

        public int UnreadMessagesCount
        {
            get { return Contact.UnreadMessagesCount; }
        }

        public ICommand ShowContactChatCommand { get; private set; }
        public ICommand SendNewMessage { get; private set; }

        string _newMessageText;

        public string NewMessageText
        {
            get { return _newMessageText; }
            set
            {
                if (value != _newMessageText)
                {
                    _newMessageText = value;
                    NotifyPropertyChanged("NewMessageText");
                }
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

        public void MarkAsRead(IncomingMessage msg)
        {
            msg.IsRead = true;
            NotifyPropertyChanged("UnreadMessagesCount");            
        }

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

        private void NotifyContactState()
        {
            NotifyPropertyChanged("LastActionText");
            NotifyPropertyChanged("IsIdle");
            NotifyPropertyChanged("IsInActive");
        }

        public void AddMessage(Message m)
        {
            Contact.Messages.Add(m);
            if (m is IncomingMessage)
                LastAction = DateTime.Now;            
        }

        public string LastActionText
        {
            get { return string.Format("Last action : {0}", (DateTime.Now - LastAction).ToReadableString()); }
        }
    }
}
