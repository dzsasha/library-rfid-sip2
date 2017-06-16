using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InformSystema.SIP2.CS
{
	public partial class ServerLog : Form
	{
		public ServerLog(ServiceSection config)
		{
			_server = new Sip2Server(config);
			InitializeComponent();
		}

		private Sip2Server _server = null;
	}
}
