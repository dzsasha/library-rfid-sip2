using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scEndPatronSession)]
    public class EndPatronSessionRequestImpl : Sip2AnswerImpl, IEndPatronSessionRequest {
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(1, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 2)]
        public string InstitutionId { get; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 3)]
        public string PatronIdentifier { get; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AC", Description = "окончательный пароль", Order = 4)]
        public string TerminalPassword { get; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AD", Description = "пароль абонента", Order = 5)]
        public string PatronPassword { get; }
    }
}
