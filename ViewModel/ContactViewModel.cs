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
            ShowContactChatCommand = new ShowChatCommand(this);
            SendNewMessage = new SendNewMessageCommand(this);
        }

        public ICommand ShowContactChatCommand { get; private set; }
        public ICommand SendNewMessage { get; private set; }

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
            LastAction = DateTime.Now;
            NotifyPropertyChanged("Messages");
            NotifyPropertyChanged("MessagesCount");
            if (m is IncomingMessage && !((IncomingMessage)m).IsRead)
                NotifyPropertyChanged("UnreadMessagesCount");            
        }

        public string LastActionText
        {
            get { return string.Format("Last action : {0}", (DateTime.Now - LastAction).ToReadableString()); }
        }
    }
}
