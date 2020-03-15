using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Входное сообщение (PatronInformation: 64)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scPatronStatus)]
    public interface IPatronInformationRequest : ISip2Request {
        /// <summary>
        /// язык
        /// </summary>
        string Language { get; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// сводка
        /// </summary>
        bool[] Summary { get; }
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
        /// <summary>
        /// начальная единица
        /// </summary>
        string StartItem { get; }
        /// <summary>
        /// конечная единица
        /// </summary>
        string EndItem { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acPatronStatus)]
    public interface IPatronInformationResponse : ISip2ResponsePrint {
        /// <summary>
        /// Статус абонента
        /// </summary>
        ushort PatronStatus { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        string Language { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// число удерживаемых единиц
        /// </summary>
        int HoldItemsCount { get; set; }
        /// <summary>
        /// число просроченных единиц
        /// </summary>
        int OverDueItemsCount { get; set; }
        /// <summary>
        /// число оплаченных единиц
        /// </summary>
        int ChargedItemsCount { get; set; }
        /// <summary>
        /// число проштрафленных единиц
        /// </summary>
        int FineItemsCount { get; set; }
        /// <summary>
        /// число отозванных единиц
        /// </summary>
        int ReCallItemsCount { get; set; }
        /// <summary>
        /// число недоступных удержаний
        /// </summary>
        int UnAvailableItemsCount { get; set; }
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
        /// ограничение удерживаемых единиц
        /// </summary>
        int HoldItemsLimit { get; set; }
        /// <summary>
        /// ограничение просроченных единиц
        /// </summary>
        int OverDueItemsLimit { get; set; }
        /// <summary>
        /// ограничение оплачиваемых единиц
        /// </summary>
        int ChargedItemsLimit { get; set; }
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
        /// <summary>
        /// ограничение взноса
        /// </summary>
        double FeeLimit { get; set; }
        /// <summary>
        /// удерживаемых единиц
        /// </summary>
        string[] HoldItems { get; set; }
        /// <summary>
        /// просроченных единиц
        /// </summary>
        string[] OverDueItems { get; set; }
        /// <summary>
        /// оплаченных единиц
        /// </summary>
        string[] ChargedItems { get; set; }
        /// <summary>
        /// проштрафленных единиц
        /// </summary>
        string[] FineItems { get; set; }
        /// <summary>
        /// отозванных единиц
        /// </summary>
        string[] RecallItems { get; set; }
        /// <summary>
        /// недоступных удерживаемых единиц
        /// </summary>
        string[] UnAvailableItems { get; set; }
        /// <summary>
        /// адрес
        /// </summary>
        string HomeAddress { get; set; }
        /// <summary>
        /// адрес электронной почты
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// домашний телефон
        /// </summary>
        string HomePhoneNumber { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scPatronInformation, response = Sip2Response.acPatronInformation)]
    public interface IPatronInformation : ISip2Command<IPatronInformationRequest, IPatronInformationResponse> {

    }
}
