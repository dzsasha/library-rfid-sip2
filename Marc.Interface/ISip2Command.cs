using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Marc.Interface
{
	/// <summary>
	/// Интерфейс приема комманд
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2915")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ISip2Request
	{
	}
	/// <summary>
	/// Интерфейс отправки команд
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2916")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ISip2Response
	{
	}
	/// <summary>
	/// Интерфейс комманд SIP2-протокола
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2917")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ISip2Command
	{
		/// <summary>
		/// Входящее сообщение
		/// </summary>
		ISip2Request Request { set; }
		/// <summary>
		/// Ответное сообщение
		/// </summary>
		ISip2Response Response { get; }
	}
	/// <summary>
	/// Делегат события прихода нового сообщения
	/// </summary>
	/// <param name="request">входящее сообщение</param>
	/// <returns>ответное сообщение</returns>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2918")]
	[ComVisible(true)]
	public delegate ISip2Response Sip2EventHandler(ISip2Request request);
	/// <summary>
	/// Интерфейс сообщений
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2919")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface ISip2Answers : IEnumerable<ISip2Command>
	{
		/// <summary>
		/// Пришло новое сообщение
		/// </summary>
		event Sip2EventHandler OnCommand;
	}
}
