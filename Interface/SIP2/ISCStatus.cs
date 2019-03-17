using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Статус
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2921")]
    [ComVisible(true)]
    public enum SCStatusCode {
        /// <summary>
        /// SC unit is OK
        /// </summary>
        OK = 0,
        /// <summary>
        /// SC printer is out of paper
        /// </summary>
        OutOfPaper = 1,
        /// <summary>
        /// SC is about to shut down
        /// </summary>
        ShutDown = 2
    }
    /// <summary>
    /// Входящее сообщение (SCStatus: 99)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2922")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scSCStatus)]
    public interface ISCStatusRequest : ISip2Request {
        /// <summary>
        /// код состояния
        /// </summary>
        SCStatusCode StatusCode { get; }
        /// <summary>
        /// макс. печатная ширина
        /// </summary>
        int MaxPrintWidth { get; }
        /// <summary>
        /// версия протокола
        /// </summary>
        Sip2Version Version { get; }
    }
    /// <summary>
    /// Выходящее сообщение (ACSStatus: 98)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2923")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acACSStatus)]
    public interface ISCStatusResponse : ISip2ResponsePrint {
        /// <summary>
        /// интерактивное состояние
        /// </summary>
        bool OnlineStatus { get; set; }
        /// <summary>
        /// возврат разрешен
        /// </summary>
        bool CheckinOk { get; set; }
        /// <summary>
        /// получение разрешено
        /// </summary>
        bool CheckoutOk { get; set; }
        /// <summary>
        /// политика возобновления ААС
        /// </summary>
        bool RenewalPolicy { get; set; }
        /// <summary>
        /// обновление состояния разрешено
        /// </summary>
        bool StatusUpdateOk { get; set; }
        /// <summary>
        /// переход в автономный режим разрешен
        /// </summary>
        bool OfflineOk { get; set; }
        /// <summary>
        /// время ожидания
        /// </summary>
        int TimeoutPeriod { get; set; }
        /// <summary>
        /// разрешенных попыток
        /// </summary>
        int RetriesAllowed { get; set; }
        /// <summary>
        /// дата/ время синхр
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// версия протокола
        /// </summary>
        Sip2Version Version { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; set; }
        /// <summary>
        /// название библиотеки
        /// </summary>
        string LibraryName { get; set; }
        /// <summary>
        /// поддерживаемые сообщения
        /// </summary>
        string SupportedMessages { get; set; }
        /// <summary>
        /// окончательное месторасположение
        /// </summary>
        string TerminalLocation { get; set; }
    }
    /// <summary>
    /// Интерфейс команды статуса (ACSStatus: 98)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2924")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(response = Sip2Response.acACSStatus, request = Sip2Request.scSCStatus)]
    public interface ISCStatus : ISip2Command<ISCStatusRequest, ISCStatusResponse> { }
}
