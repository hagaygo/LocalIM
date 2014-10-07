using LocalIM.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalIM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            InitListener();
        }

        const string MyUsername = "My User";

        MainViewModel ViewModel
        {
            get { return (MainViewModel)DataContext; }
        }

        #region network related

        private void InitListener()
        {
            var ts = new System.Threading.ThreadStart(ListenerAction);
            var t = new System.Threading.Thread(ts) { IsBackground = true };
            t.Start();
        }

        public void DataReceived(Packet p)
        {
            if (p.SourceIP == Listener.Instance.LocalIP)
                return; // ignore my self

            if (StructuralComparisons.StructuralEqualityComparer.Equals(p.Header ,Headers.Init.WHO_IS_THERE))
            {                
                //var pp = new Packet(Headers.Init.I_AM_HERE, txtMyUser.Text, Listener.Instance.LocalIP, new byte[] { 0 });
                //var s = new MySender(ViewModel.UserName);
                //s.BroadcastRaw(pp.ToRaw());
            }
            else
                if (StructuralComparisons.StructuralEqualityComparer.Equals(p.Header, Headers.Init.I_AM_HERE))
                {
                    ViewModel.CheckNewContact(p.UserIdText, p.SourceIP);                    
                }
                else
                    if (StructuralComparisons.StructuralEqualityComparer.Equals(p.Header, Headers.Message.MESSAGE))
                    {
                        var guidBytes = p.Data.Take(16).ToArray();
                        var messageBytes = p.Data.Skip(16).ToArray();
                        ViewModel.GotMessage(p.UserIdText, p.SourceIP, Encoding.Unicode.GetString(messageBytes), new Guid(guidBytes));                        
                    }
                    else
                        if (StructuralComparisons.StructuralEqualityComparer.Equals(p.Header, Headers.Message.MESSAGE_ACCEPTED))
                        {
                            var guidBytes = p.Data.Take(16).ToArray();
                            ViewModel.GotMessageConfirm(new Guid(guidBytes));
                        }
        }



        void ListenerAction()
        {            
            var l = Listener.Instance;
            while (System.Threading.Thread.CurrentThread.IsAlive)
            {
                var b = l.Receive();                
                if (b.Length > 0)
                {
                    var p = new Packet(b);
                    Dispatcher.Invoke(() => { DataReceived(p); });
                }
                System.Threading.Thread.Sleep(50);
            }
        }

        #endregion
    }
}
