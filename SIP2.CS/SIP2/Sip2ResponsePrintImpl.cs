using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    public class Sip2ResponsePrintImpl : Sip2AnswerImpl, ISip2ResponsePrint {
        /// <summary>
        /// печатная строка
        /// </summary>
        [Sip2Field(Identificator = "AG", Description = "печатная строка", Order = 99)]
        public string PrintLine { get; set; }
        /// <summary>
        /// экранное сообщение
        /// </summary>
        [Sip2Field(Identificator = "AF", Description = "экранное сообщение", Order = 98)]
        public string ScreenMessage { get; set; }
    }
}
