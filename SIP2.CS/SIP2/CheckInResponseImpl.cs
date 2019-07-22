using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acCheckin)]
    public class CheckInResponseImpl : Sip2ResponsePrintImpl, ICheckInResponse {
        public class OkCheckInSerialize : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}", ((bool)value) ? "1" : "0");
            }
        }
        /// <summary>
        /// сигнализация
        /// </summary>
        [Sip2Field(4, 1, Required = true, Description = "сигнализация")]
        public bool Alert { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(5, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 6)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AB", Description = "идентификатор единицы", Order = 7)]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы", Order = 13)]
        public string ItemProperties { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        [Sip2Field(3, 1, Required = true, Description = "магнитный носитель")]
        public bool MagneticMedia { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        [Sip2Field(Identificator = "CK", SerializeType = typeof(ItemInformationResponseImpl.Sip2MediaTypeImpl), Version = Sip2Version.V200, Description = "тип носителя", Order = 12)]
        public Sip2MediaType MediaType { get; set; } = Sip2MediaType.Other;
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(1, 1, Required = true, Description = "разрешено", SerializeType = typeof(OkCheckInSerialize))]
        public bool Ok { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 11)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// постоянное месторасположение
        /// </summary>
        [Sip2Field(Identificator = "AQ", Required = true, Description = "постоянное месторасположение", Order = 8)]
        public string PermanentLocation { get; set; }
        /// <summary>
        /// повторное намагничивание
        /// </summary>
        [Sip2Field(2, 1, Required = true, Description = "повторное намагничивание")]
        public bool Resensitize { get; set; }
        /// <summary>
        /// сортировочная корзина
        /// </summary>
        [Sip2Field(Version = Sip2Version.V200, Identificator = "CL", Description = "сортировочная корзина", Order = 10)]
        public string SortBin { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(Identificator = "AJ", Required = true, Description = "идентификатор названия", Order = 9)]
        public string TitleIdentifier { get; set; }
    }
}
