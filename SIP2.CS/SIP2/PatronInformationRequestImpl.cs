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
        public class SummarySerializeImpl : Sip2SerializeImpl {
            public override object Deserialize(PropertyDescriptor prop, string value) {
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
        [Sip2Field(2, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// начальная единица
        /// </summary>
        [Sip2Field(Identificator = "BQ", Version = Sip2Version.V200, Description = "конечная единица", Order = 10)]
        public string EndItem { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 4)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(1, 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 5)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(Identificator = "AD", Description = "пароль абонента", Order = 7)]
        public string PatronPassword { get; set; }
        /// <summary>
        /// конечная единица
        /// </summary>
        [Sip2Field(Identificator = "BP", Version = Sip2Version.V200, Description = "начальная единица", Order = 8)]
        public string StartItem { get; set; }
        /// <summary>
        /// сводка
        /// </summary>
        [Sip2Field(3, 10, Required = true, Version = Sip2Version.V200, SerializeType = typeof(SummarySerializeImpl), Description = "сводка")]
        public bool[] Summary { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(Identificator = "AC", Description = "окончательный пароль", Order = 6)]
        public string TerminalPassword { get; set; }
    }
}
