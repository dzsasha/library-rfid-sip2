﻿using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;

namespace IS.SIP2.CS.SIP2 {
    public class Sip2AnswerImpl : ISip2Answer {
        public Sip2AnswerImpl() {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this)) {
                Sip2FieldAttribute attr = prop.Attributes.OfType<Sip2FieldAttribute>().First();
                if (attr.Required) {
                    if (typeof(bool).ToString().Equals(prop.PropertyType.ToString())) {
                        prop.SetValue(this, false);
                    } else if (typeof(string).ToString().Equals(prop.PropertyType.ToString())) {
                        prop.SetValue(this, "");
                    } else if (typeof(DateTime).ToString().Equals(prop.PropertyType.ToString())) {
                        prop.SetValue(this, DateTime.Now);
                    } else if (typeof(int).ToString().Equals(prop.PropertyType.ToString())) {
                        prop.SetValue(this, 0);
                    }
                }
            }
        }
        public static bool verify(string value) {
            CheckSumImpl impl = new CheckSumImpl();
            string sum = value.Substring(value.LastIndexOf("AZ") + 2, 4);
            string chsum = impl.checksum(value.Substring(0, value.LastIndexOf("AZ") + 2));
            return chsum.Equals(sum);
        }
        internal class CheckSumImpl : ISip2Serialize, ISip2Deserialize {
            public object Deserialize(PropertyDescriptor prop, string value) {
                return Int32.Parse(value, NumberStyles.HexNumber);
            }
            public string checksum(string str) {
                uint result = 0;
                foreach (byte bt in Encoding.UTF8.GetBytes(str)) {
                    result += bt;
                }
                result = result & 0xFFFF;
                result = (uint)(-((int)result));
                result = result & 0xFFFF;
                return result.ToString("X4");
            }

            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                string result = $"{value.ToString()}{field.Identificator}";
                return $"{result}{checksum(result)}";
            }
        }
        internal class SequenceImpl : ISip2Serialize, ISip2Deserialize {

            public object Deserialize(PropertyDescriptor prop, string value) {
                return Convert.ToInt32(value);
            }

            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return $"{field.Identificator}{(int) value:D1}";
            }
        }
        #region implementation of ISip2Answer
        /// <summary>
        /// последовательный номер
        /// </summary>
        [Sip2Field(101, SerializeType = typeof(CheckSumImpl), DeserializeType = typeof(CheckSumImpl), Identificator = "AZ", Length = 4, Description = "контрольная сумма")]
        public int CheckSum { get; set; }
        /// <summary>
        /// Контрольная сумма
        /// </summary>
        [Sip2Field(100, SerializeType = typeof(SequenceImpl), DeserializeType = typeof(SequenceImpl), Identificator = "AY", Length = 1, Description = "последовательный номер")]
        public int Sequence { get; set; }
        #endregion

    }
}
