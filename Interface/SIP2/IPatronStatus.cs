using System;
using System.Runtime.InteropServices;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Статус абонента
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE291C")]
    [ComVisible(true)]
    public enum EPatronStatus {
        /// <summary>
        /// права оплаты отклонены
        /// </summary>
        PaymentRule = 0x0001,
        /// <summary>
        /// права возобновления отклонены 
        /// </summary>
        OfRenewal = 0x0002,
        /// <summary>
        /// права отзыва отклонены
        /// </summary>
        Callable = 0x0004,
        /// <summary>
        /// права удержания отклонены
        /// </summary>
        Lien = 0x0008,
        /// <summary>
        /// указанная карточка утрачена
        /// </summary>
        CardIsLost = 0x0010,
        /// <summary>
        /// слишком много оплаченных единиц
        /// </summary>
        ManyPaidUnits = 0x0020,
        /// <summary>
        /// слишком много просроченных единиц
        /// </summary>
        ManyOverdueItems = 0x0040,
        /// <summary>
        /// слишком много возобновлений
        /// </summary>
        ManyRenewals = 0x0080,
        /// <summary>
        /// слишком много востребованных единиц возвращено
        /// </summary>
        AfterItemsReturned = 0x0100,
        /// <summary>
        /// слишком много единиц утрачено
        /// </summary>
        ManyUnitsLost = 0x0200,
        /// <summary>
        /// слишком большой неуплаченный штраф
        /// </summary>
        MuchUnpaidFine = 0x0400,
        /// <summary>
        /// слишком большой неуплаченный взнос
        /// </summary>
        LargeOutstandingPayment = 0x0800,
        /// <summary>
        /// просроченный отзыв
        /// </summary>
        OverdueReview = 0x1000,
        /// <summary>
        /// начислено слишком много взносов за единицы
        /// </summary>
        ManyFeesForUnits = 0x2000
    }
    /// <summary>
    /// Входное сообщение (PatronStatus: 23)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE291E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scPatronStatus)]
    public interface IPatronStatusRequest : ISip2Request {
        /// <summary>
        /// язык
        /// </summary>
        string Language { get; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        string PatronIdentifier { get; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        string TerminalPassword { get; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        string PatronPassword { get; }
    }
    /// <summary>
    /// Выходящее сообщение (PatronStatus: 24)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE291F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acPatronStatus)]
    public interface IPatronStatusResponse : ISip2ResponsePrint {
        /// <summary>
        /// Статус абонента
        /// </summary>
        byte[] PatronStatus { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        string Language { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        string PatronIdentifier { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        string PersonalName { get; set; }
        /// <summary>
        /// действительный абонент
        /// </summary>
        bool ValidPatron { get; set; }
        /// <summary>
        /// действительный пароль абонента
        /// </summary>
        bool ValidPatronPassword { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        string CurrencyType { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        double FeeAmount { get; set; }
    }
    /// <summary>
    /// Интерфейс команды статуса (ACSStatus: 98)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2920")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scPatronStatus, response = Sip2Response.acPatronStatus)]
    public interface IPatronStatus : ISip2Command<IPatronStatusRequest, IPatronStatusResponse> {

    }
}
