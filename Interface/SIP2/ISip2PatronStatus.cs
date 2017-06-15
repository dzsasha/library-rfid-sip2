using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformSystema.Interface.SIP2
{
	/// <summary>
	/// Запрос состояния абонента
	/// </summary>
	public interface ISip2PatronStatusRequest : ISip2Request
	{
		/// <summary>
		/// язык
		/// </summary>
		[Sip2Field(Number = 1, Length = 3, Required = true)]
		String Language { get; }
		/// <summary>
		/// дата операции
		/// </summary>
		[Sip2Field(Number = 2, Required = true)]
		DateTime TransactionDate { get; }
		/// <summary>
		/// идентификатор учреждения
		/// </summary>
		[Sip2Field(Number = 3, Identificator = "AO", Required = true)]
		String InstitutionId { get; }
		/// <summary>
		/// идентификатор абонента
		/// </summary>
		[Sip2Field(Number = 4, Identificator = "AA", Required = true)]
		String PatronIdentifier { get; }
		/// <summary>
		/// окончательный пароль
		/// </summary>
		[Sip2Field(Number = 5, Identificator = "AC", Required = true)]
		String TerminalPassword { get; }
		/// <summary>
		/// пароль абонента
		/// </summary>
		[Sip2Field(Number = 6, Identificator = "AD", Required = true)]
		String PatronPassword { get; }
	}

	/// <summary>
	/// Ответ о состоянии абонента
	/// </summary>
	public interface ISip2PatronStatusResponse : ISip2Response
	{
		/// <summary>
		/// состояние абонента
		/// </summary>
		[Sip2Field(Number = 1, Length = 14, Required = true)]
		String PatronStatus { get; }

		/// <summary>
		/// язык
		/// </summary>
		[Sip2Field(Number = 2, Length = 3, Required = true)]
		String Language { get; }

		/// <summary>
		/// дата операции
		/// </summary>
		[Sip2Field(Number = 3, Required = true)]
		DateTime TransactionDate { get; }

		/// <summary>
		/// идентификатор учреждения
		/// </summary>
		[Sip2Field(Number = 4, Identificator = "AO", Required = true)]
		String InstitutionId { get; }

		/// <summary>
		/// идентификатор абонента
		/// </summary>
		[Sip2Field(Number = 5, Identificator = "AA", Required = true)]
		String PatronIdentifier { get; }

		/// <summary>
		/// идентификатор абонента
		/// </summary>
		[Sip2Field(Number = 6, Identificator = "AE", Required = true)]
		String PersonalName { get; }
		/// <summary>
		/// действительный абонент
		/// </summary>
		[Sip2Field(Identificator = "BL", Version = Sip2Version.V200)]
		Boolean ValidPatron { get; }
		/// <summary>
		/// действительный пароль абонента
		/// </summary>
		[Sip2Field(Identificator = "CQ", Version = Sip2Version.V200)]
		Boolean ValidPatronPassword { get; }
		/// <summary>
		/// валюта
		/// </summary>
		[Sip2Field(Identificator = "BH", Version = Sip2Version.V200, Length = 3)]
		String CurrencyType { get; }
		/// <summary>
		/// сумма взноса (Сумма взносов, подлежащих уплате этим абонентом.)
		/// </summary>
		[Sip2Field(Identificator = "BV", Version = Sip2Version.V200)]
		Double FeeAmount { get; }
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
	/// состояние абонента
	/// </summary>
	[Sip2Command(Sip2Request.scPatronStatusRequest, Sip2Response.acPatronStatusResponse)]
	public interface ISip2PatronStatus : ISip2Command
	{
		
	}
}
