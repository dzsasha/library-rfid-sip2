using System;
using System.Data.Odbc;
using System.Globalization;
using IS.Interface;
using IS.Interface.SIP2;

namespace IS.SIP2.CS
{
	/// <summary>
	/// Поле последовательного номера
	/// </summary>
	public class Sip2SequenceField : Sip2FieldImpl
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Sip2SequenceField() {
			Required = false;
			Identificator = "AY";
			Length = 1;
			Type = TypeField.Integer;
			Description = "последовательный номер";
			Name = "sequence";
		}
		/// <summary>
		/// Значение поля как строка
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Identificator + ((int)Value).ToString("D1");
		}
	}
	/// <summary>
	/// Поле контрольная сумма
	/// </summary>
	public class Sip2CheckSumField : Sip2FieldImpl
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Sip2CheckSumField() {
			Required = false;
			Identificator = "AZ";
			Length = 4;
			Type = TypeField.Integer;
			Description = "контрольная сумма";
			Name = "checksum";
		}
		/// <summary>
		/// Установить значение
		/// </summary>
		/// <param name="value">значение</param>
		public override void SetValue(object value)
		{
			if (String.IsNullOrEmpty(Value.ToString()))
			{
				base.SetValue(Int32.Parse(value.ToString(), NumberStyles.HexNumber));
			}
			else if (Int32.Parse(value.ToString(), NumberStyles.HexNumber) != Convert.ToInt32(Value))
			{
				throw new Exception();
			}
		}
		/// <summary>
		/// Значение поля как строка
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ((int)Value).ToString("X4");
		}
	}
}
