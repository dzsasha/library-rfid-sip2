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
        internal class PatronStatusImpl : Sip2SerializeImpl {
            public override string Serialize(Sip2FieldAttribute field, object value, Char separator) {
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
        [Sip2Field(Identificator = "BH", Version = Sip2Version.V200, Length = 3, Description = "валюта", Order = 9)]
        public string CurrencyType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        [Sip2Field(3, 18, Required = true, Description = "дата операции")]
        public DateTime Date { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        [Sip2Field(Identificator = "BV", Version = Sip2Version.V200, Description = "сумма взноса", Order = 10)]
        public double FeeAmount { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AO", Description = "идентификатор учреждения", Order = 4)]
        public string InstitutionId { get; set; }
        /// <summary>
        /// язык
        /// </summary>
        [Sip2Field(2, 3, Required = true, Description = "язык")]
        public string Language { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AA", Description = "идентификатор абонента", Order = 5)]
        public string PatronIdentifier { get; set; }
        /// <summary>
        /// Статус абонента
        /// </summary>
        [Sip2Field(1, 14, Required = true, SerializeType = typeof(PatronStatusImpl))]
        public byte[] PatronStatus { get; set; }
        /// <summary>
        /// Ф.И.О.
        /// </summary>
        [Sip2Field(Required = true, Identificator = "AE", Description = "Ф.И.О.", Order = 6)]
        public string PersonalName { get; set; }
        /// <summary>
        /// действительный абонент
        /// </summary>
        [Sip2Field(Identificator = "BL", Version = Sip2Version.V200, Description = "действительный абонент", Order = 7)]
        public bool ValidPatron { get; set; }
        /// <summary>
        /// действительный пароль абонента
        /// </summary>
        [Sip2Field(Identificator = "CQ", Version = Sip2Version.V200, Description = "действительный пароль абонента", Order = 8)]
        public bool ValidPatronPassword { get; set; }
    }
}
