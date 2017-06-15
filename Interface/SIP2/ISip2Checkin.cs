using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformSystema.Interface.SIP2
{
	/// <summary>
	/// выдача
	/// </summary>
	public interface ISip2CheckinRequest : ISip2Request
	{
		/// <summary>
		/// отсутствие блокировки
		/// </summary>
		[Sip2Field(Number = 1, Required = true)]
		Boolean NoBlock { get; }
		/// <summary>
		/// дата операции
		/// </summary>
		[Sip2Field(Number = 2, Required = true)]
		DateTime TransactionDate { get; }
		/// <summary>
		/// дата возврата
		/// </summary>
		[Sip2Field(Number = 3, Required = true)]
		DateTime ReturnDate { get; }
		/// <summary>
		/// текущее месторасположение
		/// </summary>
		[Sip2Field(Number = 4, Required = true, Identificator = "AP")]
		String CurrentLocation { get; }
		/// <summary>
		/// идентификатор учреждения
		/// </summary>
		[Sip2Field(Number = 5, Identificator = "AO", Required = true)]
		String InstitutionId { get; }
		/// <summary>
		/// идентификатор единицы
		/// </summary>
		[Sip2Field(Number = 6, Identificator = "AB", Required = true)]
		String ItemIdentifier { get; }
		/// <summary>
		/// окончательный пароль
		/// </summary>
		[Sip2Field(Number = 7, Identificator = "AC", Required = true)]
		String TerminalPassword { get; }
		/// <summary>
		/// свойства единицы
		/// </summary>
		[Sip2Field(Identificator = "CH", Version = Sip2Version.V200)]
		String ItemProperties { get; }
		/// <summary>
		/// отмена 
		/// </summary>
		[Sip2Field(Identificator = "BI", Version = Sip2Version.V200)]
		Boolean Cancel { get; }
	}
	/// <summary>
	/// Ответ о выдаче
	/// </summary>
	public interface ISip2CheckinResponse : ISip2Response
	{
		/// <summary>
		/// разрешено
		/// </summary>
		[Sip2Field(Number = 1, Required = true)]
		Boolean Ok { get; }
		/// <summary>
		/// повторное намагничивание 
		/// </summary>
		[Sip2Field(Number = 2, Required = true)]
		Boolean Resensitize { get; }
		/// <summary>
		/// магнитный носитель
		/// </summary>
		[Sip2Field(Number = 3, Required = true)]
		Boolean MagneticMedia { get; }
		/// <summary>
		/// сигнализация
		/// </summary>
		[Sip2Field(Number = 4, Required = true)]
		Boolean Alert { get; }
		/// <summary>
		/// дата операции
		/// </summary>
		[Sip2Field(Number = 5, Required = true)]
		DateTime TransactionDate { get; }
		/// <summary>
		/// идентификатор учреждения
		/// </summary>
		[Sip2Field(Number = 6, Identificator = "AO", Required = true)]
		String InstitutionId { get; }
		/// <summary>
		/// идентификатор единицы
		/// </summary>
		[Sip2Field(Number = 7, Identificator = "AB", Required = true)]
		String ItemIdentifier { get; }
		/// <summary>
		/// постоянное месторасположение
		/// </summary>
		[Sip2Field(Number = 8, Identificator = "AQ", Required = true)]
		String PermanentLocation { get; }
		/// <summary>
		/// идентификатор названия
		/// </summary>
		[Sip2Field(Number = 9, Identificator = "AJ")]
		String TitleIdentifier { get; }
		/// <summary>
		/// идентификатор названия
		/// </summary>
		[Sip2Field(Identificator = "CL", Version = Sip2Version.V200)]
		String SortBin { get; }
		/// <summary>
		/// идентификатор абонента
		/// </summary>
		[Sip2Field(Identificator = "AA", Version = Sip2Version.V200)]
		String PatronIdentifier { get; }
		/// <summary>
		/// тип взноса
		/// </summary>
		[Sip2Field(Identificator = "CK", Length = 3, Version = Sip2Version.V200)]
		String MediaType { get; }
		/// <summary>
		/// свойства единицы
		/// </summary>
		[Sip2Field(Identificator = "CH", Version = Sip2Version.V200)]
		String ItemProperties { get; }
		/// <summary>
		/// экранное сообщение
		/// </summary>
		[Sip2Field(Identificator = "AF")]
		String ScreenMessage { get; }
		/// <summary>
		/// печатная строка
		/// </summary>
		[Sip2Field(Identificator = "AG")]
		String PrintLine { get; }
	}
	/// <summary>
	/// Команда выдачи
	/// </summary>
	[Sip2Command(Sip2Request.scCheckin, Sip2Response.acCheckinResponse)]
	public interface ISip2Checkin : ISip2Command
	{
		
	}
}
