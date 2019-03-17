using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acRenewAll)]
    public class RenewAllResponseImpl : Sip2ResponsePrintImpl, IRenewAllResponse {
        /// <summary>
        /// разрешено
        /// </summary>
        [Sip2Field(1, Required = true, Length = 1, Description = "разрешено", SerializeType = typeof(RenewResponseImpl.OkRenewSerialize))]
        public bool Ok { get; set; }

        /// <summary>
        /// число возобновленных
        /// </summary>
        [Sip2Field(2, Required = true, Length = 4, Description = "число возобновленных", Version = Sip2Version.V200)]
        public int RenewedCount { get; set; }

        /// <summary>
        /// число невозобновленных
        /// </summary>
        [Sip2Field(3, Required = true, Length = 4, Description = "число невозобновленных", Version = Sip2Version.V200)]
        public int UnRenewedCount { get; set; }

        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(4, Required = true, Length = 18, Description = "дата возврата")]
        public DateTime Date { get; set; }

        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }

        /// <summary>
        /// возобновленных единиц
        /// </summary>
        [Sip2Field(6, Description = "возобновленных единиц", Version = Sip2Version.V200, Identificator = "BM", SerializeType = typeof(PatronInformationResponseImpl.StringArraySerialize))]
        public string[] RenewedItems { get; set; }

        /// <summary>
        /// невозобновленных единиц
        /// </summary>
        [Sip2Field(7, Description = "невозобновленных единиц", Version = Sip2Version.V200, Identificator = "BN", SerializeType = typeof(PatronInformationResponseImpl.StringArraySerialize))]
        public string[] UnRenewedItems { get; set; }
    }
}
