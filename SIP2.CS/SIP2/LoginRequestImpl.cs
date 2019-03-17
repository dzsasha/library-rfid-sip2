using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scLogin)]
    public class LoginRequestImpl : Sip2AnswerImpl, ILoginRequest {
        /// <summary>
        /// код места расположения
        /// </summary>
        [Sip2Field(5, Version = Sip2Version.V200, Identificator = "CP", Description = "код места расположения")]
        public string LocationCode { get; set; }
        /// <summary>
        /// пароль для входа
        /// </summary>
        [Sip2Field(4, Required = true, Version = Sip2Version.V200, Identificator = "CO", Description = "пароль для входа")]
        public string Password { get; set; }
        /// <summary>
        /// алгоритм парол.
        /// </summary>
        [Sip2Field(2, Length = 1, Version = Sip2Version.V200, Description = "алгоритм парол.")]
        public char PWDalgorihtm { get; set; }
        /// <summary>
        /// алгоритм идент. польз.
        /// </summary>
        [Sip2Field(1, Version = Sip2Version.V200, Length = 1, Description = "алгоритм идент. польз.")]
        public char UIDalgorithm { get; set; }
        /// <summary>
        /// идентификатор пользователя для входа
        /// </summary>
        [Sip2Field(3, Required = true, Version = Sip2Version.V200, Identificator = "CN", Description = "идентификатор пользователя для входа")]
        public string UserID { get; set; }
    }
}
