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
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scLogin)]
    public interface ILoginRequest : ISip2Request {
        /// <summary>
        /// алгоритм идент. польз.
        /// </summary>
        char UIDalgorithm { get; }
        /// <summary>
        /// алгоритм парол.
        /// </summary>
        char PWDalgorihtm { get; }
        /// <summary>
        /// идентификатор пользователя для входа
        /// </summary>
        string UserID { get; }
        /// <summary>
        /// пароль для входа
        /// </summary>
        string Password { get; }
        /// <summary>
        /// код места расположения
        /// </summary>
        string LocationCode { get; }
    }
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(response = Sip2Response.acLogin)]
    public interface ILoginResponse : ISip2Response {
        /// <summary>
        /// разрешено
        /// </summary>
        bool Ok { get; set; }
    }
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scLogin, response = Sip2Response.acLogin)]
    public interface ILogin : ISip2Command<ILoginRequest, ILoginResponse> { }
}
