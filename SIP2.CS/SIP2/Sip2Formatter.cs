using IS.Interface.SIP2;
using System;
using System.Collections;
using System.ComponentModel;
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
            public int Compare(object x, object y) {
                if ((x is PropertyDescriptor) && (y is PropertyDescriptor)) {
                    Sip2FieldAttribute attrX = (x as PropertyDescriptor).Attributes.OfType<Sip2FieldAttribute>().First();
                    Sip2FieldAttribute attrY = (y as PropertyDescriptor).Attributes.OfType<Sip2FieldAttribute>().First();
                    if (attrX != null && attrY != null) {
                        if (attrX.Order > attrY.Order) return 1;
                        else if (attrX.Order < attrY.Order) return -1;
                        else return 0;
                    } else return 0;
                } else return 0;
            }
        }
        private ISip2Config _config { get; set; }
        #region implements IFormatter
        public SerializationBinder Binder { get; set; }

        public StreamingContext Context { get; set; }

        public ISurrogateSelector SurrogateSelector { get; set; }

        public object Deserialize(Stream serializationStream) {
            using (StreamReader sr = new StreamReader(serializationStream)) {
                string sCmd = "";
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(value).Sort(new FieldComparer())) {
                    Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().First();
                    char[] buffer = new char[1024];
                    if (attr != null && attr.Version <= _config.Version) {
                        if (String.IsNullOrEmpty(attr.Identificator) && attr.Required) {
                            prop.SetValue(value, attr.Deserialize(prop, new string(buffer, 0, sr.Read(buffer, 0, attr.Length))));
                        } else if ((!String.IsNullOrEmpty(sCmd) || (String.IsNullOrEmpty(sCmd) && sr.Read(buffer, 0, 2) == 2))) {
                            if (String.IsNullOrEmpty(sCmd)) sCmd = new string(buffer, 0, 2);
                            if (sCmd.Equals(attr.Identificator)) {
                                int iLength = 0;
                                while (sr.Peek() != Convert.ToInt32(_config.Separator) && (attr.Length == 0 || iLength < attr.Length)) {
                                    sr.Read(buffer, iLength++, 1);
                                }
                                if (attr.Length == 0) sr.Read(buffer, iLength, 1);
                                prop.SetValue(value, attr.Deserialize(prop, new string(buffer, 0, iLength)));
                                sCmd = "";
                            }
                        }
                    }
                }
            }
            return value;
        }

        public void Serialize(Stream serializationStream, object graph) {
            Sip2IdentificatorAttribute idAttr = graph.GetType().GetCustomAttributes<Sip2IdentificatorAttribute>().FirstOrDefault();
            if (idAttr != null) {
                serializationStream.Write(_config.encoding.GetBytes(((int)idAttr.response).ToString("D2")), 0, 2);
            }
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(graph).Sort(new FieldComparer())) {
                Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().First();
                if (attr != null && attr.Version <= _config.Version) {
                    if (((_config.isDebug && attr.Order < 101) || (!_config.isDebug && attr.Order < 100))) {
                        string strSerialize = attr.Serialize(prop.GetValue(graph), _config.Separator);
                        foreach (byte bt in _config.encoding.GetBytes(strSerialize)) {
                            serializationStream.WriteByte(bt);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
