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
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        string Serialize(Sip2FieldAttribute field, object value, Char separator);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        object Deserialize(PropertyDescriptor prop, string value);
    }
}
