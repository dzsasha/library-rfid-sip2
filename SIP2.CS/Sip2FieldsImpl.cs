using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using IS.Interface;
using IS.Interface.SIP2;

namespace IS.SIP2.CS
{
	/// <summary>
	/// Поля входящего/ответного сообщения
	/// </summary>
	/// <typeparam name="T">входящий/ответный тип сообщения</typeparam>
	public class Sip2FieldsImpl<T> : List<Sip2FieldImpl>, ISip2Fields<T>
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		/// <param name="cmd">команда</param>
		public Sip2FieldsImpl(ISip2Cmd<T> cmd)
		{
			_command = cmd.Command;
		}

		private string checksum(string str)
		{
			ulong result = str.Aggregate<char, ulong>(0, (current, c) => current + Convert.ToUInt64(c));
			result &= 0xFFFF;
			result = (ulong)(-((long)result));
			result &= 0xFFFF;
			return result.ToString("X4");
		}
		#region implementation interface ISip2Cmd<T>

		private readonly T _command;
		/// <summary>
		/// номер запроса
		/// </summary>
		T ISip2Cmd<T>.Command { get { return _command; } }
		#endregion

		/// <summary>
		/// Проверка полей на правильность заполнения
		/// </summary>
		/// <param name="version">версия протокола</param>
		/// <returns>успешность порверки</returns>
		#region implementation interface ISip2Fields<T>
		bool ISip2Fields<T>.Validate(Sip2Version version)
		{
			bool result = true;
			foreach (ISip2Field field in this)
			{
				result &= Convert.ToInt32(field.Version) <= Convert.ToInt32(version);
				if (field.Required)
				{
					result &= field.Value != null;
				}
			}
			return result;
		}
		/// <summary>
		/// Сериализация полей
		/// </summary>
		/// <param name="separator">разделитель полей переменной длинны</param>
		/// <param name="debug">использовать отладку</param>
		/// <returns>ответная строка</returns>
		string ISip2Fields<T>.ToString(Char separator, bool debug)
		{
			StringBuilder result = new StringBuilder((this as ISip2Cmd<T>).ToString());
			foreach (ISip2Field field in this)
			{
				if (!String.IsNullOrEmpty(field.Identificator))
				{
					result.Append(field.Identificator);
				}
				if (field.Name.Equals("checksum"))
				{
					result.Append(field.Identificator);
					field.Value = checksum(result.ToString());
					result.Append(field.ToString());
				}
				else if (field.Name.Equals("sequence") && debug)
				{
					result.Append(field.ToString());
				}
				else
				{
					result.Append(field.ToString());
				}
				if (field.Value != null && !String.IsNullOrEmpty(field.Identificator) && field.Length == 0)
				{
					result.Append(separator);
				}
			}
			return result.ToString() + "\r";
		}
		/// <summary>
		/// Десериализация полей
		/// </summary>
		/// <param name="str">входная строка</param>
		/// <param name="separator">разделитель полей переменной длинны</param>
		void ISip2Fields<T>.FillFields(string str, Char separator)
		{
			using (StreamReader sr = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(str.Substring(2)))))
			{
				char[] buffer = new char[1024];
				foreach (ISip2Field field in this)
				{
					if (String.IsNullOrEmpty(field.Identificator) && field.Required)
					{
						field.Value = new string(buffer, 0, sr.Read(buffer, 0, field.Length));
					}
				}
				while (sr.Read(buffer, 0, 2) == 2)
				{
					String sCmd = new string(buffer, 0, 2);
					int iLength = 0;
					foreach (ISip2Field field in this)
					{
						if (sCmd.Equals(field.Identificator))
						{
							if (field.Length == 0)
							{
								while (sr.Peek() != Convert.ToInt32(separator))
								{
									sr.Read(buffer, iLength++, 1);
								}
								sr.Read(buffer, iLength, 1);
							}
							else if (sCmd.Equals(field.Identificator) && field.Length != 0)
							{
								iLength = sr.Read(buffer, 0, field.Length);
							}
							field.Value = new string(buffer, 0, iLength);
						}
					}
				}
			}
			try
			{
				(this as ISip2Fields<T>).ToString(separator, true);
			}
			catch (Exception)
			{
				
			}
		}
		#endregion

		#region implementation interface IClonable
		object ICloneable.Clone()
		{
			Sip2FieldsImpl<T> result = new Sip2FieldsImpl<T>(new Sip2Cmd<T>((this as ISip2Cmd<T>).Command));
			result.AddRange(this);
			return result;
		}
		#endregion

		public new IEnumerator<ISip2Field> GetEnumerator()
		{
			return (this as List<Sip2FieldImpl>).GetEnumerator();
		}
	}
}
