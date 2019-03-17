using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// завершение сеанса
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2936")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scItemStatusUpdate)]
    public interface IItemStatusUpdateRequest : ISip2Request {
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime date { get; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; }
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
    }
    /// <summary>
    /// завершение сеанса
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2937")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scItemStatusUpdate)]
    public interface IItemStatusUpdateResponse : ISip2ResponsePrint {
        /// <summary>
        /// свойства единицы
        /// </summary>
        bool ItemPropertiesOk { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime date { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        string ItemIdentifier { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        string TitleIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        string ItemProperties { get; set; }
    }
    /// <summary>
    /// завершение сеанса
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2938")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scItemStatusUpdate, response = Sip2Response.acItemStatusUpdate)]
    public interface IItemStatusUpdate : ISip2Command<IItemStatusUpdateRequest, IItemStatusUpdateResponse> {
    }
}
