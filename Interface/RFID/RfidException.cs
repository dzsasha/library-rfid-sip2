using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.Interface.RFID
{
	/// <summary>
	/// Класс ошибок для RFID-оборудования
	/// </summary>
	public class RfidException : Exception
	{
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="message">строка ошибки</param>
        public RfidException(string message) : this(message, 0)
		{
		}
        /// <summary>
        /// Конструктор с кодом ошибки
        /// </summary>
        /// <param name="message">строка ошибки</param>
        /// <param name="code">код ошибки</param>
        public RfidException(string message, int code) : base(message) {
            Code = code;
        }
        /// <summary>
        /// Код ошибки
        /// </summary>
        public int Code { get; private set; }
    }
}
