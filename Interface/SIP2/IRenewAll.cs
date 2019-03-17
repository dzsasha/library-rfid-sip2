using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Продлить все
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2939")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scRenewAll)]
    public interface IRenewAllRequest : ISip2Request {
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime date { get; }

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
        /// подтверждение взноса
        /// </summary>
        string FeeAcknowledged { get; }
    }

    /// <summary>
    /// Продлить все
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE293A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acRenewAll)]
    public interface IRenewAllResponse : ISip2ResponsePrint {
        /// <summary>
        /// разрешено
        /// </summary>
        bool Ok { get; set; }

        /// <summary>
        /// число возобновленных
        /// </summary>
        int RenewedCount { get; set; }

        /// <summary>
        /// число невозобновленных
        /// </summary>
        int UnRenewedCount { get; set; }

        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; set; }

        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; set; }

        /// <summary>
        /// возобновленных единиц
        /// </summary>
        string[] RenewedItems { get; set; }

        /// <summary>
        /// невозобновленных единиц
        /// </summary>
        string[] UnRenewedItems { get; set; }
    }

    /// <summary>
    /// Продлить все
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE293B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scRenewAll, response = Sip2Response.acRenewAll)]
    public interface IRenewAll : ISip2Command<IRenewAllRequest, IRenewAllResponse> { }

}
