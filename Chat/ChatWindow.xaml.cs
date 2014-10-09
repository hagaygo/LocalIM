using LocalIM.Model;
using LocalIM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LocalIM.Chat
{
    /// <summary>
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ContactViewModel ContactViewModel { get; private set; }

        public ChatWindow(ContactViewModel contact)
        {
            InitializeComponent();
            ContactViewModel = contact;
            DataContext = contact;            
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            Left = Owner.Left + 100;
            Top = Owner.Top + 80;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
