using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace IS.SIP2.CS
{
	public class Sip2Client
	{
		public Sip2Client(Socket socket, ServiceSection config)
		{
			_socket = socket;
			_config = config;
			LastMessage = null;
			_receiveArgs = new SocketAsyncEventArgs { AcceptSocket = _socket };
			_receiveArgs.SetBuffer(new byte[1024], 0, 1024);
			_receiveArgs.Completed += new EventHandler<SocketAsyncEventArgs>(ProcessReceive);
			_socket.ReceiveAsync(_receiveArgs);
		}

		void ProcessReceive(object sender, SocketAsyncEventArgs e)
		{
			try
			{
				if (e.SocketError == SocketError.Success)
				{
					String sb = Encoding.ASCII.GetString(e.Buffer, 0, e.BytesTransferred);
					LastMessage = Sip2Message.GetMessage(sb, _config.Answers.Separator, LastMessage);
					if (OnReceive != null)
					{
						OnReceive(this, new Sip2MessageEventArgs(LastMessage));
					}
					e.SetBuffer(new byte[1024], 0, 1024);
					_socket.ReceiveAsync(_receiveArgs);
				}
			}
			catch (Exception ex)
			{
				if (OnError != null)
				{
					OnError(this, new ErrorEventArgs(ex));
				}
			}
		}

		public void Send(ISip2Message message)
		{
			_socket.Send(Encoding.ASCII.GetBytes(message.Response.ToString(_config.Answers.Separator, _config.Answers.Debug)));
			if (OnSend != null)
			{
				OnSend(this, new Sip2MessageEventArgs(message));
			}
		}

		private readonly Socket _socket = null;
		private readonly ServiceSection _config = null;
		public ISip2Message LastMessage { get; private set; }
		private readonly SocketAsyncEventArgs _receiveArgs = null;
		public event EventHandler<Sip2MessageEventArgs> OnReceive;
		public event EventHandler<Sip2MessageEventArgs> OnSend;
		public event ErrorEventHandler OnError;
	}
}
