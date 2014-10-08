using LocalIM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Chat
{
    public class ChatManager
    {
        protected ChatManager()
        {
        }

        List<ChatWindow> _windows = new List<ChatWindow>();

        public ReadOnlyCollection<ChatWindow> Windows
        {
            get { return _windows.AsReadOnly(); }
        }

        static ChatManager _instance;

        public void ShowChatWindow(Contact contact)
        {
            lock (typeof(ChatManager))
            {
                var window = Windows.FirstOrDefault(x => x.Contact == contact);
                if (window == null)
                {
                    window = new ChatWindow(contact) { Owner = App.Current.MainWindow };
                    window.Closed += window_Closed;
                    window.Show();
                    _windows.Add(window);
                    window.Activate();
                }
                else
                {
                    window.Activate();
                }
            }
        }

        void window_Closed(object sender, EventArgs e)
        {
            lock (typeof(ChatManager))
            {
                _windows.Remove((ChatWindow)sender);
            }
        }

        public static ChatManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(ChatManager))
                    {
                        if (_instance == null)
                            _instance = new ChatManager();
                    }
                }
                return _instance;
            }
        }


    }
}
