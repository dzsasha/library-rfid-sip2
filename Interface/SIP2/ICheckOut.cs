using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2930")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scCheckout)]
    public interface ICheckOutRequest : ISip2Request {
        /// <summary>
        /// политика возобновления системы SC
        /// </summary>
        bool RenewalPolicy { get; }
        /// <summary>
        /// отсутствие блокировки
        /// </summary>
        bool NoBlock { get; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// дата возврата
        /// </summary>
        DateTime DueDate { get; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        string PatronIdentifier { get; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        string ItemIdentifier { get; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        string TerminalPassword { get; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        string ItemProperties { get; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        string PatronPassword { get; }
        /// <summary>
        /// подтверждение взноса
        /// </summary>
        string FeeAcknowledged { get; }
        /// <summary>
        /// отмена
        /// </summary>
        bool Cancel { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2931")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acCheckout)]
    public interface ICheckOutResponse : ISip2ResponsePrint {
        /// <summary>
        /// разрешено
        /// </summary>
        bool Ok { get; set; }
        /// <summary>
        /// возобновление разрешено
        /// </summary>
        bool RenewalOk { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        bool MagneticMedia { get; set; }
        /// <summary>
        /// размагничивание
        /// </summary>
        bool Desensitize { get; set; }
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
        /// идентификатор единицы
        /// </summary>
        string ItemIdentifier { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        string TitleIdentifier { get; set; }
        /// <summary>
        /// дата возврата
        /// </summary>
        DateTime DueDate { get; set; }
        /// <summary>
        /// тип взноса
        /// </summary>
        Sip2FeeType FeeType { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        bool SecurityInhibit { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        string CurrencyType { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        double FeeAmount { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        string ItemProperties { get; set; }
        /// <summary>
        /// идентификатор операции
        /// </summary>
        int TransactionId { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2932")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scCheckout, response = Sip2Response.acCheckout)]
    public interface ICheckOut : ISip2Command<ICheckOutRequest, ICheckOutResponse> {

    }

}
