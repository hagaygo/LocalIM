using LocalIM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalIM
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Contacts = new List<Contact>();
        }

        public List<Contact> Contacts { get; private set; }
        public string UserName { get; set; }

        public void CheckNewContact(string username, string address)
        {

        }

        public void SendMessage(Contact contact, OutgoingMessage msg)
        {
            
        }

        public void GotMessage(string username, string address, string message,Guid guid)
        {

        }

        public void GotMessageConfirm(Guid guid)
        {

        }
    }
}
