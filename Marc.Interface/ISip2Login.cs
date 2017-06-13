using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marc.Interface
{
	/// <summary>
	/// Интерфейс Входящего сообщения 'scLogin'(93)
	/// </summary>
	public interface ISip2LoginRequest : ISip2Request
	{
		/// <summary>
		/// алгоритм идент. польз.
		/// </summary>
		[Sip2Field(Number = 1)]
		Char UidAlgorithm { get; }
		/// <summary>
		/// алгоритм парол.
		/// </summary>
		[Sip2Field(Number = 2)]
		Char PwdAlgorithm { get; }
		/// <summary>
		/// идентификатор пользователя для входа
		/// </summary>
		[Sip2Field(Number = 3, Required = true, Identificator = "CN")]
		String LoginUserId { get; }
		/// <summary>
		/// пароль для входа
		/// </summary>
		[Sip2Field(Number = 4, Required = true, Identificator = "CO")]
		String LoginPassword { get; }
		/// <summary>
		/// пароль для входа
		/// </summary>
		[Sip2Field(Number = 5, Identificator = "CP")]
		String LocationCode { get; }

	}
	/// <summary>
	/// Интерфейс ответного сообщения 'acLoginResponse'(94)
	/// </summary>
	public interface ISip2LoginResponse : ISip2Response
	{
		/// <summary>
		/// разрешено
		/// </summary>
		[Sip2Field(Number = 1)]
		Char Ok { get; }
	}
	/// <summary>
	/// Интерфейс сообщения Login(93, 94)
	/// </summary>
	[Sip2Command(Sip2Request.scLogin, Sip2Response.acLoginResponse, Version = Sip2Version.v2_00)]
	public interface ISip2Login : ISip2Command
	{
		
	}
}
