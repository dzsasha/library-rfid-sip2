using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acPatronStatus)]
    public class PatronStatusResponseImpl : Sip2ResponsePrintImpl, IPatronStatusResponse {
        internal class PatronStatusImpl : ISip2Serialize {
            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                ushort status = BitConverter.ToUInt16((byte[])value, 0);
                string sRet = "";
                for(int i = 0; i < 14; i++) {
                    sRet += (status & (0x1 << i)) == 1 ? "Y" : " ";
                }
                return sRet;
            }
        }
        /// <summary>
        /// валюта
        /// </summary>
        [Sip2Field(9, Identificator = "BH", Version = Sip2Version.V200, Length = 3, Description = "валюта")]
        public string CurrencyType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        [Sip2Field(10, Identificator = "BV", Version = Sip2Version.V200, Description = "сумма взноса")]
        public double FeeAmount { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(4, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(2, Length = 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(5, Required = true, Identificator = "AA", Description = "идентификатор абонента")]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// Статус абонента
        /// </summary>
        [Sip2Field(1, Length = 14, Required = true, SerializeType = typeof(PatronStatusImpl))]
        public byte[] PatronStatus { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [Sip2Field(6, Required = true, Identificator = "AE", Description = "Ф.И.О.")]
        public string PersonalName { get; set; }
        /// <summary>
        /// действительный абонент
        /// </summary>
        [Sip2Field(7, Identificator = "BL", Version = Sip2Version.V200, Description = "действительный абонент")]
        public bool ValidPatron { get; set; }
        /// <summary>
        /// действительный пароль абонента
        /// </summary>
        [Sip2Field(8, Identificator = "CQ", Version = Sip2Version.V200, Description = "действительный пароль абонента")]
        public bool ValidPatronPassword { get; set; }
    }
}
