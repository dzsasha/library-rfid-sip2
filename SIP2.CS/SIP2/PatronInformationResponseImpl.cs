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
        public class StringArraySerialize : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
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
        [Sip2Field(6, 4, Required = true, Version = Sip2Version.V200)]
        public int ChargedItemsCount { get; set; }
        /// <summary>
        /// ограничение оплачиваемых единиц
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Length = 4, Identificator = "CB", Description = "ограничение оплачиваемых единиц", Order = 15)]
        public int ChargedItemsLimit { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(Identificator = "BH", Version = Sip2Version.V200, Length = 3, Description = "валюта", Order = 18)]
        public string CurrencyType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        [Sip2Field(Identificator = "BV", Version = Sip2Version.V200, Description = "сумма взноса", Order = 19)]
        public double FeeAmount { get; set; }
        /// <summary>
        /// ограничение взноса
        /// </summary>
        [Sip2Field(Identificator = "CC", Version = Sip2Version.V200, Description = "ограничение взноса", Order = 10)]
        public double FeeLimit { get; set; }
        /// <summary>
        /// удерживаемых единиц
        /// </summary>
        [Sip2Field(Identificator = "AS", Version = Sip2Version.V200, Description = "удерживаемых единиц", SerializeType = typeof(StringArraySerialize), Order = 21)]
        public string[] HoldItems { get; set; }
        /// <summary>
        /// просроченных единиц
        /// </summary>
        [Sip2Field(Identificator = "AT", Version = Sip2Version.V200, Description = "просроченных единиц", SerializeType = typeof(StringArraySerialize), Order = 22)]
        public string[] OverDueItems { get; set; }
        /// <summary>
        /// оплаченных единиц
        /// </summary>
        [Sip2Field(Identificator = "AU", Version = Sip2Version.V200, Description = "оплаченных единиц", SerializeType = typeof(StringArraySerialize), Order = 23)]
        public string[] ChargedItems { get; set; }
        /// <summary>
        /// проштрафленных единиц
        /// </summary>
        [Sip2Field(Identificator = "AV", Version = Sip2Version.V200, Description = "проштрафленных единиц", SerializeType = typeof(StringArraySerialize), Order = 24)]
        public string[] FineItems { get; set; }
        /// <summary>
        /// отозванных единиц
        /// </summary>
        [Sip2Field(Identificator = "BU", Version = Sip2Version.V200, Description = "отозванных единиц", SerializeType = typeof(StringArraySerialize), Order = 25)]
        public string[] RecallItems { get; set; }
        /// <summary>
        /// недоступных удерживаемых единиц
        /// </summary>
        [Sip2Field(Identificator = "CD", Version = Sip2Version.V200, Description = "отозванных единиц", SerializeType = typeof(StringArraySerialize), Order = 26)]
        public string[] UnAvailableItems { get; set; }
        /// <summary>
        /// адрес
        /// </summary>
        [Sip2Field(Identificator = "BD", Version = Sip2Version.V200, Description = "адрес", Order = 27)]
        public string HomeAddress { get; set; }
        /// <summary>
        /// адрес электронной почты
        /// </summary>
        [Sip2Field(Identificator = "BE", Version = Sip2Version.V200, Description = "адрес электронной почты", Order = 28)]
        public string Email { get; set; }
        /// <summary>
        /// домашний телефон
        /// </summary>
        [Sip2Field(Identificator = "BF", Version = Sip2Version.V200, Description = "домашний телефон", Order = 29)]
        public string HomePhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(7, 4, Required = true, Version = Sip2Version.V200)]
        public int FineItemsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(4, 4, Required = true, Version = Sip2Version.V200)]
        public int HoldItemsCount { get; set; }
        /// <summary>
        /// ограничение удерживаемых единиц
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Length = 4, Identificator = "BZ", Description = "ограничение удерживаемых единиц", Order = 13)]
        public int HoldItemsLimit { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 10)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(2, 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(5, 4, Required = true, Version = Sip2Version.V200)]
        public int OverDueItemsCount { get; set; }
        /// <summary>
        /// ограничение просроченных единиц
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Length = 4, Identificator = "CA", Description = "ограничение просроченных единиц", Order = 14)]
        public int OverDueItemsLimit { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 11)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// Статус абонента
        /// </summary>
        [Sip2Field(1, 14, Required = true, SerializeType = typeof(PatronStatusResponseImpl.PatronStatusImpl))]
        public byte[] PatronStatus { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AE", Description = "Ф.И.О.", Order = 12)]
        public string PersonalName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(8, 4, Required = true, Version = Sip2Version.V200)]
        public int ReCallItemsCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Sip2Field(9, 4, Required = true, Version = Sip2Version.V200)]
        public int UnAvailableItemsCount { get; set; }
        /// <summary>
        /// действительный абонент
        /// </summary>
        [Sip2Field(Identificator = "BL", Version = Sip2Version.V200, Description = "действительный абонент", Order = 16)]
        public bool ValidPatron { get; set; }
        /// <summary>
        /// действительный пароль абонента
        /// </summary>
        [Sip2Field(Identificator = "CQ", Version = Sip2Version.V200, Description = "действительный пароль абонента", Order = 17)]
        public bool ValidPatronPassword { get; set; }
    }
}
