using LocalIM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace LocalIM.Model
{
    public class SendNewMessageCommand : ICommand
    {
        ContactViewModel _contact;

        public SendNewMessageCommand(ContactViewModel contact)
        {
            _contact = contact;
        }

        public bool CanExecute(object parameter)
        {
            //if (_contact.
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            
        }
    }
}
