using IS.Interface.SIP2;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace IS.SIP2.CS.SIP2 {
    /// <summary>
    /// Описание атрибута поля для SIP2-протокола
    /// </summary>
    public class Sip2FieldAttribute : Attribute {
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        /// <param name="order">Порядок при сериализации</param>
        public Sip2FieldAttribute(int order, int iLength) : this() {
            this.Order = order;
            this.Length = iLength;
            this.Fixed = true;
        }
        public Sip2FieldAttribute() {
            this.SerializeType = typeof(Sip2SerializeImpl);
        }
        /// <summary>
        /// Описание поля
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Длинна поля
        /// </summary>
        public int Length { get; set; } = 0;
        /// <summary>
        /// Обязательное поле
        /// </summary>
        public bool Required { get; set; } = false;
        /// <summary>
        /// Версия протокола
        /// </summary>
        public Sip2Version Version { get; set; } = Sip2Version.V100;
        /// <summary>
        /// Текстовый идентификатор поля
        /// </summary>
        public string Identificator { get; set; }
        /// <summary>
        /// Порядок при сериализации
        /// </summary>
        public int Order { get; set; } = -1;
        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public object Default { get; set; }
        /// <summary>
        /// Функция сериализации поля
        /// </summary>
        /// <param name="value">значение</param>
        /// <param name="separator">разделитель</param>
        /// <returns></returns>
        public string Serialize(object value, char separator) {
            Debug.Assert(Order > 0);
            return _serialize.Serialize(this, value, separator);
        }
        /// <summary>
        /// Функция десериализации поля
        /// </summary>
        /// <param name="prop">поле</param>
        /// <param name="value">строковое значение</param>
        /// <returns>значение</returns>
        public object Deserialize(PropertyDescriptor prop, string value) {
            return _serialize.Deserialize(prop, value);
        }
        private ISip2Serialize _serialize { get; set; }
        /// <summary>
        /// Тип для сериализации/десериализации поля
        /// </summary>
        public Type SerializeType {
            get { return _serialize.GetType(); }
            set => _serialize = (Activator.CreateInstance(value) as ISip2Serialize);
        }
        public Boolean Fixed { get; set; } = false;
    }
}