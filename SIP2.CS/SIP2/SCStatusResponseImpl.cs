using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.CS.SIP2 {
    [Serializable]
    [Sip2Identificator(Sip2Response.acACSStatus)]
    public class SCStatusResponseImpl : Sip2ResponsePrintImpl, ISCStatusResponse {
        /// <summary>
        /// возврат разрешен
        /// </summary>
        [Sip2Field(2, Required = true, Description = "возврат разрешен")]
        public bool CheckinOk { get; set; }
        /// <summary>
        /// получение разрешено
        /// </summary>
        [Sip2Field(3, Required = true, Description = "получение разрешено")]
        public bool CheckoutOk { get; set; }
        /// <summary>
        /// дата/ время синхр
        /// </summary>
        [Sip2Field(9, Required = true, Description = "дата/ время синхр")]
        public DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        [Sip2Field(11, Required = true, Identificator = "AO", Description = "идентификатор учреждения")]
        public string InstitutionId { get; set; }
        /// <summary>
        /// название библиотеки
        /// </summary>
        [Sip2Field(12, Identificator = "AM", Description = "название библиотеки")]
        public string LibraryName { get; set; }
        /// <summary>
        /// переход в автономный режим разрешен
        /// </summary>
        [Sip2Field(6, Required = true, Description = "переход в автономный режим разрешен")]
        public bool OfflineOk { get; set; }
        /// <summary>
        /// интерактивное состояние
        /// </summary>
        [Sip2Field(1, Required = true, Description = "интерактивное состояние")]
        public bool OnlineStatus { get; set; }
        /// <summary>
        /// политика возобновления ААС
        /// </summary>
        [Sip2Field(4, Required = true, Description = "политика возобновления ААС")]
        public bool RenewalPolicy { get; set; }
        /// <summary>
        /// разрешенных попыток
        /// </summary>
        [Sip2Field(8, Required = true, Length = 3, Description = "разрешенных попыток")]
        public int RetriesAllowed { get; set; }
        /// <summary>
        /// обновление состояния разрешено
        /// </summary>
        [Sip2Field(5, Required = true, Description = "обновление состояния разрешено")]
        public bool StatusUpdateOk { get; set; }
        /// <summary>
        /// поддерживаемые сообщения
        /// </summary>
        [Sip2Field(13, Required = true, Identificator = "BX", Version = Sip2Version.V200, Length = 16, Description = "поддерживаемые сообщения")]
        public string SupportedMessages { get; set; }
        /// <summary>
        /// окончательное месторасположение
        /// </summary>
        [Sip2Field(14, Identificator = "AN", Description = "окончательное месторасположение")]
        public string TerminalLocation { get; set; }
        /// <summary>
        /// время ожидания
        /// </summary>
        [Sip2Field(7, Required = true, Length = 3, Description = "время ожидания")]
        public int TimeoutPeriod { get; set; }
        /// <summary>
        /// версия протокола
        /// </summary>
        [Sip2Field(10, SerializeType = typeof(SCStatusRequestImpl.VersionImpl), Required = true, Description = "версия протокола")]
        public Sip2Version Version { get; set; }
    }
}
