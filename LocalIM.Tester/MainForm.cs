using LocalIM.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalIM.Tester
{
    public partial class b : Form
    {
        public b()
        {
            InitializeComponent();
        }

        TestSender GetSender()
        {
            return new TestSender(edtUsername.Text);
        }

        private void btnSendIAmHere_Click(object sender, EventArgs e)
        {
            var s = GetSender();
            var pp = new Packet(Headers.Init.I_AM_HERE, s.UserName, Listener.Instance.LocalIP, new byte[] { 0 });            
            s.BroadcastRaw(pp.ToRaw());
        }

        private void btnSendWhoIsThere_Click(object sender, EventArgs e)
        {
            var s = GetSender();
            var pp = new Packet(Headers.Init.WHO_IS_THERE, s.UserName, Listener.Instance.LocalIP, new byte[] { 0 });
            s.BroadcastRaw(pp.ToRaw());
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            var s = GetSender();
            s.SendMessage(edtMessageTargetAddress.Text, edtMessageText.Text);
        }
    }
}
