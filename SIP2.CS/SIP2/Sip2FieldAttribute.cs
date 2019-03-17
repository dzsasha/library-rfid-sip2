using IS.Interface.SIP2;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace IS.SIP2.CS.SIP2 {
    /// <summary>
    /// Описание атрибута поля для SIP2-протокола
    /// </summary>
    public class Sip2FieldAttribute : Attribute, ISip2Serialize, ISip2Deserialize {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="order">Порядок при сериализации</param>
        public Sip2FieldAttribute(int order) {
            this.Order = order;
            this.Length = 0;
            this.Required = false;
            this.Version = Sip2Version.V100;
            this._serialize = (this as ISip2Serialize);
            this._deserialize = (this as ISip2Deserialize);
        }
        /// <summary>
        /// Описание поля
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Длинна поля
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Обязательное поле
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Версия протокола
        /// </summary>
        public Sip2Version Version { get; set; }
        /// <summary>
        /// Текстовый идентификатор поля. Его наличие считается, что поле не имеет фиксированной длинны,
        /// т.е. после него надо ставить разделитель
        /// </summary>
        public string Identificator { get; set; }
        /// <summary>
        /// Порядок при сериализации
        /// </summary>
        public int Order { get; }
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public object Default { get; set; }
        /// <summary>
        /// Функция сериализации поля
        /// </summary>
        public string Serialize(object value, char separator) {
            return _serialize.Serialize(this, value, separator);
        }
        public object Deserialize(PropertyDescriptor prop, string value) {
            return _deserialize.Deserialize(prop, value);
        }
        private ISip2Serialize _serialize { get; set; }
        private ISip2Deserialize _deserialize { get; set; }
        public Type SerializeType {
            get { return _serialize.GetType(); }
            set { _serialize = (Activator.CreateInstance(value) as ISip2Serialize); }
        }
        public Type DeserializeType {
            get { return _deserialize.GetType(); }
            set { _deserialize = (Activator.CreateInstance(value) as ISip2Deserialize); }
        }

        #region implements ISip2Formatter
        string ISip2Serialize.Serialize(Sip2FieldAttribute field, object value, Char separator) {
            StringBuilder result = new StringBuilder();
            object val = value;
            if (value == null) {
                val = field.Default;
            }
            if (val != null && !String.IsNullOrEmpty(Identificator)) {
                result.Append(Identificator);
            }
            if (val is bool) {
                result.Append((bool)val ? "Y" : "N");
            } else if ((val is string) && (!String.IsNullOrEmpty((val as string)))) {
                result.Append(val.ToString());
            } else if (val is int) {
                String sFormat = "{0:D" + Length + "}";
                result.Append(String.Format(sFormat, val));
            } else if (val is DateTime) {
                result.Append(((DateTime)val).ToString("yyyyMMdd    HHmmss"));
            } else {
                return "";
            }
            if (value != null && !String.IsNullOrEmpty(Identificator)) {
                result.Append(separator);
            }
            return result.ToString();
        }

        object ISip2Deserialize.Deserialize(PropertyDescriptor prop, string value) {
            if (!String.IsNullOrEmpty(value)) {
                try {
                    if (prop.PropertyType == typeof(int)) {
                        return Convert.ToInt32(value);
                    } else if (prop.PropertyType == typeof(string)) {
                        return value;
                    } else if (prop.PropertyType == typeof(DateTime)) {
                        return DateTime.ParseExact(value, "yyyyMMdd    HHmmss", CultureInfo.InvariantCulture);
                    } else if (prop.PropertyType == typeof(bool)) {
                        return ("Y".Equals(value) || "1".Equals(value));
                    }
                } catch (Exception) {
                    return null;
                }
            }
            return null;
        }
        #endregion
    }
}