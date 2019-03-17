using IS.Interface.SIP2;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace IS.SIP2.CS.SIP2 {
    /// <summary>
    /// Имплементация ISCStatusRequest
    /// </summary>
    [Serializable]
    [Sip2Identificator(Sip2Request.scSCStatus)]
    public class SCStatusRequestImpl : Sip2AnswerImpl, ISCStatusRequest {
        internal class StatusCodeImpl : ISip2Serialize, ISip2Deserialize {
            public object create { get; set; }

            public object Deserialize(PropertyDescriptor prop, string value) {
                return (SCStatusCode)Convert.ToInt32(value);
            }

            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return Convert.ToString((int)(SCStatusCode)(value));
            }
        }
        internal class VersionImpl : ISip2Serialize, ISip2Deserialize {
            public object create { get; set; }

            public object Deserialize(PropertyDescriptor prop, string value) {
                foreach (Sip2Version Version in Enum.GetValues(typeof(Sip2Version))) {
                    if(Version.GetAttributeOfType<EnumMemberAttribute>().Value.Equals(value)) return Version;
                }
                return Sip2Version.V100;
            }

            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return ((Sip2Version)value).GetAttributeOfType<EnumMemberAttribute>().Value;
            }
        }
        #region implementation ISCStatusRequest
        /// <summary>
        /// макс. печатная ширина
        /// </summary>
        [Sip2Field(2, Required = true, Length = 3, Description = "макс. печатная ширина")]
        public int MaxPrintWidth { get; set; }
        /// <summary>
        /// код состояния
        /// </summary>
        [Sip2Field(1, DeserializeType = typeof(StatusCodeImpl), Required = true, Length = 1, Description = "код состояния")]
        public SCStatusCode StatusCode { get; set; }
        /// <summary>
        /// версия протокола
        /// </summary>
        [Sip2Field(3, DeserializeType = typeof(VersionImpl), Required = true, Length = 4, Description = "версия протокола")]
        public Sip2Version Version { get; set; }
        #endregion
    }
}
