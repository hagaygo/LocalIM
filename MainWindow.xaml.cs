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
                var pp = new Packet(Headers.Init.I_AM_HERE, txtMyUser.Text, Listener.Instance.LocalIP, new byte[] { 0 });
                var s = new Sender();
                s.BroadcastRaw(pp.ToRaw());
            }
            else
                if (StructuralComparisons.StructuralEqualityComparer.Equals(p.Header, Headers.Init.I_AM_HERE))
                {
                    lstUsers.Items.Add(p.UserIdText);
                }
                else
                    if (StructuralComparisons.StructuralEqualityComparer.Equals(p.Header, Headers.Message.MESSAGE))
                    {
                        lstMessages.Items.Add(Encoding.Unicode.GetString(p.Data));
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
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = new Sender();

            var pp = new Packet(Headers.Init.WHO_IS_THERE, txtMyUser.Text, Listener.Instance.LocalIP, new byte[] { 0 });
            s.BroadcastRaw(pp.ToRaw());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var s = new Sender();
            var pp = new Packet(Headers.Message.MESSAGE, txtMyUser.Text, Listener.Instance.LocalIP, Encoding.Unicode.GetBytes(txtMessage.Text));
            s.SendRaw(pp.ToRaw(), "192.168.200.10");
        }
    }
}
