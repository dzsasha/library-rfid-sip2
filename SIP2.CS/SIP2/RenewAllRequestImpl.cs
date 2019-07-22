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
        [Sip2Field(1, 18, Required = true, Description = "дата операции")]
        public DateTime date { get; set; }

        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 2)]
        public string InstitutionId { get; set; }

        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 3)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AC", Description = "окончательный пароль", Order = 5)]
        public string TerminalPassword { get; set; }

        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(Identificator = "AD", Description = "пароль абонента", Order = 4)]
        public string PatronPassword { get; set; }

        /// <summary>
        /// подтверждение взноса
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "BO", Description = "подтверждение взноса", Order = 6)]
        public string FeeAcknowledged { get; set; }
    }
}
