using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS.SIP2 {
    public delegate string SerializeFiledDelegate(Sip2FieldAttribute field, object value);
    public delegate object DeserializeFiledDelegate(PropertyDescriptor prop, string value);
}
