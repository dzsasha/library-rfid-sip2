using System;
using System.Collections.Generic;
using IS.Interface;
using IS.Interface.SIP2;
using IS.SIP2.CS.SIP2;
using System.ComponentModel;

namespace IS.SIP2.CS {
    /// <summary>
    /// Интерфейс для сериализации поля
    /// </summary>
    public interface ISip2Serialize {
        /// <summary>
        /// Сериализовать поле
        /// </summary>
        /// <param name="field">атрибуты поля</param>
        /// <param name="value">значение</param>
        /// <param name="separator">разделитель</param>
        /// <returns>текстовое представление</returns>
        string Serialize(Sip2FieldAttribute field, object value, Char separator);
        /// <summary>
        /// Десериализовать поле
        /// </summary>
        /// <param name="prop">поля</param>
        /// <param name="value">текстовое представление</param>
        /// <returns>поле</returns>
        object Deserialize(PropertyDescriptor prop, string value);
    }
}
