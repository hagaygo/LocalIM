using LocalIM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalIM
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Contacts.CollectionChanged += Contacts_CollectionChanged;
        }

        void Contacts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
        }

        public ObservableCollection<Contact> Contacts { get; private set; }
        public string UserName { get; set; }

        static object _lockObject = new object();

        Contact FindContact(string username, string address)
        {
            return Contacts.FirstOrDefault(x => x.Username == username && x.Address == address);
        }

        public void CheckNewContact(string username, string address)
        {
            lock (_lockObject)
            {
                var contact = FindContact(username, address);
                if (contact == null)
                {
                    contact = new Contact
                    {
                        Address = address,
                        LastAction = DateTime.Now,                        
                        Username = username
                    };
                    Contacts.Add(contact);
                }
                else
                    contact.LastAction = DateTime.Now;
            }
        }

        public void SendMessage(Contact contact, OutgoingMessage msg)
        {
            
        }



        public string StatusText
        {
            get
            {
                return string.Format("{0} Contacts", Contacts.Count);
            }
        }

        public void GotMessage(string username, string address, string message,Guid guid)
        {
            var contact = FindContact(username, address);
            if (contact != null)
            {
                if (!contact.Messages.Any(x => x.Guid == guid))
                {
                    var m = new IncomingMessage
                    {
                        Guid = guid,
                        Text = message,
                        TimeStamp = DateTime.Now
                    };
                    contact.AddMessage(m);
                    
                    // todo : send confirm
                }
            }
        }

        public void GotMessageConfirm(Guid guid)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
