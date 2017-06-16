using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
{
	public class Sip2Server : ISip2Answers, IDisposable
	{
		private readonly List<IPAddress> _address = new List<IPAddress>();
		public Sip2Server(ServiceSection config)
		{
			_config = config;
			if (!String.IsNullOrEmpty(config.Answers.Address))
			{
				_address.Add(IPAddress.Parse(config.Answers.Address));
			}
			else
			{
				IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
				_address.AddRange(ipHostInfo.AddressList);
			}
			_answer = (ISip2Answers)Activator.CreateInstance(Type.GetTypeFromProgID(_config.Answers.Name));
			foreach (ISip2Command command in _answer.Commands)
			{
				command.OnError += new ErrorEventHandler(command_OnError);
			}
		}

		void command_OnError(object sender, ErrorEventArgs e)
		{
			Log.For(sender).Error(e.GetException().Message);
		}

		private readonly ServiceSection _config;

		internal void Listener()
		{
			if (_address.Count > 0)
			{
				foreach (IPAddress ipAddress in _address)
				{
					IPEndPoint localEndPoint = new IPEndPoint(ipAddress, _config.Answers.Port);
					Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, _config.Answers.Proto);
				}
			}
		}
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

		public Sip2Version Version { get { return (_answer != null) ? _answer.Version : Sip2Version.V100; } }

		public event ErrorEventHandler OnError
		{
			add { if (_answer != null) _answer.OnError += value; }
			remove { if (_answer != null) _answer.OnError += value; }
		}
		#endregion

		#region implementation interface IDisposable
		public void Dispose()
		{
			foreach (ISip2Command command in _answer.Commands)
			{
				command.OnError -= command_OnError;
			}
		}
		#endregion
	}
}
