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
        public class OkCheckInSerialize : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return String.Format("{0}", ((bool)value) ? "1" : "0");
            }
        }
        /// <summary>
        /// сигнализация
        /// </summary>
        [Sip2Field(4, Required = true, Description = "сигнализация")]
        public bool Alert { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(5, Required = true, Length = 18, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(6, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(7, Required = true, Identificator = "AB", Description = "идентификатор единицы")]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(13, Version = Sip2Version.V200, Identificator = "CH", Description = "свойства единицы")]
        public string ItemProperties { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        [Sip2Field(3, Required = true, Description = "магнитный носитель")]
        public bool MagneticMedia { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        [Sip2Field(12, Identificator = "CK", SerializeType = typeof(ItemInformationResponseImpl.Sip2MediaTypeImpl), Version = Sip2Version.V200, Description = "тип носителя")]
        public Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(1, Required = true, Description = "разрешено", SerializeType = typeof(OkCheckInSerialize))]
        public bool Ok { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(11, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// постоянное месторасположение
        /// </summary>
        [Sip2Field(8, Identificator = "AQ", Required = true, Description = "постоянное месторасположение")]
        public string PermanentLocation { get; set; }
        /// <summary>
        /// повторное намагничивание
        /// </summary>
        [Sip2Field(2, Required = true, Description = "повторное намагничивание")]
        public bool Resensitize { get; set; }
        /// <summary>
        /// сортировочная корзина
        /// </summary>
        [Sip2Field(10, Version = Sip2Version.V200, Identificator = "CL", Description = "сортировочная корзина")]
        public string SortBin { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(9, Identificator = "AJ", Required = true, Description = "идентификатор названия")]
        public string TitleIdentifier { get; set; }
    }
}
