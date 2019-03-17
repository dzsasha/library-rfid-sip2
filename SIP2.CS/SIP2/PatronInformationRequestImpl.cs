using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scPatronInformation)]
    public class PatronInformationRequestImpl : Sip2AnswerImpl, IPatronInformationRequest {
        public class SummarySerializeImpl : ISip2Deserialize {
            public object Deserialize(PropertyDescriptor prop, string value) {
                List<bool> result = new List<bool>();
                foreach (char c in value) {
                    result.Add(c.Equals('Y'));
                }
                return result.ToArray();
            }
        }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(2, Required = true, Description = "дата операции", Length = 18)]
        public DateTime Date { get; set; }
        /// <summary>
        /// начальная единица
        /// </summary>
        [Sip2Field(9, Identificator = "BQ", Version = Sip2Version.V200, Description = "конечная единица")]
        public string EndItem { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(4, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(1, Length = 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(7, Identificator = "AD", Description = "пароль абонента")]
        public string PatronPassword { get; set; }
        /// <summary>
        /// конечная единица
        /// </summary>
        [Sip2Field(8, Identificator = "BP", Version = Sip2Version.V200, Description = "начальная единица")]
        public string StartItem { get; set; }
        /// <summary>
        /// сводка
        /// </summary>
        [Sip2Field(3, Required = true, Length = 10, Version = Sip2Version.V200, DeserializeType = typeof(SummarySerializeImpl), Description = "сводка")]
        public bool[] Summary { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(6, Identificator = "AC", Description = "окончательный пароль")]
        public string TerminalPassword { get; set; }
    }
}
