using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2
{
    [Serializable]
    [Sip2Identificator(Sip2Response.acRenew)]
    public class RenewResponseImpl : Sip2ResponsePrintImpl, IRenewResponse
    {
        public class OkRenewSerialize : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}", ((bool)value) ? "1" : "0");
            }
        }
        public class DueDateRenewSerialize : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}{1}{2}", field.Identificator, ((DateTime)value).ToString("dd.MM.yyyy"), separator);
            }
        }
        public class Sip2FeeTypeImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}{1:00}{2}", field.Identificator, (int)(Sip2FeeType)value, separator);
            }
        }

        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(13, Length = 3, Version = Sip2Version.V200, Description = "валюта", Identificator = "BH")]
        public string CurrencyType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(5, Required = true, Length = 18, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// размагничивание
        /// </summary>
        [Sip2Field(4, Required = true, Length = 1, Description = "размагничивание")]
        public bool Desensitize { get; set; }
        /// <summary>
        /// дата возврата
        /// </summary>
        [Sip2Field(10, Required = true, Length = 18, Description = "дата возврата", Identificator = "AH", SerializeType = typeof(DueDateRenewSerialize))]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        [Sip2Field(14, Identificator = "BV", Version = Sip2Version.V200, Description = "сумма взноса")]
        public double FeeAmount { get; set; }
        /// <summary>
        /// тип взноса
        /// </summary>
        [Sip2Field(11, Length = 2, SerializeType = typeof(Sip2FeeTypeImpl), Version = Sip2Version.V200, Identificator = "BT", Description = "тип взноса")]
        public Sip2FeeType FeeType { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(6, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(8, Required = true, Identificator = "AB", Description = "идентификатор единицы")]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(16, Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы")]
        public string ItemProperties { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        [Sip2Field(3, Required = true, Length = 1, Description = "магнитный носитель")]
        public bool MagneticMedia { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        [Sip2Field(15, Identificator = "CK", SerializeType = typeof(ItemInformationResponseImpl.Sip2MediaTypeImpl), Version = Sip2Version.V200, Description = "тип носителя")]
        public Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(1, Required = true, Length = 1, Description = "разрешено", SerializeType = typeof(OkRenewSerialize))]
        public bool Ok { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(7, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// возобновление разрешено
        /// </summary>
        [Sip2Field(2, Required = true, Length = 1, Description = "возобновление разрешено")]
        public bool RenewalOk { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        [Sip2Field(12, Version = Sip2Version.V200, Identificator = "CI", Description = "магнитный носитель")]
        public bool SecurityInhibit { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(9, Identificator = "AJ", Required = true, Description = "идентификатор названия")]
        public string TitleIdentifier { get; set; }
        /// <summary>
        /// идентификатор операции
        /// </summary>
        [Sip2Field(17, Version = Sip2Version.V200, Identificator = "BK", Description = "идентификатор операции")]
        public int TransactionId { get; set; }
    }
}
