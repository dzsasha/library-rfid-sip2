using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scRenewAll)]
    public class RenewAllRequestImpl : Sip2AnswerImpl, IRenewAllRequest {
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(1, Required = true, Length = 18, Description = "дата операции")]
        public DateTime date { get; set; }

        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(2, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }

        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(3, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AC", Description = "окончательный пароль")]
        public string TerminalPassword { get; set; }

        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(4, Identificator = "AD", Description = "пароль абонента")]
        public string PatronPassword { get; set; }

        /// <summary>
        /// подтверждение взноса
        /// </summary>
        [Sip2Field(6, Version = Sip2Version.V200, Identificator = "BO", Description = "подтверждение взноса")]
        public string FeeAcknowledged { get; set; }
    }
}
