using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace InformSystema.Interface.SIP2
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
	public interface ISip2Response : ISerializable
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
		/// Выполнить входящее сообщение
		/// </summary>
		/// <param name="request">входящее сообщение</param>
		/// <returns>ответное сообщение</returns>
		ISip2Response Execute(ISip2Request request);
		/// <summary>
		/// Событие, если была ошибка
		/// </summary>
		event ErrorEventHandler OnError;
	}
	/// <summary>
	/// Интерфейс сообщений
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2918")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface ISip2Answers
	{
		/// <summary>
		/// Первоначальная инициализация
		/// </summary>
		/// <param name="paramsFields">параметры</param>
		/// <returns>успешность инициализации</returns>
		bool Init(IField[] paramsFields);
		/// <summary>
		/// Список возможных комманд для ответа
		/// </summary>
		ISip2Command[] Commands { get; }
		/// <summary>
		/// Событие, если была ошибка
		/// </summary>
		event ErrorEventHandler OnError;
	}
}
