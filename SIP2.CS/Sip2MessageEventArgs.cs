using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace IS.SIP2.CS {

    public class Sip2MessageEventArgs : EventArgs {
        public Sip2MessageEventArgs(string str) {
            this.str = str;
        }

        public string str { get; private set; }
    }

}
