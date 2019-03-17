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
        [Sip2Field(1, Required = true, Description = "дата операции", Length = 18)]
        public DateTime Date { get; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(2, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(3, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(4, Required = true, Identificator = "AC", Description = "окончательный пароль")]
        public string TerminalPassword { get; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AD", Description = "пароль абонента")]
        public string PatronPassword { get; }
    }
}
