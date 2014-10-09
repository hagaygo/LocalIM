using LocalIM.Model;
using LocalIM.ViewModel;
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
            ContactViewModels = new ObservableCollection<ContactViewModel>();
            ContactViewModels.CollectionChanged += Contacts_CollectionChanged;
        }
        
        void Contacts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("StatusText"));
        }

        public ObservableCollection<ContactViewModel> ContactViewModels { get; private set; }
        public string UserName { get; set; }

        static object _lockObject = new object();

        ContactViewModel FindContactViewModel(string username, string address)
        {
            return ContactViewModels.FirstOrDefault(x => x.Contact.Username == username && x.Contact.Address == address);
        }

        public void CheckNewContact(string username, string address)
        {
            lock (_lockObject)
            {
                var contact = FindContactViewModel(username, address);
                if (contact == null)
                {
                    contact = new ContactViewModel(
                        new Contact
                        {
                        Address = address,                        
                        Username = username
                        })
                    {
                        LastAction = DateTime.Now
                    };
                    ContactViewModels.Add(contact);
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
                return string.Format("{0} Contacts", ContactViewModels.Count);
            }
        }

        public void GotMessage(string username, string address, string message,Guid guid)
        {
            var contactViewModel = FindContactViewModel(username, address);
            if (contactViewModel != null)
            {
                if (!contactViewModel.Contact.Messages.Any(x => x.Guid == guid))
                {
                    var m = new IncomingMessage
                    {
                        Guid = guid,
                        Text = message,
                        TimeStamp = DateTime.Now
                    };
                    contactViewModel.AddMessage(m);
                    
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
