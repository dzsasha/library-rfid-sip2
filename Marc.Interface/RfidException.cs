using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marc.Interface
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
		public RfidException(string message) : base(message)
		{
		}
	}
}
