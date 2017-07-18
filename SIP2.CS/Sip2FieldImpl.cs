using System;
using System.Globalization;
using IS.Interface;
using IS.Interface.SIP2;

namespace IS.SIP2.CS {
	/// <summary>
	/// Реализация интерфейса ISip2Field
	/// </summary>
	public class Sip2FieldImpl : FieldImpl, ISip2Field
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public Sip2FieldImpl() {
			Required = false;
			Identificator = "";
			Version = Sip2Version.V100;
			Length = 0;
		}
		/// <summary>
		/// Обязательное поле
		/// </summary>
		public bool Required { get; set; }
		/// <summary>
		/// Идентификатор поля (если нужен)
		/// </summary>
		public string Identificator { get; set; }
		/// <summary>
		/// Версия поля
		/// </summary>
		public Sip2Version Version { get; set; }
		/// <summary>
		/// Длинна фиксированного поля
		/// </summary>
		private int _length;
		public int Length
		{
			get {
				switch (Type)
				{
					case TypeField.Boolean: return 1;
					case TypeField.Char: return 1;
					case TypeField.DateTime: return 18;
					default: return _length;
				}
			}
			set { _length = value; }
		}
		/// <summary>
		/// Вывести значение как строку
		/// </summary>
		/// <returns>строка значения</returns>
		public override string ToString()
		{
			string result = "";
			switch (Type) {
				case TypeField.Boolean:
					result += (Convert.ToBoolean(Value) ? "Y" : "N");
					break;
				case TypeField.Char:
					result += (Convert.ToChar(Value).ToString(CultureInfo.InvariantCulture));
					break;
				case TypeField.DateTime:
					result += ((DateTime)Value).ToString("yyyyMMdd    hhmmss");
					break;
				case TypeField.Integer:
					result += Convert.ToString(Value);
					break;
				default:
					result += Value.ToString();
					break;
			}
			return result;
		}

		public override void SetValue(object value)
		{
			if (!String.IsNullOrEmpty(value.ToString()))
			{
				switch (Type)
				{
					case TypeField.Boolean:
						base.SetValue(Convert.ToBoolean(value.ToString()));
						break;
					case TypeField.Char:
						base.SetValue(Convert.ToChar(value.ToString()));
						break;
					case TypeField.DateTime:
						base.SetValue(DateTime.ParseExact(value.ToString(), "yyyyMMdd    hhmmss", CultureInfo.InvariantCulture));
						break;
					case TypeField.Integer:
						base.SetValue(Convert.ToInt32(value.ToString()));
						break;
					default:
						base.SetValue(value.ToString());
						break;
				}
			}
			else
			{
				base.SetValue(null);
			}
		}
	}
}
