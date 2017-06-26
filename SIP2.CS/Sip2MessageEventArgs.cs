using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace InformSystema.SIP2.CS
{
	
	public class Sip2MessageEventArgs : EventArgs
	{
		public Sip2MessageEventArgs(ISip2Message message)
		{
			Message = message;
		}
		public ISip2Message Message { get; private set; }
	}

}
