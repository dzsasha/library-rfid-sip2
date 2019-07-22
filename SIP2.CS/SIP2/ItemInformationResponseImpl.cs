using IS.Interface.SIP2;
using System;
using System.ComponentModel;
using System.Globalization;

namespace IS.SIP2.CS.SIP2 {
    /// <summary>
    /// Выходящее сообщение (Item Information: 18)
    /// </summary>
    [Serializable]
    [Sip2Identificator(Sip2Response.acItemInformation)]
    public class ItemInformationResponseImpl : Sip2ResponsePrintImpl, IItemInformationResponse {
        public class Sip2CirculationStatusImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                int iResult = (!((int)value).Equals(0))
                    ? (int)(Sip2CirculationStatus)value
                    : (int)Sip2CirculationStatus.Other;
                return String.Format("{0:00}", iResult);
            }
        }
        public class Sip2FeeTypeImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}{1:00}{2}", field.Identificator, (int)(Sip2FeeType)value, String.IsNullOrEmpty(field.Identificator) ? "" : new String(separator, 1));
            }
        }
        public class SecurityMarkerImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0:00}", (int)(SecurityMarker)value);
            }
        }
        public class Sip2MediaTypeImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}{1:000}{2}", field.Identificator, (int)(Sip2MediaType)value, String.IsNullOrEmpty(field.Identificator) ? "" : new String(separator, 1));
            }
        }
        public class Sip2Date : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                if(value != null && !(value is DateTime ? (DateTime)value : new DateTime()).Equals(new DateTime())) {
                    return String.Format("{0}{1}{2}", field.Identificator,
                        (value is DateTime) ? ((DateTime)value).ToString("dd.MM.yyyy") : "", separator);
                }
                return "";
            }
            public override object Deserialize(PropertyDescriptor prop, string value) {
                return DateTime.ParseExact(value, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            }
        }
        /// <summary>
        /// состояние выдачи на абонемент
        /// </summary>
        [Sip2Field(1, 2, Required = true, SerializeType = typeof(Sip2CirculationStatusImpl), Version = Sip2Version.V200, Description = "состояние выдачи на абонемент", Default = Sip2CirculationStatus.Other)]
        public Sip2CirculationStatus CirculationStatus { get; set; } = Sip2CirculationStatus.Other;
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(Length = 3, Version = Sip2Version.V200, Description = "валюта", Identificator = "BH", Order = 12)]
        public string CurrencyType { get; set; }
        /// <summary>
        /// текущее месторасположение
        /// </summary>
        [Sip2Field(Identificator = "AP", Version = Sip2Version.V200, Description = "текущее месторасположение", Order = 16)]
        public string CurrentLocation { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(4, 18, Required = true, Description = "дата операции")]
        public DateTime date { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(Identificator = "AH", Description = "дата операции", SerializeType = typeof(Sip2Date), Order = 6)]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Description = "валюта", Identificator = "BV", Order = 13)]
        public double FeeAmount { get; set; }
        /// <summary>
        /// тип взноса
        /// </summary>
        [Sip2Field(3, 2, Required = true, SerializeType = typeof(Sip2FeeTypeImpl), Version = Sip2Version.V200, Description = "тип взноса")]
        public Sip2FeeType FeeType { get; set; }
        /// <summary>
        /// дата отзыва
        /// </summary>
        [Sip2Field(Identificator = "CM", Version = Sip2Version.V200, Description = "дата отзыва", SerializeType = typeof(Sip2Date), Order = 8)]
        public DateTime HoldPickupDate { get; set; }
        /// <summary>
        /// длина очереди удержания
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CF", Description = "длина очереди удержания", Order = 5)]
        public int HoldQueueLength { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Identificator = "AB", Required = true, Description = "идентификатор единицы", Order = 9)]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(Identificator = "CH", Version = Sip2Version.V200, Description = "свойства единицы", Order = 17)]
        public string ItemProperties { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        [Sip2Field(Identificator = "CK", SerializeType = typeof(Sip2MediaTypeImpl), Version = Sip2Version.V200, Description = "тип носителя", Order = 14)]
        public Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// владелец
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "BG", Description = "владелец", Order = 11)]
        public string Owner { get; set; }
        /// <summary>
        /// постоянное месторасположение
        /// </summary>
        [Sip2Field(Identificator = "AQ", Version = Sip2Version.V200, Description = "постоянное месторасположение", Order = 15)]
        public string PermanentLocation { get; set; }
        /// <summary>
        /// дата отзыва
        /// </summary>
        [Sip2Field(Identificator = "CJ", Version = Sip2Version.V200, Description = "дата отзыва", SerializeType = typeof(Sip2Date), Order = 7)]
        public DateTime RecallDate { get; set; }
        /// <summary>
        /// маркер безопасности
        /// </summary>
        [Sip2Field(2, 2, Required = true, SerializeType = typeof(SecurityMarkerImpl), Version = Sip2Version.V200, Description = "маркер безопасности")]
        public SecurityMarker SecurityMarker { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(Identificator = "AJ", Required = true, Description = "идентификатор названия", Order = 10)]
        public string TitleIdentifier { get; set; }
    }
}
