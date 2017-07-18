using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using IS.Interface;
using IS.Interface.SIP2;

namespace IS.SIP2.CS
{
	public class Sip2Server : ISip2Answers, IDisposable
	{
		private Socket _listener = null;
		private List<Sip2Client> clients = new List<Sip2Client>();
		public Sip2Server(ServiceSection config)
		{
			_config = config;
			_answer = (ISip2Answers)Activator.CreateInstance(Type.GetTypeFromProgID(_config.Answers.Name));
			_answer.OnError += new ErrorEventHandler(command_OnError);
			foreach (ISip2Command command in _answer.Commands)
			{
				command.OnError += new ErrorEventHandler(command_OnError);
			}
		}

		void command_OnError(object sender, ErrorEventArgs e)
		{
			Log.For(sender).Error(e.GetException().Message);
			if (OnError != null)
			{
				OnError(sender, e);
			}
		}

		private readonly ServiceSection _config;

		internal void Start()
		{
			IPAddress address = IPAddress.Parse(_config.Answers.Address);
			IPEndPoint localEndPoint = new IPEndPoint(address, _config.Answers.Port);
			_listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, _config.Answers.Proto);
			try
			{
				_listener.Bind(localEndPoint);
				_listener.Listen(_config.Answers.MaxConnection);
				SocketAsyncEventArgs e = new SocketAsyncEventArgs();
				e.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
				if (!_listener.AcceptAsync(e))
				{
					AcceptEventArg_Completed(_listener, e);
				}
				Log.For(this).Info(String.Format("Listen SIP2-server for address: {0}", localEndPoint.ToString()));
			}
			catch (Exception ex)
			{
				command_OnError(this, new ErrorEventArgs(ex));
			}
		}

		void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e)
		{
			if (e.SocketError == SocketError.Success)
			{
				Sip2Client client = new Sip2Client(e.AcceptSocket, _config);
				client.OnReceive += new EventHandler<Sip2MessageEventArgs>(client_OnReceive);
				clients.Add(client);
				Log.For(this).Info(String.Format("Accept client from address: {0}", e.AcceptSocket.RemoteEndPoint.ToString()));
			}
		}

		void client_OnReceive(object sender, Sip2MessageEventArgs e)
		{
			if (e.Message != null)
			{
				foreach (ISip2Command command in (this as ISip2Answers).Commands)
				{
					if (command.Request.Equals(e.Message.Request.Command))
					{
						IField[] fields = e.Message.Response.ToArray();
						if (Convert.ToInt16(e.Message.Version) <= (Convert.ToInt16(_answer.Version)))
						{
							if (command.Execute(e.Message.Request.Cast<IField>().ToArray(), ref fields))
							{
								e.Message.Response.GetFieldImpl("sequence").Value = e.Message.Request.GetFieldImpl("sequence").Value;
								if (sender is Sip2Client)
								{
									(sender as Sip2Client).Send(e.Message);
								}
							}
						}
					}
				}
			}
		}

		internal void Stop()
		{
			if (_listener != null)
			{
				_listener.Close();
			}
		}

		public event EventHandler<Sip2MessageEventArgs> OnReceive;
		public event EventHandler<Sip2MessageEventArgs> OnSend;

		#region implementation interface ISip2Answers
		private readonly ISip2Answers _answer = null;

		public bool Init(IField[] paramsFields)
		{
			return (_answer != null && _answer.Init(paramsFields));
		}

		public ISip2Command[] Commands
		{
			get { return (_answer != null) ? _answer.Commands : new List<ISip2Command>().ToArray(); }
		}

		Sip2Version ISip2Answers.Version { get { return (_answer != null) ? _answer.Version : Sip2Version.V100; } }

		public event ErrorEventHandler OnError;
		#endregion

		#region implementation interface IDisposable
		public void Dispose()
		{
			foreach (ISip2Command command in _answer.Commands)
			{
				command.OnError -= command_OnError;
			}
			Stop();
		}
		#endregion
	}
}
