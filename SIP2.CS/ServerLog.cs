using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IS.SIP2.CS {
    public partial class ServerLog : Form {
        private Socket _client = null;
        private ServiceSection _config = null;
        public ServerLog(ServiceSection config, string[] args) {
            _server = new Sip2Server(config);
            _config = config;
            InitializeComponent();
            _server.OnReceive += new EventHandler<Sip2MessageEventArgs>(_server_OnReceive);
            _server.OnSend += new EventHandler<Sip2MessageEventArgs>(_server_OnSend);
            _server.OnError += new ErrorEventHandler(_server_OnError);
            _server.OnStart += new EventHandler(_server_OnStart);
            textAddress.ValidatingType = typeof(IPAddress);
            comboProto.DataSource = Enum.GetValues(typeof(ProtocolType));
            comboProto.SelectedItem = config.Answers.Proto;
            if (!(args.Length > 0 && args[0].Equals("/debug"))) {
                tabClient.TabPages.Remove(tabPageClient);
            }
        }

        private void _server_OnStart(object sender, EventArgs e) {
            if(tabClient.Visible) {
                IPAddress address = IPAddress.Parse("127.0.0.1");
                IPEndPoint localEndPoint = new IPEndPoint(address, _config.Answers.Port);
                _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, _config.Answers.Proto);
                _client.Connect(localEndPoint);
            }
        }

        private void _server_OnError(object sender, ErrorEventArgs e) {
            MessageBox.Show(e.GetException().Message, "Error", MessageBoxButtons.OK);
        }

        private void _server_OnSend(object sender, Sip2MessageEventArgs e) {
            if (textLog.InvokeRequired) {
                textLog.Invoke((ThreadStart)(() => textLog.AppendText(Environment.NewLine +
                                                                      $"{(sender as Socket)?.LocalEndPoint.ToString()} => {e.str}")));
            } else {
                textLog.AppendText(Environment.NewLine + e.str);
            }
        }

        private void _server_OnReceive(object sender, Sip2MessageEventArgs e) {
            if (textLog.InvokeRequired) {
                textLog.Invoke((ThreadStart)(() => textLog.AppendText(Environment.NewLine +
                                                                      $"{(sender as Socket)?.RemoteEndPoint.ToString()} <= {e.str}")));
            } else {
                textLog.AppendText(Environment.NewLine + e.str);
            }
        }

        private readonly Sip2Server _server = null;

        private void button3_Click(object sender, EventArgs e) {
            Close();
        }

        private void button1_Click(object sender, EventArgs e) {
            _server.Start();
            textLog.Text = "Listen server...";
        }

        private void button2_Click(object sender, EventArgs e) {
            textLog.AppendText(Environment.NewLine + "Stoping server.");
            _server.Stop();
        }

        private void ServerLog_FormClosed(object sender, FormClosedEventArgs e) {
            _server.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e) {
            _client.Send(Encoding.UTF8.GetBytes(textSend.Text));
            _client.Send(new byte[] { 0x0D });
        }
    }
}
