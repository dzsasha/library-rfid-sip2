using System;
using System.Collections.Generic;
using System.IO;
using IS.Interface.SIP2;
using IS.SIP2.CS.SIP2;
using System.Reflection;
using System.Runtime.Serialization;

namespace IS.SIP2.CS {
    internal static class CoreExt {
        private static Dictionary<int, Type> cacheCommand = new Dictionary<int, Type>();
        internal static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute {
            var attributes = enumVal.GetType().GetMember(enumVal.ToString())[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }
        private static Stream GetStream(this string str) {
            MemoryStream result = new MemoryStream();
            StreamWriter reader = new StreamWriter(result);
            reader.Write(str);
            reader.Flush();
            result.Position = 0;
            return result;
        }
        internal static string doMessage(this ISip2 server, string message, ISip2Config config, ref string lastCmd) {
            ISip2Request request = null;
            ISip2Response response = null;
            string msg = message;
            if (((Sip2Request)Convert.ToInt32(message.Substring(0, 2))).Equals(Sip2Request.scRequestACSResend)) {
                msg = lastCmd;
            } else {
                lastCmd = message;
            }
            foreach (var cmd in server.commands) {
                foreach (var typeCmd in cmd.GetType().FindInterfaces((Type a, object obj) => {
                    Sip2IdentificatorAttribute attr = a.GetCustomAttribute<Sip2IdentificatorAttribute>();
                    if (attr != null && attr.request.Equals((Sip2Request)obj)) {
                        if (cacheCommand.ContainsKey((int)attr.request)) {  // Проверяем в кеше, если уже было определно, не надо будет определять новые
                            request = (ISip2Request)Activator.CreateInstance(cacheCommand[(int)attr.request]);
                        }
                        if (cacheCommand.ContainsKey((int)attr.response)) {
                            response = (ISip2Response)Activator.CreateInstance(cacheCommand[(int)attr.response]);
                        }
                        if (request == null || response == null) {
                            foreach (Type typeImpl in Assembly.GetEntryAssembly().GetTypes()) {
                                Sip2IdentificatorAttribute typeAttr = typeImpl.GetCustomAttribute<Sip2IdentificatorAttribute>();
                                if (typeAttr != null && typeAttr.request.Equals(attr.request)) {
                                    request = (ISip2Request)Activator.CreateInstance(typeImpl);
                                    if (!cacheCommand.ContainsKey((int)attr.request)) cacheCommand.Add((int)attr.request, typeImpl);
                                } else if (typeAttr != null && typeAttr.response.Equals(attr.response)) {
                                    response = (ISip2Response)Activator.CreateInstance(typeImpl);
                                    if (!cacheCommand.ContainsKey((int)attr.response)) cacheCommand.Add((int)attr.response, typeImpl);
                                }
                            }
                        }
                        return true;
                    }
                    return false;
                }, (Sip2Request)Convert.ToInt32(msg.Substring(0, 2)))) {
                    foreach (var typeImpl in typeCmd.FindInterfaces((Type a, object obj) => { return a.GetMethod("execute") != null; }, null)) {
                        IFormatter formatter = new Sip2Formatter(request, config);
                        using (Stream stream = msg.Substring(2).GetStream()) {
                            request = (ISip2Request)formatter.Deserialize(stream);
                        }
                        if (request != null) {
                            var result = typeImpl.GetMethod("execute")?.Invoke(cmd, new object[] { config, request, response });
                            if ((result is bool) && (bool)result) {
                                using (Stream writer = new MemoryStream()) {
                                    response.Sequence = request.Sequence;
                                    formatter.Serialize(writer, response);
                                    Sip2FieldAttribute attr = response.GetType().GetProperty("CheckSum").GetCustomAttribute<Sip2FieldAttribute>();
                                    StreamReader rdr = new StreamReader(writer);
                                    writer.Position = 0;
                                    return ((attr != null) ? attr.Serialize(rdr.ReadToEnd(), '\0') : "");
                                }
                            }
                        }
                        return "";
                    }
                }
            }
            return null;
        }
    }
}
