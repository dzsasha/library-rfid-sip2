using IS.Interface.SIP2;
using System;
using System.Linq;
using System.ComponentModel;
using System.Globalization;
using System.Configuration;

namespace IS.SIP2.CS.SIP2 {
    public class Sip2AnswerImpl : ISip2Answer {
        protected Sip2AnswerImpl() {
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
            string sum = value.Substring(value.LastIndexOf("AZ", StringComparison.Ordinal) + 2, 4);
            string chsum = impl.checksum(value.Substring(0, value.LastIndexOf("AZ", StringComparison.Ordinal) + 2));
            return chsum.Equals(sum);
        }
        internal class CheckSumImpl : ISip2Serialize {
            private static readonly ISip2Config _config = ((ServiceSection)ConfigurationManager.GetSection(ServiceSection.SectionName)).Answers;
            public object Deserialize(PropertyDescriptor prop, string value) {
                return Int32.Parse(value, NumberStyles.HexNumber);
            }
            public string checksum(string str) {
                uint result = _config.encoding.GetBytes(str).Aggregate<byte, uint>(0, (current, bt) => current + bt);
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

        private class SequenceImpl : ISip2Serialize {
            public object Deserialize(PropertyDescriptor prop, string value) {
                if (String.IsNullOrEmpty(value)) {
                    return -1;
                } else {
                    return Convert.ToInt32(value);
                }
            }

            public string Serialize(Sip2FieldAttribute field, object value, Char separator) {
                return (value == null || ((int)value).Equals(-1)) ? "" : $"{field.Identificator}{(int) value:D1}";
            }
        }
        #region implementation of ISip2Answer
        /// <summary>
        /// последовательный номер
        /// </summary>
        [Sip2Field(SerializeType = typeof(CheckSumImpl), Identificator = "AZ", Description = "контрольная сумма", Length = 4, Fixed = true, Order = 101)]
        public int CheckSum { get; set; }
        /// <summary>
        /// Контрольная сумма
        /// </summary>
        [Sip2Field(SerializeType = typeof(SequenceImpl), Identificator = "AY", Description = "последовательный номер", Length = 1, Fixed = true, Order = 100)]
        public int Sequence { get; set; }
        #endregion

    }
}
