using LocalIM.Network;
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

            var s = new Sender();

            var pp = new Packet(Headers.Init.WHO_IS_THERE, "testing נסיון", "192.32.22.111", new byte[] { 1, 2, 3, 5 });
            s.BroadcastRaw(pp.ToRaw());
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
                }
            }
            
        }
    }
}
