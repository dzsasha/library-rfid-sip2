﻿using System;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Request.scItemInformation)]
    public class ItemInformationRequestImpl : Sip2AnswerImpl, IItemInformationRequest {
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(1, 18, Required = true, Description = "дата операции")]
        public DateTime date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 2)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AB", Description = "идентификатор единицы", Order = 3)]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        [Sip2Field(Identificator = "AC", Description = "окончательный пароль", Order = 4)]
        public string TerminalPassword { get; set; }
    }
}
