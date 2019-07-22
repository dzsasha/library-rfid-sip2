using IS.Interface.SIP2;
using System;
using System.IO;

namespace IS.SIP2.CS.SIP2 {
    [Sip2Identificator(request = Sip2Request.scRequestACSResend, response = Sip2Response.acRequestSCResend)]
    public class ResendImpl : ISip2Command<ISip2Request, ISip2Response>, ISip2Answer {
        public int Sequence { get; set; }
        [Sip2Field(101, 4, Required = true, SerializeType = typeof(Sip2AnswerImpl.CheckSumImpl))]
        public int CheckSum { get; set; }

        public event ErrorEventHandler OnError;

        public bool execute(ISip2Config config, ISip2Request request, ref ISip2Response response) {
            return true;
        }
    }
}
