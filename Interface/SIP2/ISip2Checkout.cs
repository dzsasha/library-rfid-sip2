using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformSystema.Interface.SIP2
{
	/// <summary>
	/// Выдача
	/// </summary>
	public interface ISip2CheckoutRequest : ISip2Request
	{
		/// <summary>
		/// политика возобновления системы SC
		/// </summary>
		[Sip2Field(Number = 1, Required = true)]
		Boolean SCRenewalPolicy { get; }
		/// <summary>
		/// отсутствие блокировки
		/// </summary>
		[Sip2Field(Number = 2, Required = true)]
		Boolean NoBlock { get; }
		/// <summary>
		/// дата операции
		/// </summary>
		[Sip2Field(Number = 3, Required = true)]
		DateTime TransactionDate { get; }
		/// <summary>
		/// дата возврата
		/// </summary>
		[Sip2Field(Number = 4, Required = true)]
		DateTime NbDueDate { get; }
		/// <summary>
		/// идентификатор учреждения
		/// </summary>
		[Sip2Field(Number = 5, Identificator = "AO", Required = true)]
		String InstitutionId { get; }
		/// <summary>
		/// идентификатор абонента
		/// </summary>
		[Sip2Field(Number = 6, Identificator = "AA", Required = true)]
		String PatronIdentifier { get; }
		/// <summary>
		/// идентификатор единицы
		/// </summary>
		[Sip2Field(Number = 7, Identificator = "AB", Required = true)]
		String ItemIdentifier { get; }
		/// <summary>
		/// окончательный пароль
		/// </summary>
		[Sip2Field(Number = 8, Identificator = "AC", Required = true)]
		String TerminalPassword { get; }
		/// <summary>
		/// свойства единицы
		/// </summary>
		[Sip2Field(Identificator = "CH", Version = Sip2Version.V200)]
		String ItemProperties { get; }
		/// <summary>
		/// пароль абонента
		/// </summary>
		[Sip2Field(Identificator = "AD", Version = Sip2Version.V200)]
		String PatronPassword { get; }
		/// <summary>
		/// подтверждение взноса
		/// </summary>
		[Sip2Field(Identificator = "BO", Version = Sip2Version.V200)]
		Boolean FeeAcknowledged { get; }
		/// <summary>
		/// отмена 
		/// </summary>
		[Sip2Field(Identificator = "BI",Version = Sip2Version.V200)]
		Boolean Cancel { get; }
	}
	/// <summary>
	/// Ответ о выдаче
	/// </summary>
	public interface ISip2CheckoutResponse : ISip2Response
	{
		/// <summary>
		/// разрешено
		/// </summary>
		[Sip2Field(Number = 1, Required = true)]
		Boolean Ok { get; }
		/// <summary>
		/// возобновление разрешено
		/// </summary>
		[Sip2Field(Number = 2, Required = true)]
		Boolean RenewalOk { get; }
		/// <summary>
		/// магнитный носитель
		/// </summary>
		[Sip2Field(Number = 3, Required = true)]
		Boolean MagneticMedia  { get; }
		/// <summary>
		/// размагничивание
		/// </summary>
		[Sip2Field(Number = 4, Required = true)]
		Boolean Desensitize { get; }
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
		/// идентификатор абонента
		/// </summary>
		[Sip2Field(Number = 7, Identificator = "AA", Required = true)]
		String PatronIdentifier { get; }
		/// <summary>
		/// идентификатор единицы
		/// </summary>
		[Sip2Field(Number = 8, Identificator = "AB", Required = true)]
		String ItemIdentifier { get; }
		/// <summary>
		/// идентификатор названия
		/// </summary>
		[Sip2Field(Number = 9, Identificator = "AJ", Required = true)]
		String TitleIdentifier { get; }
		/// <summary>
		/// дата возврата
		/// </summary>
		[Sip2Field(Number = 10, Required = true)]
		DateTime DueDate { get; }
		/// <summary>
		/// тип взноса
		/// </summary>
		[Sip2Field(Identificator = "BT", Length = 2, Version = Sip2Version.V200)]
		String FeeType { get; }
		/// <summary>
		/// блокировка безопасности
		/// </summary>
		[Sip2Field(Identificator = "CI", Version = Sip2Version.V200)]
		Boolean SecurityInhibit { get; }
		/// <summary>
		/// тип взноса
		/// </summary>
		[Sip2Field(Identificator = "BH", Length = 3, Version = Sip2Version.V200)]
		String CurrencyType { get; }
		/// <summary>
		/// сумма взноса (Сумма взносов, подлежащих уплате этим абонентом.)
		/// </summary>
		[Sip2Field(Identificator = "BV", Version = Sip2Version.V200)]
		Double FeeAmount { get; }
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
		/// идентификатор операции
		/// </summary>
		[Sip2Field(Identificator = "BK", Version = Sip2Version.V200)]
		String TransactionId  { get; }
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
	/// Выдача
	/// </summary>
	[Sip2Command(Sip2Request.scCheckout, Sip2Response.acCheckoutResponse)]
	public interface ISip2Checkout : ISip2Command
	{}
}
