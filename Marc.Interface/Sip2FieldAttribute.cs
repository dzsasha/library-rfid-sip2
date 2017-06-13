using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marc.Interface
{
	/// <summary>
	/// Класс описания поля запроса
	/// </summary>
	public class Sip2FieldAttribute : Attribute
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Sip2FieldAttribute()
		{
			Number = 0;
			Required = false;
			Version = Sip2Version.v1_00;
		}
		/// <summary>
		/// Номер по порядку
		/// </summary>
		public int Number { get; set; }
		/// <summary>
		/// Обязательное поле
		/// </summary>
		public Boolean Required { get; set; }
		/// <summary>
		/// Имя команды.
		/// </summary>
		public String Identificator { get; set; }
		/// <summary>
		/// Версия
		/// </summary>
		public Sip2Version Version { get; set; }
		/// <summary>
		/// Длина поля(размер)
		/// </summary>
		public int Length { get; set; }
	}
}
