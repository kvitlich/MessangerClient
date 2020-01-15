using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMessanger
{
    public class Message
    {
        public string Nickname { get; set; }
        public string FromPort { get; set; }
        public string FromIp { get; set; }
        public string Text { get; set; }
    }
}
