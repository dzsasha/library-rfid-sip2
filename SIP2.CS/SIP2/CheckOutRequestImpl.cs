using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scCheckout)]
    public class CheckOutRequestImpl : Sip2AnswerImpl, ICheckOutRequest {
        /// <summary>
        /// отмена
        /// </summary>
        [Sip2Field(12, Version = Sip2Version.V200, Identificator = "BI", Description = "отмена")]
        public bool Cancel { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, Required = true, Length = 18, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// дата возврата
        /// </summary>
        [Sip2Field(4, Required = true, Length = 18, Description = "дата возврата")]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// подтверждение взноса
        /// </summary>
        [Sip2Field(11, Version = Sip2Version.V200, Identificator = "BO", Description = "подтверждение взноса")]
        public string FeeAcknowledged { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(7, Required = true, Identificator = "AB", Description = "идентификатор единицы")]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(9, Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы")]
        public string ItemProperties { get; set; }
        /// <summary>
        /// отсутствие блокировки
        /// </summary>
        [Sip2Field(2, Required = true, Length = 1, Description = "отсутствие блокировки")]
        public bool NoBlock { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(6, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(7, Version = Sip2Version.V200, Identificator = "AD", Description = "пароль абонента")]
        public string PatronPassword { get; set; }
        /// <summary>
        /// политика возобновления системы SC
        /// </summary>
        [Sip2Field(1, Required = true, Length = 1, Description = "политика возобновления системы SC")]
        public bool RenewalPolicy { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(8, Required = true, Identificator = "AC", Description = "окончательный пароль")]
        public string TerminalPassword { get; set; }
    }
}
