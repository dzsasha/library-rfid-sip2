using System;
using System.Collections.Generic;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
{
	/// <summary>
	/// Интерфейс полей SIP2-протокола
	/// </summary>
	public interface ISip2Field : IField
	{
		/// <summary>
		/// Обязательное поле
		/// </summary>
		bool Required { get; }
		/// <summary>
		/// Идентификатор поля (если нужен)
		/// </summary>
		string Identificator { get; }
		/// <summary>
		/// Версия поля
		/// </summary>
		Sip2Version Version { get; }
		/// <summary>
		/// Длинна фиксированного поля
		/// </summary>
		int Length { get; }
	}
	/// <summary>
	/// Интерфейс типа команды
	/// </summary>
	/// <typeparam name="T">входящее/ответное сообщение</typeparam>
	public interface ISip2Cmd<out T>
	{
		/// <summary>
		/// Номер команды
		/// </summary>
		T Command { get; }
	}
	/// <summary>
	/// Интерфейс полей
	/// </summary>
	public interface ISip2Fields<out T> : ISip2Cmd<T>, IEnumerable<ISip2Field>, ICloneable
	{
		/// <summary>
		/// Проверка на правильность заполнения
		/// </summary>
		/// <param name="version">версия</param>
		/// <returns></returns>
		bool Validate(Sip2Version version);
		/// <summary>
		/// Десериализация полей
		/// </summary>
		/// <param name="str">входная строка</param>
		/// <param name="separator">разделитель полей переменной длинны</param>
		void FillFields(string str, Char separator);
		/// <summary>
		/// Сериализация полей
		/// </summary>
		/// <param name="separator">разделитель полей переменной длинны</param>
		/// <param name="debug">использовать отладку</param>
		/// <returns>ответная строка</returns>
		string ToString(Char separator, bool debug);
	}
	/// <summary>
	/// Интерфейс сообщения
	/// </summary>
	public interface ISip2Message : ICloneable
	{
		ISip2Fields<Sip2Request> Request { get; }
		/// <summary>
		/// Ответное сообщение
		/// </summary>
		ISip2Fields<Sip2Response> Response { get; }
		/// <summary>
		/// Версия
		/// </summary>
		Sip2Version Version { get; }
	}
}
