using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// состояние выдачи на абонемент
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2925")]
    [ComVisible(true)]
    public enum Sip2CirculationStatus {
        /// <summary>
        /// Other
        /// </summary>
        Other = 1,
        /// <summary>
        /// on order
        /// </summary>
        OnOrder = 2,
        /// <summary>
        /// avalable
        /// </summary>
        Available = 3,
        /// <summary>
        /// charged
        /// </summary>
        Charged = 4,
        /// <summary>
        /// 
        /// </summary>
        ChargedNotRecall = 5,
        InProcess = 6,
        ReCalled = 7,
        HoldShelf = 8,
        ReShelved = 9,
        InTransit = 10,
        ClaimedReurned = 11,
        Lost = 12,
        Missing = 13
    }
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2926")]
    [ComVisible(true)]
    public enum SecurityMarker {
        Other = 0,
        None = 1,
        Tattle = 2,
        Whisper = 3
    }
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2927")]
    [ComVisible(true)]
    public enum Sip2MediaType {
        Other = 000,
        Book = 001,
        Magazine = 002,
        BoundJournal = 003,
        AudioType = 004,
        VideoType = 005,
        CDROM = 006,
        Diskette = 007,
        BookWithDiskette = 008,
        BookWithCD = 009,
        BookWithAudioTape = 010
    }
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2928")]
    [ComVisible(true)]
    public enum Sip2FeeType {
        Other = 01,
        Administrative = 02,
        Damage = 03,
        Overdue = 04,
        Processing = 05,
        Rental = 06,
        Replacement = 07,
        ComputerAccessCharge = 08,
        HoldFee = 09
    }
    /// <summary>
    /// Входящее сообщение (Item Information: 17)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2927")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Request.scItemInformation)]
    public interface IItemInformationRequest : ISip2Request {
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime date { get; }
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
    }
    /// <summary>
    /// Выходящее сообщение (Item Information: 18)
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2928")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(Sip2Response.acItemInformation)]
    public interface IItemInformationResponse : ISip2ResponsePrint {
        /// <summary>
        /// состояние выдачи на абонемент
        /// </summary>
        Sip2CirculationStatus CirculationStatus { get; set; }
        /// <summary>
        /// маркер безопасности
        /// </summary>
        SecurityMarker SecurityMarker { get; set; }
        /// <summary>
        /// тип взноса
        /// </summary>
        Sip2FeeType FeeType { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime date { get; set; }
        /// <summary>
        /// длина очереди удержания
        /// </summary>
        int HoldQueueLength { get; set; }
        /// <summary>
        /// дата операции
        /// </summary>
        DateTime DueDate { get; set; }
        /// <summary>
        /// дата отзыва
        /// </summary>
        DateTime RecallDate { get; set; }
        /// <summary>
        /// дата отзыва
        /// </summary>
        DateTime HoldPickupDate { get; set; }
        /// <summary>
        /// идентификатор единицы
        /// </summary>
        string ItemIdentifier { get; set; }
        /// <summary>
        /// идентификатор названия
        /// </summary>
        string TitleIdentifier { get; set; }
        /// <summary>
        /// владелец
        /// </summary>
        string Owner { get; set; }
        /// <summary>
        /// валюта
        /// </summary>
        string CurrencyType { get; set; }
        /// <summary>
        /// сумма взноса
        /// </summary>
        double FeeAmount { get; set; }
        /// <summary>
        /// тип носителя
        /// </summary>
        Sip2MediaType MediaType { get; set; }
        /// <summary>
        /// постоянное месторасположение
        /// </summary>
        string PermanentLocation { get; set; }
        /// <summary>
        /// текущее месторасположение
        /// </summary>
        string CurrentLocation { get; set; }
        /// <summary>
        /// свойства единицы
        /// </summary>
        string ItemProperties { get; set; }
    }
    /// <summary>
    /// Интерфейс информации о экземпляре
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2929")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    [Sip2Identificator(response = Sip2Response.acItemInformation, request = Sip2Request.scItemInformation)]
    public interface IItemInformation : ISip2Command<IItemInformationRequest, IItemInformationResponse> {
    }
}
