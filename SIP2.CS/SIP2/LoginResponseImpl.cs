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
        public class OkSerializeImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return ((bool)value) ? "1" : "0";
            }
        }
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(1, 1, Version = Sip2Version.V200, Required = true, SerializeType = typeof(OkSerializeImpl), Description = "разрешено")]
        public bool Ok { get; set; }
    }
}
