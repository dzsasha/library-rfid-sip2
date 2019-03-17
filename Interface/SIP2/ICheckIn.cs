using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scCheckin)]
    public interface ICheckInRequest : ISip2Request {
        /// <summary>
        /// отсутствие блокировки
        /// </summary>
        bool NoBlock { get; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; }
        /// <summary>
        /// дата возврата
        /// </summary>
        DateTime ReturnDate { get; }
        /// <summary>
        /// текущее месторасположение
        /// </summary>
        string CurrentLocation { get; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        string ItemIdentifier { get; }
        /// <summary>
        /// окончательный пароль
        /// </summary>
        string TerminalPassword { get; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        string ItemProperties { get; }
        /// <summary>
        /// отмена
        /// </summary>
        bool Cancel { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acCheckin)]
    public interface ICheckInResponse : ISip2ResponsePrint {
        /// <summary>
        /// разрешено
        /// </summary>
        bool Ok { get; set; }
        /// <summary>
        /// повторное намагничивание
        /// </summary>
        bool Resensitize { get; set; }
        /// <summary>
        /// магнитный носитель
        /// </summary>
        bool MagneticMedia { get; set; }
        /// <summary>
        /// сигнализация
        /// </summary>
        bool Alert { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime Date { get; set; }
        /// <summary>
        /// идентификатор учреждения
        /// </summary>
        string InstitutionId { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        string ItemIdentifier { get; set; }
        /// <summary>
        /// постоянное месторасположение
        /// </summary>
        string PermanentLocation { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        string TitleIdentifier { get; set; }
        /// <summary>
        /// сортировочная корзина
        /// </summary>
        string SortBin { get; set; }
        /// <summary>
        /// идентификатор абонента
        /// </summary>
        string PatronIdentifier { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        string ItemProperties { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE292F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(request = Sip2Request.scCheckin, response = Sip2Response.acCheckin)]
    public interface ICheckIn : ISip2Command<ICheckInRequest, ICheckInResponse> {

    }
}
