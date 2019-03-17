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
        [Sip2Field(99, Identificator = "AG", Description = "печатная строка")]
        public string PrintLine { get; set; }
        /// <summary>
        /// экранное сообщение
        /// </summary>
        [Sip2Field(98, Identificator = "AF", Description = "экранное сообщение")]
        public string ScreenMessage { get; set; }
    }
}
