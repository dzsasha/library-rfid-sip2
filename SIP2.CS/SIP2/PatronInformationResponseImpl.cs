using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acPatronInformation)]
    public class PatronInformationResponseImpl : Sip2ResponsePrintImpl, IPatronInformationResponse {
        public class StringArraySerialize : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                string result = "";
                if (value != null) {
                    result = (value as string[]).Aggregate(result, (current, str) => current + $"{field.Identificator}{str}{separator}");
                }

                return result;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(6, Required = true, Version = Sip2Version.V200, Length = 4)]
        public int ChargedItemsCount { get; set; }
        /// <summary>
        /// ограничение оплачиваемых единиц
        /// </summary>
        [Sip2Field(15, Version = Sip2Version.V200, Length = 4, Identificator = "CB", Description = "ограничение оплачиваемых единиц")]
        public int ChargedItemsLimit { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(18, Identificator = "BH", Version = Sip2Version.V200, Length = 3, Description = "валюта")]
        public string CurrencyType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        [Sip2Field(19, Identificator = "BV", Version = Sip2Version.V200, Description = "сумма взноса")]
        public double FeeAmount { get; set; }
        /// <summary>
        /// ограничение взноса
        /// </summary>
        [Sip2Field(20, Identificator = "CC", Version = Sip2Version.V200, Description = "ограничение взноса")]
        public double FeeLimit { get; set; }
        /// <summary>
        /// удерживаемых единиц
        /// </summary>
        [Sip2Field(21, Identificator = "AS", Version = Sip2Version.V200, Description = "удерживаемых единиц", SerializeType = typeof(StringArraySerialize))]
        public string[] HoldItems { get; set; }
        /// <summary>
        /// просроченных единиц
        /// </summary>
        [Sip2Field(22, Identificator = "AT", Version = Sip2Version.V200, Description = "просроченных единиц", SerializeType = typeof(StringArraySerialize))]
        public string[] OverDueItems { get; set; }
        /// <summary>
        /// оплаченных единиц
        /// </summary>
        [Sip2Field(23, Identificator = "AU", Version = Sip2Version.V200, Description = "оплаченных единиц", SerializeType = typeof(StringArraySerialize))]
        public string[] ChargedItems { get; set; }
        /// <summary>
        /// проштрафленных единиц
        /// </summary>
        [Sip2Field(24, Identificator = "AV", Version = Sip2Version.V200, Description = "проштрафленных единиц", SerializeType = typeof(StringArraySerialize))]
        public string[] FineItems { get; set; }
        /// <summary>
        /// отозванных единиц
        /// </summary>
        [Sip2Field(25, Identificator = "BU", Version = Sip2Version.V200, Description = "отозванных единиц", SerializeType = typeof(StringArraySerialize))]
        public string[] RecallItems { get; set; }
        /// <summary>
        /// недоступных удерживаемых единиц
        /// </summary>
        [Sip2Field(26, Identificator = "CD", Version = Sip2Version.V200, Description = "отозванных единиц", SerializeType = typeof(StringArraySerialize))]
        public string[] UnAvailableItems { get; set; }
        /// <summary>
        /// адрес
        /// </summary>
        [Sip2Field(27, Identificator = "BD", Version = Sip2Version.V200, Description = "адрес")]
        public string HomeAddress { get; set; }
        /// <summary>
        /// адрес электронной почты
        /// </summary>
        [Sip2Field(28, Identificator = "BE", Version = Sip2Version.V200, Description = "адрес электронной почты")]
        public string Email { get; set; }
        /// <summary>
        /// домашний телефон
        /// </summary>
        [Sip2Field(29, Identificator = "BF", Version = Sip2Version.V200, Description = "домашний телефон")]
        public string HomePhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(7, Required = true, Version = Sip2Version.V200, Length = 4)]
        public int FineItemsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(4, Required = true, Version = Sip2Version.V200, Length = 4)]
        public int HoldItemsCount { get; set; }
        /// <summary>
        /// ограничение удерживаемых единиц
        /// </summary>
        [Sip2Field(13, Version = Sip2Version.V200, Length = 4, Identificator = "BZ", Description = "ограничение удерживаемых единиц")]
        public int HoldItemsLimit { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(10, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(2, Length = 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(5, Required = true, Version = Sip2Version.V200, Length = 4)]
        public int OverDueItemsCount { get; set; }
        /// <summary>
        /// ограничение просроченных единиц
        /// </summary>
        [Sip2Field(14, Version = Sip2Version.V200, Length = 4, Identificator = "CA", Description = "ограничение просроченных единиц")]
        public int OverDueItemsLimit { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(11, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// Статус абонента
        /// </summary>
        [Sip2Field(1, Length = 14, Required = true, SerializeType = typeof(PatronStatusResponseImpl.PatronStatusImpl))]
        public byte[] PatronStatus { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [Sip2Field(12, Required = true, Identificator = "AE", Description = "Ф.И.О.")]
        public string PersonalName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(8, Required = true, Version = Sip2Version.V200, Length = 4)]
        public int ReCallItemsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(9, Required = true, Version = Sip2Version.V200, Length = 4)]
        public int UnAvailableItemsCount { get; set; }
        /// <summary>
        /// действительный абонент
        /// </summary>
        [Sip2Field(16, Identificator = "BL", Version = Sip2Version.V200, Description = "действительный абонент")]
        public bool ValidPatron { get; set; }
        /// <summary>
        /// действительный пароль абонента
        /// </summary>
        [Sip2Field(17, Identificator = "CQ", Version = Sip2Version.V200, Description = "действительный пароль абонента")]
        public bool ValidPatronPassword { get; set; }
    }
}
