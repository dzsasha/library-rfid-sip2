using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acEndSession)]
    public class EndPatronSessionResponseImpl : Sip2ResponsePrintImpl, IEndPatronSessionResponse {
        /// <summary>
        /// завершение сеанса
        /// </summary>
        [Sip2Field(1, Required = true, Version = Sip2Version.V200, Default = true, Description = "завершение сеанса")]
        public bool EndSession { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(2, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(3, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(4, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
    }
}
