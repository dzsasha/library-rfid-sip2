using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformSystema.Interface.SIP2
{
	/// <summary>
	/// 
	/// </summary>
	public class Sip2CommandAttribute : Attribute
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		/// <param name="request">Команда входа</param>
		/// <param name="response">Команда ответа</param>
		public Sip2CommandAttribute(Sip2Request request, Sip2Response response)
		{
			Version = Sip2Version.V100;
			Response = response;
			Request = request;
		}
		/// <summary>
		/// Входящее сообщение
		/// </summary>
		public Sip2Request Request { get; set; }
		/// <summary>
		/// Ответное сообщение
		/// </summary>
		public Sip2Response Response { get; set; }
		/// <summary>
		/// Версия
		/// </summary>
		public Sip2Version Version { get; set; }
	}
}
