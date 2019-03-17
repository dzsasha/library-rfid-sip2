using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS.SIP2 {
    /// <summary>
    /// Выходящее сообщение (Item Information: 18)
    /// </summary>
    [Serializable]
    [Sip2Identificator(Sip2Response.acItemInformation)]
    public class ItemInformationResponseImpl : Sip2ResponsePrintImpl, IItemInformationResponse {
        public class Sip2CirculationStatusImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                int iResult = (!((int)value).Equals(0))
                    ? (int)(Sip2CirculationStatus)value
                    : (int)Sip2CirculationStatus.Other;
                return String.Format("{0:00}", iResult);
            }
        }
        public class Sip2FeeTypeImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0:00}", (int)(Sip2FeeType)value);
            }
        }
        public class SecurityMarkerImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0:00}", (int)(SecurityMarker)value);
            }
        }
        public class Sip2MediaTypeImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}{1}|", field.Identificator, Convert.ToString((int)(Sip2MediaType)value));
            }
        }
        public class Sip2Date : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                if (value != null && !(value is DateTime ? (DateTime) value : new DateTime()).Equals(new DateTime()))
                {
                    return String.Format("{0}{1}{2}", field.Identificator,
                        (value is DateTime) ? ((DateTime) value).ToString("dd.MM.yyyy") : "", separator);
                }
                return "";
            }
        }
        /// <summary>
        /// состояние выдачи на абонемент
        /// </summary>
        [Sip2Field(1, Required = true, Length = 2, SerializeType = typeof(Sip2CirculationStatusImpl), Version = Sip2Version.V200, Description = "состояние выдачи на абонемент", Default = Sip2CirculationStatus.Other)]
        public Sip2CirculationStatus CirculationStatus { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(11, Length = 3, Version = Sip2Version.V200, Description = "валюта", Identificator = "BH")]
        public string CurrencyType { get; set; }
        /// <summary>
        /// текущее месторасположение
        /// </summary>
        [Sip2Field(15, Identificator = "AP", Version = Sip2Version.V200, Description = "текущее месторасположение")]
        public string CurrentLocation { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(4, Required = true, Description = "дата операции")]
        public DateTime date { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(6, Identificator = "AH", Description = "дата операции", SerializeType = typeof(Sip2Date))]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(12, Version = Sip2Version.V200, Description = "валюта", Identificator = "BV")]
        public double FeeAmount { get; set; }
        /// <summary>
        /// тип взноса
        /// </summary>
        [Sip2Field(3, Length = 2, Required = true, SerializeType = typeof(Sip2FeeTypeImpl), Version = Sip2Version.V200, Description = "тип взноса")]
        public Sip2FeeType FeeType { get; set; }
        /// <summary>
        /// дата отзыва
        /// </summary>
        [Sip2Field(8, Identificator = "CM", Version = Sip2Version.V200, Description = "дата отзыва", SerializeType = typeof(Sip2Date))]
        public DateTime HoldPickupDate { get; set; }
        /// <summary>
        /// длина очереди удержания
        /// </summary>
        [Sip2Field(5, Version = Sip2Version.V200, Identificator = "CF", Description = "длина очереди удержания")]
        public int HoldQueueLength { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(9, Identificator = "AB", Required = true, Description = "идентификатор единицы")]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(16, Identificator = "CH", Version = Sip2Version.V200, Description = "свойства единицы")]
        public string ItemProperties { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        [Sip2Field(13, Identificator = "CK", SerializeType = typeof(Sip2MediaTypeImpl), Version = Sip2Version.V200, Description = "тип носителя")]
        public Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// владелец
        /// </summary>
        [Sip2Field(5, Version = Sip2Version.V200, Identificator = "BG", Description = "владелец")]
        public string Owner { get; set; }
        /// <summary>
        /// постоянное месторасположение
        /// </summary>
        [Sip2Field(14, Identificator = "AQ", Version = Sip2Version.V200, Description = "постоянное месторасположение")]
        public string PermanentLocation { get; set; }
        /// <summary>
        /// дата отзыва
        /// </summary>
        [Sip2Field(7, Identificator = "CJ", Version = Sip2Version.V200, Description = "дата отзыва", SerializeType = typeof(Sip2Date))]
        public DateTime RecallDate { get; set; }
        /// <summary>
        /// маркер безопасности
        /// </summary>
        [Sip2Field(2, Length = 2, Required = true, SerializeType = typeof(SecurityMarkerImpl), Version = Sip2Version.V200, Description = "маркер безопасности")]
        public SecurityMarker SecurityMarker { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(10, Identificator = "AJ", Required = true, Description = "идентификатор названия")]
        public string TitleIdentifier { get; set; }
    }
}
