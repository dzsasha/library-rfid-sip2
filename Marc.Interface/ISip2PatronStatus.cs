using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marc.Interface
{
	/// <summary>
	/// Запрос состояния абонента
	/// </summary>
	public interface ISip2PatronStatusRequest : ISip2Request
	{
		/// <summary>
		/// язык
		/// </summary>
		[Sip2Field(Number = 1, Length = 3)]
		String Language { get; }
		/// <summary>
		/// дата операции
		/// </summary>
		[Sip2Field(Number = 2)]
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
		
	}
	/// <summary>
	/// состояние абонента
	/// </summary>
	[Sip2Command(Sip2Request.scPatronStatusRequest, Sip2Response.acPatronStatusResponse)]
	public interface ISip2PatronStatus : ISip2Command
	{
		
	}
}
