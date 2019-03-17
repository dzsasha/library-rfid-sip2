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
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2933")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scEndPatronSession)]
    public interface IEndPatronSessionRequest : ISip2Request {
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
    /// завершение сеанса
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2934")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scEndPatronSession)]
    public interface IEndPatronSessionResponse : ISip2ResponsePrint {
        /// <summary>
        /// завершение сеанса
        /// </summary>
        bool EndSession { get; set; }
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
    }
    /// <summary>
    /// завершение сеанса
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2935")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scEndPatronSession, response = Sip2Response.acEndSession)]
    public interface IEndPatronSession : ISip2Command<IEndPatronSessionRequest, IEndPatronSessionResponse> {
    }
}
