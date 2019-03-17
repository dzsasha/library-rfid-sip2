using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.Service {
    public interface IWebSocket {
        string Name { get; }
        string URL { get; }
        string Method { get; }
        string ContentType { get; }
    }
    public class WebSocketImpl : ConfigurationElement, IWebSocket {
        public WebSocketImpl() { }
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name {
            get { return ((string)(base["name"])); }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("url", IsRequired = true)]
        public string URL {
            get { return ((string)(base["url"])); }
            set { base["url"] = value; }
        }
        [ConfigurationProperty("method", DefaultValue = "POST")]
        public string Method {
            get { return ((string)(base["method"])); }
            set { base["method"] = value; }
        }
        [TypeConverter(typeof(TypeNameConverter))]
        [ConfigurationProperty("type", DefaultValue = typeof(WebSocketDefault))]
        public Type types => (base["type"] as Type);

        [ConfigurationProperty("contenttype", DefaultValue = "application/json")]
        public string ContentType => ((string)base["contenttype"]);
    }
}
