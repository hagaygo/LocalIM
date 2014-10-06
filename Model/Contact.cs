using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalIM.Model
{
    public class Contact
    {
        public string Username { get; set; }
        public string Address { get; set; }
        public DateTime LastAction { get; set; }
        public List<Message> Messages { get; set; }
    }
}
