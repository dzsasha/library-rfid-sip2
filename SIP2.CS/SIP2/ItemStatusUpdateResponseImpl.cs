using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    /// <summary>
    /// Выходящее сообщение
    /// </summary>
    [Serializable]
    [Sip2Identificator(Sip2Response.acItemStatusUpdate)]
    public class ItemStatusUpdateResponseImpl : Sip2ResponsePrintImpl, IItemStatusUpdateResponse{
        public class Sip2ItemStatusUpdateImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return ((value is bool ? (bool) value : false)) ? "0" : "1";
            }
        }
        /// <summary>
        /// свойства единицы разрешены
        /// </summary>
        [Sip2Field(1, 1, Required = true, Version = Sip2Version.V200, Description = "свойства единицы разрешены", Default = true, SerializeType = typeof(Sip2ItemStatusUpdateImpl))]
        public bool ItemPropertiesOk { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(2, 18, Required = true, Description = "дата операции")]
        public DateTime date { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        [Sip2Field(Identificator = "AB", Required = true, Description = "идентификатор единицы")]
        public string ItemIdentifier { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        [Sip2Field(Identificator = "AJ", Required = true, Description = "идентификатор названия")]
        public string TitleIdentifier { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        [Sip2Field(Identificator = "CH", Version = Sip2Version.V200, Description = "свойства единицы")]
        public string ItemProperties { get; set; }
    }
}
