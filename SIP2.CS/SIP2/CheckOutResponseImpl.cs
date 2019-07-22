using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acCheckout)]
    public class CheckOutResponseImpl : Sip2ResponsePrintImpl, ICheckOutResponse {
        public class OkCheckOutSerialize : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}", ((bool)value) ? "1" : "0");
            }
        }
        public class DueDateSerialize : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}{1}{2}", field.Identificator, ((DateTime)value).ToString("dd.MM.yyyy"), separator);
            }
        }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(Length = 3, Version = Sip2Version.V200, Description = "валюта", Identificator = "BH", Order = 13)]
        public string CurrencyType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(5, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// размагничивание
        /// </summary>
        [Sip2Field(4, 1, Required = true, Description = "размагничивание")]
        public bool Desensitize { get; set; }
        /// <summary>
        /// дата возврата
        /// </summary>
        [Sip2Field(Required = true, Description = "дата возврата", Identificator = "AH", SerializeType = typeof(DueDateSerialize), Order = 10)]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        [Sip2Field(Identificator = "BV", Version = Sip2Version.V200, Description = "сумма взноса", Order = 14)]
        public double FeeAmount { get; set; }
        /// <summary>
        /// тип взноса
        /// </summary>
        [Sip2Field(Length = 2, SerializeType = typeof(ItemInformationResponseImpl.Sip2FeeTypeImpl), Version = Sip2Version.V200, Identificator = "BT", Description = "тип взноса", Order = 11)]
        public Sip2FeeType FeeType { get; set; } = Sip2FeeType.Other;
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 6)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AB", Description = "идентификатор единицы", Order = 8)]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы", Order = 16)]
        public string ItemProperties { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        [Sip2Field(3, 1, Required = true, Description = "магнитный носитель")]
        public bool MagneticMedia { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        [Sip2Field(Identificator = "CK", SerializeType = typeof(ItemInformationResponseImpl.Sip2MediaTypeImpl), Version = Sip2Version.V200, Description = "тип носителя", Order = 15)]
        public Sip2MediaType MediaType { get; set; } = Sip2MediaType.Other;
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(1, 1, Required = true, Description = "разрешено", SerializeType = typeof(OkCheckOutSerialize))]
        public bool Ok { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 7)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// возобновление разрешено
        /// </summary>
        [Sip2Field(2, 1, Required = true, Description = "возобновление разрешено")]
        public bool RenewalOk { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CI", Description = "магнитный носитель", Order = 12)]
        public bool SecurityInhibit { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(Identificator = "AJ", Required = true, Description = "идентификатор названия", Order = 9)]
        public string TitleIdentifier { get; set; }
        /// <summary>
        /// идентификатор операции
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "BK", Description = "идентификатор операции", Order = 17)]
        public int TransactionId { get; set; }
    }
}
