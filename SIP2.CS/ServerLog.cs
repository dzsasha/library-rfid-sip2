﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace InformSystema.SIP2.CS
{
	public partial class ServerLog : Form
	{
		public ServerLog(ServiceSection config)
		{
			_server = new Sip2Server(config);
			InitializeComponent();
			_server.OnReceive += new EventHandler<Sip2MessageEventArgs>(_server_OnReceive);
			textAddress.ValidatingType = typeof(IPAddress);
			comboProto.DataSource = Enum.GetValues(typeof(ProtocolType));
			comboProto.SelectedItem = config.Answers.Proto;
		}

		private void _server_OnReceive(object sender, Sip2MessageEventArgs e)
		{
			if (textLog.InvokeRequired)
			{
				textLog.Invoke((ThreadStart)(() => textLog.AppendText(Environment.NewLine + String.Format("<={0}: {1}", (sender as Socket).RemoteEndPoint.ToString()))));
			}
			else
			{
				textLog.AppendText(Environment.NewLine + e.Message);
			}
		}

		private readonly Sip2Server _server = null;

		private void button3_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			_server.Start();
			textLog.Text = "Listen server...";
		}

		private void button2_Click(object sender, EventArgs e)
		{
			textLog.AppendText(Environment.NewLine + "Stoping server.");
			_server.Stop();
		}

		private void ServerLog_FormClosed(object sender, FormClosedEventArgs e)
		{
			_server.Stop();
		}

	}
}