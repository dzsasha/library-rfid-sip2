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
            Sip2Request sip2Request = (Sip2Request)Convert.ToInt32(msg.Substring(0, 2));
            if(sip2Request.Equals(Sip2Request.scRequestACSResend)) {
                Type answer = cacheCommand[Convert.ToInt32(lastCmd.Substring(0, 2))];
                ISip2Answer obj = (ISip2Answer)Activator.CreateInstance(answer);
                IFormatter formatter = new Sip2Formatter(obj, config);
                using(Stream stream = lastCmd.Substring(2).GetStream()) {
                    obj = (ISip2Response)formatter.Deserialize(stream);
                }
                obj.Sequence = -1;
                return serialize(formatter, obj);
            } else {
                foreach(var cmd in server.commands) {
                    foreach(Type typeImpl in findType(cmd.GetType(), sip2Request, ref request, ref response)
                        .FindInterfaces((Type a, object obj) => { return a.GetMethod("execute") != null; }, null)) {
                        IFormatter formatter = new Sip2Formatter(request, config);
                        using(Stream stream = msg.Substring(2).GetStream()) {
                            request = (ISip2Request)formatter.Deserialize(stream);
                        }
                        if(request != null) {
                            var result = typeImpl.GetMethod("execute")?.Invoke(cmd, new object[] { config, request, response });
                            if((result is bool) && (bool)result) {
                                response.Sequence = request.Sequence;
                                return serialize(formatter, response);
                            }
                        }
                        return "";
                    }
                }
            }
            return null;
        }
        internal static string doResend(this ISip2 server, ISip2Config config) {
            ISip2Answer obj = new ResendImpl();
            IFormatter formatter = new Sip2Formatter(obj, config);
            return serialize(formatter, obj);
        }
        private static string serialize(IFormatter formatter, ISip2Answer obj) {
            using(Stream writer = new MemoryStream()) {
                formatter.Serialize(writer, obj);
                Sip2FieldAttribute attr = obj.GetType().GetProperty("CheckSum").GetCustomAttribute<Sip2FieldAttribute>();
                StreamReader rdr = new StreamReader(writer);
                writer.Position = 0;
                return ((attr != null) ? attr.Serialize(rdr.ReadToEnd(), '\0') : "");
            }
        }
        private static Type findType(Type cmdType, Sip2Request cmd, ref ISip2Request request_ref, ref ISip2Response response_ref) {
            ISip2Request request = null;
            ISip2Response response = null;
            foreach(Type typeCmd in cmdType.FindInterfaces((Type a, object obj) => {
                Sip2IdentificatorAttribute attr = a.GetCustomAttribute<Sip2IdentificatorAttribute>();
                if(attr != null && attr.request.Equals((Sip2Request)obj)) {
                    if(cacheCommand.ContainsKey((int)attr.request)) {  // Проверяем в кеше, если уже было определно, не надо будет определять новые
                        request = (ISip2Request)Activator.CreateInstance(cacheCommand[(int)attr.request]);
                    }
                    if(cacheCommand.ContainsKey((int)attr.response)) {
                        response = (ISip2Response)Activator.CreateInstance(cacheCommand[(int)attr.response]);
                    }
                    if(request == null || response == null) {
                        foreach(Type typeImpl in Assembly.GetEntryAssembly().GetTypes()) {
                            Sip2IdentificatorAttribute typeAttr = typeImpl.GetCustomAttribute<Sip2IdentificatorAttribute>();
                            if(typeAttr != null && typeAttr.request.Equals(attr.request)) {
                                request = (ISip2Request)Activator.CreateInstance(typeImpl);
                                if(!cacheCommand.ContainsKey((int)attr.request))
                                    cacheCommand.Add((int)attr.request, typeImpl);
                            } else if(typeAttr != null && typeAttr.response.Equals(attr.response)) {
                                response = (ISip2Response)Activator.CreateInstance(typeImpl);
                                if(!cacheCommand.ContainsKey((int)attr.response))
                                    cacheCommand.Add((int)attr.response, typeImpl);
                            }
                        }
                    }
                    return true;
                }
                return false;
            }, cmd)) {
                request_ref = request;
                response_ref = response;
                return typeCmd;
            }
            return null;
        }
    }
}
