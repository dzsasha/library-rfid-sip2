using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace InformSystema.Interface.SIP2
{
	/// <summary>
	/// Система SC отправляет в ААС следующие командные сообщения
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2911")]
	[ComVisible(true)]
	[DataContract(Namespace = "http://informsystema.com/marc/service/")]
	public enum Sip2Request
	{
		/// <summary>
		/// Ошибочная команда
		/// </summary>
		scUnknown = -1,
		/// <summary>
		/// Запрос состояния абонента
		/// </summary>
		scPatronStatusRequest = 23,
		/// <summary>
		/// Получение
		/// </summary>
		scCheckout = 11,
		/// <summary>
		/// Возврат
		/// </summary>
		scCheckin = 9,
		/// <summary>
		/// Блокировка абонента
		/// </summary>
		scBlockPatron = 1,
		/// <summary>
		/// Состояние системы SC
		/// </summary>
		scSCStatus = 99,
		/// <summary>
		/// Повторная отправка запроса ААС
		/// </summary>
		scRequestACSResend = 97,
		/// <summary>
		/// Вход
		/// </summary>
		scLogin = 93,
		/// <summary>
		/// Сведения об абоненте
		/// </summary>
		scPatronInformation = 63,
		/// <summary>
		/// Завершение сеанса абонента
		/// </summary>
		scEndPatronSession = 35,
		/// <summary>
		/// Уплата взноса
		/// </summary>
		scFeePaid = 37,
		/// <summary>
		/// Сведения о единице
		/// </summary>
		scItemInformation = 17,
		/// <summary>
		/// Обновление состояния единицы
		/// </summary>
		scItemStatusUpdate = 19,
		/// <summary>
		/// Активация абонента
		/// </summary>
		scPatronEnable = 25,
		/// <summary>
		/// Удержание
		/// </summary>
		scHold = 15,
		/// <summary>
		/// Возобновление
		/// </summary>
		scRenew = 29,
		/// <summary>
		/// Возобновление всего
		/// </summary>
		scRenewAll = 65
	}
	/// <summary>
	/// ААС отправляет в систему SC в следующие ответные сообщения
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2912")]
	[ComVisible(true)]
	[DataContract(Namespace = "http://informsystema.com/marc/service/")]
	public enum Sip2Response
	{
		/// <summary>
		/// Ответ о состоянии абонента
		/// </summary>
		acPatronStatusResponse = 24,
		/// <summary>
		/// Ответ о получении
		/// </summary>
		acCheckoutResponse = 12,
		/// <summary>
		/// Ответ о возврате
		/// </summary>
		acCheckinResponse = 10,
		/// <summary>
		/// Состояние ААС
		/// </summary>
		acACSStatus = 98,
		/// <summary>
		/// Повторная отправка запроса системы SC
		/// </summary>
		acRequestSCResend = 96,
		/// <summary>
		/// Ответ о входе
		/// </summary>
		acLoginResponse = 94,
		/// <summary>
		/// Ответ со сведениями об абоненте
		/// </summary>
		acPatronInformationResponse = 64,
		/// <summary>
		/// Ответ о завершении сеанса
		/// </summary>
		acEndSessionResponse = 36,
		/// <summary>
		/// Ответ об уплате взноса
		/// </summary>
		acFeePaidResponse = 38,
		/// <summary>
		/// Ответ со сведениями о единице
		/// </summary>
		acItemInformationResponse = 18,
		/// <summary>
		/// Ответ об обновлении состояния единицы
		/// </summary>
		acItemStatusUpdateResponse = 20,
		/// <summary>
		/// Ответ об активации абонента
		/// </summary>
		acPatronEnableResponse = 26,
		/// <summary>
		/// Ответ об удержании
		/// </summary>
		acHoldResponse = 16,
		/// <summary>
		/// Ответ о возобновлении
		/// </summary>
		acRenewResponse = 30,
		/// <summary>
		/// Ответ о возобновлении всего
		/// </summary>
		acRenewAllResponse = 66
	}
	/// <summary>
	/// Версия SIP2-протокола
	/// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2914")]
	[ComVisible(true)]
	[DataContract(Namespace = "http://informsystema.com/marc/service/")]
	public enum Sip2Version
	{
		/// <summary>
		/// Поддержка версии 1.00
		/// </summary>
		V100 = 0x1,
		/// <summary>
		/// Поддержка версии 2.00
		/// </summary>
		V200 = 0x2
	}
}
