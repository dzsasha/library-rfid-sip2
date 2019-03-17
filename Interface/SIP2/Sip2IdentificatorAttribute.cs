using System;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Номера команд
    /// </summary>
    public class Sip2IdentificatorAttribute : Attribute {
        /// <summary>
        /// Конструктор для входящего сообщения
        /// </summary>
        /// <param name="request">номер входящего сообщения</param>
        public Sip2IdentificatorAttribute(Sip2Request request) {
            this.request = request;
        }
        /// <summary>
        /// Конструктор для выходящего сообщения
        /// </summary>
        /// <param name="response">номер выходящего сообщения</param>
        public Sip2IdentificatorAttribute(Sip2Response response) {
            this.response = response;
        }
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Sip2IdentificatorAttribute() {

        }
        /// <summary>
        /// Номер входящего сообщения
        /// </summary>
        public Sip2Request request { get; set; }
        /// <summary>
        /// Номер выходящего сообщения
        /// </summary>
        public Sip2Response response { get; set; }
    }
}