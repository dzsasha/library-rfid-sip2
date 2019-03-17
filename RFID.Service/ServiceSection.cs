using System.Configuration;

namespace IS.RFID.Service {
    public class ServiceSection : ConfigurationSection {
        public static string SectionName = "rfid.service";
        public ServiceSection() { }
        [ConfigurationProperty("readers")]
        public Readers Readers {
            get { return (Readers)base["readers"]; }
            set { base["readers"] = value; }
        }
        [ConfigurationProperty("websocket")]
        public WebSockets Sockets {
            get { return (WebSockets)base["websocket"]; }
            set { base["websocket"] = value; }
        }
    }
}
