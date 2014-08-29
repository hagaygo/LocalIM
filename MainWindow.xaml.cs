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
            System.Threading.Thread.Sleep(2000);
            s.SendRaw(Encoding.ASCII.GetBytes("hag"));
        }


        void ListenerAction()
        {
            var l = Listener.Instance;
            while (System.Threading.Thread.CurrentThread.IsAlive)
            {
                var b = l.Receive();
                if (b.Length > 0)
                {
                }
            }
            
        }
    }
}
