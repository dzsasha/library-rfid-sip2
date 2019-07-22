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
        internal class StatusCodeImpl : Sip2SerializeImpl {
            public object create { get; set; }

            public override object Deserialize(PropertyDescriptor prop, string value) {
                return (SCStatusCode)Convert.ToInt32(value);
            }

            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return Convert.ToString((int)(SCStatusCode)(value));
            }
        }
        internal class VersionImpl : Sip2SerializeImpl {
            public object create { get; set; }

            public override object Deserialize(PropertyDescriptor prop, string value) {
                foreach (Sip2Version Version in Enum.GetValues(typeof(Sip2Version))) {
                    if(Version.GetAttributeOfType<EnumMemberAttribute>().Value.Equals(value)) return Version;
                }
                return Sip2Version.V100;
            }

            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return ((Sip2Version)value).GetAttributeOfType<EnumMemberAttribute>().Value;
            }
        }
        #region implementation ISCStatusRequest
        /// <summary>
        /// макс. печатная ширина
        /// </summary>
        [Sip2Field(2, 3, Required = true, Description = "макс. печатная ширина")]
        public int MaxPrintWidth { get; set; }
        /// <summary>
        /// код состояния
        /// </summary>
        [Sip2Field(1, 1, SerializeType = typeof(StatusCodeImpl), Required = true, Description = "код состояния")]
        public SCStatusCode StatusCode { get; set; }
        /// <summary>
        /// версия протокола
        /// </summary>
        [Sip2Field(3, 4, SerializeType = typeof(VersionImpl), Required = true, Description = "версия протокола")]
        public Sip2Version Version { get; set; }
        #endregion
    }
}
