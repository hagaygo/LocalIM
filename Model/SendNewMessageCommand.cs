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
        ContactViewModel _contactViewModel;

        public SendNewMessageCommand(ContactViewModel contactVM)
        {
            _contactViewModel = contactVM;
            _contactViewModel.PropertyChanged += ContactViewModel_PropertyChanged;
        }

        void ContactViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {                
                case "NewMessageText":
                    CanExecuteChanged(this,EventArgs.Empty);
                    break;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (string.IsNullOrEmpty(_contactViewModel.NewMessageText))
                return false;
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var m = new OutgoingMessage();
            m.Guid = Guid.NewGuid();
            m.Text = _contactViewModel.NewMessageText;
            _contactViewModel.AddMessage(m);
        }
    }
}
