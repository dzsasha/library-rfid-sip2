using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.Service {
    public class WebSockets : ConfigurationElementCollection {
        public WebSockets() { }
        #region ConfigurationElementCollection
        protected override ConfigurationElement CreateNewElement() {
            return new WebSocketImpl();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((WebSocketImpl)element).Name;
        }
        #endregion

        public void Add(WebSocketImpl element) {
            BaseAdd(element);
        }
        public void Clear() {
            BaseClear();
        }
        public int IndexOf(WebSocketImpl element) {
            return BaseIndexOf(element);
        }
        public void Remove(WebSocketImpl element) {
            if (BaseIndexOf(element) >= 0) {
                BaseRemove(element.Name);
            }
        }
        public void RemoveAt(int index) {
            BaseRemoveAt(index);
        }
        public WebSocketImpl this[int index] {
            get { return (WebSocketImpl)BaseGet(index); }
            set {
                if (BaseGet(index) != null) {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        public new WebSocketImpl this[string name] => (WebSocketImpl)BaseGet(name);

        protected override void BaseAdd(ConfigurationElement element) {
            BaseAdd(element, false);
        }
        [ConfigurationProperty("port", DefaultValue = 80)]
        public int Port {
            get { return ((int)(base["port"])); }
            set { base["port"] = value; }
        }
        [ConfigurationProperty("host", DefaultValue = "localhost")]
        public string Host {
            get { return ((string)(base["host"])); }
            set { base["host"] = value; }
        }
    }
}
