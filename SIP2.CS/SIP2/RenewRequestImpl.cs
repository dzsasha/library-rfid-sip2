using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2
{
    [Serializable]
    [Sip2Identificator(Sip2Request.scRenew)]
    public class RenewRequestImpl : Sip2AnswerImpl, IRenewRequest
    {
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// подтверждение взноса
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "BO", Description = "подтверждение взноса", Order = 12)]
        public string FeeAcknowledged { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 5)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AB", Description = "идентификатор единицы", Order = 8)]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы", Order = 11)]
        public string ItemProperties { get; set; }
        /// <summary>
        /// дата возврата nb
        /// </summary>
        [Sip2Field(4, 18, Required = true, Description = "дата возврата nb")]
        public DateTime NbDueDate { get; set; }
        /// <summary>
        /// отсутствие блокировки
        /// </summary>
        [Sip2Field(2, 1, Required = true, Description = "")]
        public bool NoBlock { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 6)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// пароль абонента
        /// </summary>
        [Sip2Field(Identificator = "AD", Description = "пароль абонента", Order = 7)]
        public string PatronPassword { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AC", Description = "окончательный пароль", Order = 10)]
        public string TerminalPassword { get; set; }
        /// <summary>
        /// разрешение на присутствие третьей стороны
        /// </summary>
        [Sip2Field(1, 1, Version = Sip2Version.V200, Required = true, Length = 1)]
        public bool ThirdPartyAllowed { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(Identificator = "AJ", Required = true, Description = "идентификатор названия", Order = 9)]
        public string TitleIdentifier { get; set; }
    }
}
