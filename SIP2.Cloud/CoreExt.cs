using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Interface;
using IS.Interface.SIP2;
using System.Net;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    internal static class CoreExt {
        internal static IField GetField(this IField[] fields, String name) {
            IField result = null;
            foreach (IField field in fields.Where(field => field.Name.Equals(name))) {
                result = field;
            }
            return result;
        }
        internal static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        internal static T GetAnswer<T>(this IField[] param, T message) {
            if (param.GetField("server").Value == null) {   // Проверка на не пустое значение сервера NCIP
                Log.For(message).Error("app.config not param 'server'");
                throw new Exception("CoreExt.GetAnswer", new ArgumentNullException("app.config not param 'server'"));
            }
            using (WebClient client = new WebClient()) {
                client.Encoding = Encoding.UTF8;
                string strMessage = Serializer.SerializeObject(message, typeof(T));
                Log.For(message).DebugFormat("GetAnswer -> : {0}", strMessage);
                string strAnswer = client.UploadString(Convert.ToString(param.GetField("server").Value), strMessage);
                Log.For(message).DebugFormat("GetAnswer <- : {0}", strAnswer);
                return (T)Serializer.DeserializeObject(strAnswer, typeof(T));
            }
        }

        internal static T getItem<T>(this NCIPMessage message) {
            foreach (Object obj in message.Items) {
                if (typeof(T).Equals(obj.GetType())) {
                    return (T)obj;
                }
            }
            return default(T);
        }
        internal static void setPrintLine(this ISip2ResponsePrint response, ISip2Config config, string value) {
            if (config.param.GetField("MaxPrintWidth").Value != null && value != null && value.Length > Convert.ToInt32(config.param.GetField("MaxPrintWidth").Value)) {
                response.PrintLine = value.Substring(0, Convert.ToInt32(config.param.GetField("MaxPrintWidth").Value));
            }
        }
    }
}
