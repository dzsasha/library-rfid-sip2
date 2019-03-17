using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.Interface
{
    /// <summary>
    /// Настроечные поля для добавления RFID-оборудования
    /// </summary>
	[Guid("4AFA5E2E-786F-4CD3-B811-44A867DE290C")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    public interface IConfig
    {
        /// <summary>
        /// Строка com-объекта
        /// </summary>
        string ProgId { get; }
        /// <summary>
        /// Поля для настройки в config-файле
        /// </summary>
        IField[] Fields { get; }
    }
}
