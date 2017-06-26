using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.Cloud
{
	public class LoginImpl : ISip2Command
	{
		public Sip2Request Request
		{
			get { return Sip2Request.scLogin; }
		}

		public Sip2Response Response
		{
			get { return Sip2Response.acLogin; }
		}

		public bool Execute(Interface.IField[] request, ref Interface.IField[] response)
		{
			response.GetField("ok").Value = '1';
			return true;
		}

		public event ErrorEventHandler OnError;
	}
}
