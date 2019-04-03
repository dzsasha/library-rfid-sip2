using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace IS.Interface.SIP2 {
    /// <summary>
    /// Интерфейс раелизации событий ошибок
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2914")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Error {
        /// <summary>
        /// Событие ошибки
        /// </summary>
        event ErrorEventHandler OnError;
    }
    /// <summary>
    /// Интерфейс настроек
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2914")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Config {
        /// <summary>
        /// Текущая версия
        /// </summary>
        Sip2Version Version { get; set; }
        /// <summary>
        /// Различные параметры из конфигурации приложения
        /// </summary>
        IField[] param { get; }
        /// <summary>
        /// Добавить к параметрам
        /// </summary>
        /// <param name="field">параметр</param>
        void AddParam(IField field);
        /// <summary>
        /// Включать отладочную информацию
        /// </summary>
        bool isDebug { get; }
        /// <summary>
        /// Символ-разграничитель для полей переменной длинны
        /// </summary>
        Char Separator { get; }
    }
    /// <summary>
    /// Общий интрейс сообщений
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2915")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Answer {
        /// <summary>
        /// последовательный номер
        /// </summary>
        int Sequence { get; set; }
        /// <summary>
        /// Контрольная сумма
        /// </summary>
        int CheckSum { get; set; }
    }
    /// <summary>
    /// Интерфейс выходящего сообщения
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2916")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Response : ISip2Answer { }
    /// <summary>
    /// Интерфейс выходящего сообщения с предопределнными полями
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2917")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2ResponsePrint : ISip2Response {
        /// <summary>
        /// экранное сообщение
        /// </summary>
        string ScreenMessage { get; set; }
        /// <summary>
        /// печатная строка
        /// </summary>
        string PrintLine { get; set; }
    }
    /// <summary>
    /// Интрефейс входящего сообщения
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2918")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Request : ISip2Answer { }
    /// <summary>
    /// Виртуальный интерфейс команд SIP2-протокола
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE2919")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Cmd : ISip2Error { }
    /// <summary>
    /// Интерфейс выполнения команды
    /// </summary>
    /// <typeparam name="T">тип выходного сообщения</typeparam>
    /// <typeparam name="K">тип входящего сообщения</typeparam>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE291A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2Command<in T, K> : ISip2Cmd where T : ISip2Request where K : ISip2Response {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="config">конфигурация</param>
        /// <param name="request">входящее сообщение</param>
        /// <param name="response">выходящее сообщение</param>
        /// <returns>успешность выполнения</returns>
        bool execute(ISip2Config config, T request, ref K response);
    }
    /// <summary>
    /// Инициализационный интерфейс
    /// </summary>
    [Guid("4AFA5E2E-786F-4CD3-B811-44A867DE291B")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface ISip2 : ISip2Error {
        /// <summary>
        /// Инициализация
        /// </summary>
        /// <param name="config">Конфигурация</param>
        /// <returns>успешность инициализации</returns>
        bool init(ISip2Config config);
        /// <summary>
        /// Список доступных команд
        /// </summary>
        ISip2Cmd[] commands { get; }
    }
}
