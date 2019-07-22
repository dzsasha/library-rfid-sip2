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
        [Sip2Field(Version = Sip2Version.V200, Identificator = "BI", Description = "отмена", Order = 12)]
        public bool Cancel { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// дата возврата
        /// </summary>
        [Sip2Field(4, 18, Required = true, Description = "дата возврата")]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// подтверждение взноса
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "BO", Description = "подтверждение взноса", Order = 11)]
        public string FeeAcknowledged { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 5)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AB", Description = "идентификатор единицы", Order = 7)]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы", Order = 9)]
        public string ItemProperties { get; set; }
        /// <summary>
        /// отсутствие блокировки
        /// </summary>
        [Sip2Field(2, 1, Required = true, Description = "отсутствие блокировки")]
        public bool NoBlock { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 6)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "AD", Description = "пароль абонента", Order = 10)]
        public string PatronPassword { get; set; }
        /// <summary>
        /// политика возобновления системы SC
        /// </summary>
        [Sip2Field(1, 1, Required = true, Description = "политика возобновления системы SC")]
        public bool RenewalPolicy { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AC", Description = "окончательный пароль", Order = 8)]
        public string TerminalPassword { get; set; }
    }
}
