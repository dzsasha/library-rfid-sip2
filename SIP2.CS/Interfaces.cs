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
        string Serialize(Sip2FieldAttribute field, object value, Char separator);
    }
    /// <summary>
    /// Интрефейс для десериализации поля
    /// </summary>
    public interface ISip2Deserialize {
        object Deserialize(PropertyDescriptor prop, string value);
    }
}
