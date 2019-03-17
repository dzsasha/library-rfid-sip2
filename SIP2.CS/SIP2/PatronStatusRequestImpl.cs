using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scPatronStatus)]
    public class PatronStatusRequestImpl : Sip2AnswerImpl, IPatronStatusRequest {
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(2, Required = true, Description = "дата операции", Length = 18)]
        public DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(3, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(1, Length = 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(4, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(6, Required = true, Identificator = "AD", Description = "пароль абонента")]
        public string PatronPassword { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AC", Description = "окончательный пароль")]
        public string TerminalPassword { get; set; }
    }
}
