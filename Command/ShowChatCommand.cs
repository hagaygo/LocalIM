using LocalIM.Chat;
using LocalIM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LocalIM.Command
{
    public class ShowChatCommand : ICommand
    {
        Contact Contact { get; set; }

        public ShowChatCommand(Contact contact)
        {
            Contact = contact;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            ChatManager.Instance.ShowChatWindow(Contact);
        }
    }
}
