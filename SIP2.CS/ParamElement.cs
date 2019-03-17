using System;
using System.Configuration;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.SIP2.CS {
    public class ParamElement : ConfigurationElement, IField {
        public ParamElement() { }
        #region IField
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }

        [ConfigurationProperty("description")]
        public string Description {
            get { return ((string)(base["description"])); }
            set { base["description"] = value; }
        }

        [ConfigurationProperty("type")]
        public TypeField Type {
            get { return ((TypeField)(base["type"])); }
            set { base["type"] = value; }
        }

        public object Value {
            get {
                switch(Type) {
                    case TypeField.Boolean:
                        return Convert.ToBoolean(Test);
                    case TypeField.Integer:
                        return Convert.ToInt32(Test);
                    case TypeField.String:
                        return Convert.ToString(Test);
                    default:
                        return null;
                }
            }
            set { Test = value.ToString(); }
        }

        public event EventHandler OnChange;

        #endregion

        [ConfigurationProperty("value")]
        public string Test {
            get { return (string)base["value"]; }
            set { base["value"] = value; }
        }
    }
}
