using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace IS.SIP2.CS.SIP2 {
    public class Sip2SerializeImpl : ISip2Serialize {
        #region implements ISip2Formatter
        /// <summary>
        /// Сериализовать поле
        /// </summary>
        /// <param name="field">атрибуты поля</param>
        /// <param name="value">значение</param>
        /// <param name="separator">разделитель</param>
        /// <returns>текстовое представление</returns>
        public virtual string Serialize(Sip2FieldAttribute field, object value, Char separator) {
            StringBuilder result = new StringBuilder();
            object val = value;
            if(value == null || (value != null && String.IsNullOrEmpty(value.ToString()))) {
                if(field.Required && field.Default != null) {
                    val = field.Default;
                } else if(field.Required) {
                    val = "";
                }
            }
            if(val != null && !String.IsNullOrEmpty(field.Identificator)) {
                result.Append(field.Identificator);
            }
            if(val is bool b) {
                result.Append(b ? "Y" : "N");
            } else if((val is string s) && (!String.IsNullOrEmpty(s))) {
                result.Append(s);
            } else if(val is int) {
                result.Append(String.Format("{0:D" + field.Length + "}", val));
            } else if(val is DateTime time) {
                result.Append(time.ToString("yyyyMMdd    HHmmss"));
            } else {
                result.Append("");
            }
            if(val != null && !String.IsNullOrEmpty(field.Identificator)) {
                result.Append(separator);
            }
            return result.ToString();
        }
        /// <summary>
        /// Десериализовать поле
        /// </summary>
        /// <param name="prop">поля</param>
        /// <param name="value">текстовое представление</param>
        /// <returns>поле</returns>
        public virtual object Deserialize(PropertyDescriptor prop, string value) {
            try {
                if(prop.PropertyType == typeof(int)) {
                    return Convert.ToInt32(value);
                } else if(prop.PropertyType == typeof(string)) {
                    return value;
                } else if(prop.PropertyType == typeof(DateTime)) {
                    return DateTime.ParseExact(value, "yyyyMMdd    HHmmss", CultureInfo.InvariantCulture);
                } else if(prop.PropertyType == typeof(bool)) {
                    return ("Y".Equals(value) || "1".Equals(value));
                }
            } catch(Exception) {
                return null;
            }
            return null;
        }
        #endregion
    }
}
