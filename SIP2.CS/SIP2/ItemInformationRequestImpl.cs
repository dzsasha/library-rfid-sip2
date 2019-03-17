using System;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scItemInformation)]
    public class ItemInformationRequestImpl : Sip2AnswerImpl, IItemInformationRequest {
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(1, Required = true, Description = "дата операции", Length = 18)]
        public DateTime date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(2, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(3, Required = true, Identificator = "AB", Description = "идентификатор единицы")]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(4, Identificator = "AC", Description = "окончательный пароль")]
        public string TerminalPassword { get; set; }
    }
}
