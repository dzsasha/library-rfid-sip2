using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acLogin)]
    public class LoginResponseImpl : Sip2AnswerImpl, ILoginResponse {
        public class OkSerializeImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return ((bool)value) ? "1" : "0";
            }
        }
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(0, Version = Sip2Version.V200, Length = 1, Required = true, SerializeType = typeof(OkSerializeImpl), Description = "разрешено")]
        public bool Ok { get; set; }
    }
}
