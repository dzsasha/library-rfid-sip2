using IS.Interface.SIP2;
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace IS.SIP2.CS.SIP2 {
    internal class Sip2Formatter : IFormatter {
        internal Sip2Formatter(Object value, ISip2Config config) {
            this.value = value;
            this._config = config;
        }
        internal Object value { get; private set; }
        internal class FieldComparer : IComparer {
            public FieldComparer(bool exclude) {
                this._exclude = exclude;
            }
            private bool _exclude { get; set; }
            public int Compare(object x, object y) {
                if((x is PropertyDescriptor) && (y is PropertyDescriptor)) {
                    Sip2FieldAttribute attrX = (x as PropertyDescriptor).Attributes.OfType<Sip2FieldAttribute>().FirstOrDefault();
                    Sip2FieldAttribute attrY = (y as PropertyDescriptor).Attributes.OfType<Sip2FieldAttribute>().FirstOrDefault();
                    if(attrX != null && attrY != null) {
                        int ix = ((attrX.Order != -1 && String.IsNullOrEmpty(attrX.Identificator)) || !_exclude) ? attrX.Order : 1000;
                        int iy = ((attrY.Order != -1 && String.IsNullOrEmpty(attrY.Identificator)) || !_exclude) ? attrY.Order : 1000;
                        if(ix > iy)
                            return 1;
                        else if(ix < iy)
                            return -1;
                        else
                            return 0;
                    } else
                        return 0;
                } else
                    return 0;
            }
        }
        private ISip2Config _config { get; set; }

        private PropertyDescriptor GetProperty(string sCmd) {
            foreach(PropertyDescriptor prop in TypeDescriptor.GetProperties(value)) {
                Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().First();
                if(attr != null && !String.IsNullOrEmpty(attr.Identificator) && attr.Identificator.Equals(sCmd)) {
                    return prop;
                }
            }
            return null;
        }
        #region implements IFormatter
        public SerializationBinder Binder { get; set; }

        public StreamingContext Context { get; set; }

        public ISurrogateSelector SurrogateSelector { get; set; }

        public object Deserialize(Stream serializationStream) {
            using(StreamReader sr = new StreamReader(serializationStream)) {
                string sCmd = "";
                // Идем по фиксированным полям.
                foreach(PropertyDescriptor prop in TypeDescriptor.GetProperties(value).Sort(new FieldComparer(true))) {
                    Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().First();
                    if(attr != null && (!attr.Fixed || !String.IsNullOrEmpty(attr.Identificator))) {
                        break;   // Фиксированные поля кончились, выходим из этого цикла
                    } else if(attr != null) {
                        char[] buffer = new char[1024];
                        prop.SetValue(value, attr.Deserialize(prop, new string(buffer, 0, sr.Read(buffer, 0, attr.Length))));
                    }
                }
                char[] cmdBuff = new char[2];
                while(sr.Read(cmdBuff, 0, 2) == 2) {
                    char[] buffer = new char[1024];
                    sCmd = new string(cmdBuff, 0, 2);
                    Debug.Assert(!String.IsNullOrEmpty(sCmd));
                    PropertyDescriptor prop = GetProperty(sCmd);
                    Debug.Assert(prop != null);
                    Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().First();
                    Debug.Assert(attr != null);
                    int iLength = 0;
                    while(sr.Peek() != Convert.ToInt32(_config.Separator) && (attr.Length == 0 || iLength < attr.Length)) {
                        sr.Read(buffer, iLength++, 1);
                    }
                    if(!attr.Fixed) {
                        sr.Read(buffer, iLength, 1);
                    }
                    prop.SetValue(value, attr.Deserialize(prop, new string(buffer, 0, iLength)));
                }
            }
            return value;
        }

        public void Serialize(Stream serializationStream, object graph) {
            Sip2IdentificatorAttribute idAttr = graph.GetType().GetCustomAttributes<Sip2IdentificatorAttribute>().FirstOrDefault();
            if(idAttr != null) {
                serializationStream.Write(Encoding.UTF8.GetBytes(((int)idAttr.response).ToString("D2")), 0, 2);
            }
            foreach(PropertyDescriptor prop in TypeDescriptor.GetProperties(graph).Sort(new FieldComparer(false))) {
                Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().FirstOrDefault();
                if(attr != null && attr.Version <= _config.Version) {
                    if(((_config.isDebug && attr.Order < 101) || (!_config.isDebug && attr.Order < 100))) {
                        string strSerialize = attr.Serialize(prop.GetValue(graph), _config.Separator);
                        foreach(byte bt in Encoding.UTF8.GetBytes(strSerialize)) {
                            serializationStream.WriteByte(bt);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
