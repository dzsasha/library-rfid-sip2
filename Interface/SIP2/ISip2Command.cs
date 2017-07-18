using System.IO;
using System.Runtime.InteropServices;

namespace IS.Interface.SIP2
{
	/// <summary>
	/// Интерфейс команд SIP2-протокола
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2914")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ISip2Command
	{
		/// <summary>
		/// Номер входящего сообщения
		/// </summary>
		Sip2Request Request { get; }
		/// <summary>
		/// Номер ответного сообщения
		/// </summary>
		Sip2Response Response { get; }
		/// <summary>
		/// Выполнить входящее сообщение
		/// </summary>
		/// <param name="request">набор полей входящего сообщения</param>
		/// <param name="response">набор полей ответного сообщения</param>
		/// <returns>успешность выполнения</returns>
		bool Execute(IField[] request, ref IField[] response);
		/// <summary>
		/// Событие, если была ошибка
		/// </summary>
		event ErrorEventHandler OnError;
	}
	/// <summary>
	/// Интерфейс объекта сообщений
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2915")]
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
		/// Поддерживаемая версия сервера
		/// </summary>
		Sip2Version Version { get; }
		/// <summary>
		/// Событие, если была ошибка
		/// </summary>
		event ErrorEventHandler OnError;
	}
}
