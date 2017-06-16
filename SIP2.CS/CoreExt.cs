using System;
using System.Globalization;
using System.Linq;
using InformSystema.Interface;
using InformSystema.Interface.SIP2;

namespace InformSystema.SIP2.CS
{
	/// <summary>
	/// Класс расширений
	/// </summary>
	public static class CoreExt
	{
		/// <summary>
		/// Получение поля по имени
		/// </summary>
		/// <param name="fields">список полей</param>
		/// <param name="identificator">имя поля</param>
		/// <returns>объект поля</returns>
		internal static Sip2FieldImpl GetField(this Sip2FieldImpl[] fields, String identificator)
		{
			return fields.FirstOrDefault(field => field.Identificator.Equals(identificator));
		}

		internal static string GetValue(this string[] arr, String identificator)
		{
			string result = null;
			foreach (string s in arr.Where(s => s.Substring(0,2).Equals(identificator)))
			{
				return s.Substring(0, 2);
			}
			return result;
		}

		/// <summary>
		/// Сериализация в строку ответа
		/// </summary>
		/// <param name="fields">поля ответа</param>
		/// <param name="answer">сервер подготовки ответов</param>
		/// <param name="separator">разделитель</param>
		/// <returns>строка ответа</returns>
		internal static String Serialize(this Sip2FieldImpl[] fields, ISip2Answers answer, String separator)
		{
			String result = "";
			foreach (Sip2FieldImpl field in fields)
			{
				if (field.Verify(answer) && field.Value != null)
				{
					if (!String.IsNullOrEmpty(field.Identificator)) result += field.Identificator;
					switch (field.Type)
					{
						case TypeField.Boolean:
							result += ((field.Value is Boolean).Equals(true) ? "Y" : "N");
							break;
						case TypeField.DateTime:
							result += ((DateTime) field.Value).ToString("ddMMYYYY    hhmmss");
							break;
						case TypeField.Char:
							result += field.Value;
							break;
						default:
							result += field.Value;
							break;
					}
					if (!String.IsNullOrEmpty(field.Identificator)) result += separator;
				}
				else
				{
					throw new Exception("Ошибка в значениях полей.");
				}
			}
			return result;
		}

		internal static Sip2FieldImpl[] Deserialize(this Sip2FieldImpl[] fields, String str, ISip2Answers answer, Char separator)
		{
			int iCurr = 0;
			string[] arr = str.Split(new []{separator});
			foreach (Sip2FieldImpl field in fields)
			{
				if (field.Required && String.IsNullOrEmpty(field.Identificator))
				{
					switch (field.Type)
					{
						case TypeField.Char:
							field.Value = str.Substring(iCurr++, 1);
							arr[0] = arr[0].Substring(1);
							break;
						case TypeField.Boolean:
							field.Value = str.Substring(iCurr++, 1).Equals("Y") ? true : false;
							arr[0] = arr[0].Substring(1);
							break;
						case TypeField.DateTime:
							field.Value = DateTime.ParseExact(str.Substring(iCurr, 18), "ddMMYYYY    hhmmss", new CultureInfo("ru-RU"));
							iCurr += 18;
							arr[0] = arr[0].Substring(18);
							break;
						case TypeField.String:
							field.Value = str.Substring(iCurr, field.Length);
							iCurr += field.Length;
							arr[0] = arr[0].Substring(field.Length);
							break;
					}
				}
				else if (!String.IsNullOrEmpty(field.Identificator))
				{
					string s = arr.GetValue(field.Identificator);
					if (s != null)
					{
						field.Value = s;
					}
				}
			}
			return fields;
		}
	}
}
