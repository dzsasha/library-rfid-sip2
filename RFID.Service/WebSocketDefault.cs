using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace IS.RFID.Service {
    public class WebSocketDefault : WebSocketBehavior, IWebSocket {
        public WebSocketDefault(IWebSocket webSocket) {
            _socket = webSocket;
        }
        private IWebSocket _socket { get; set; }
        protected object objLock = new object();
        protected WebRequest request {
            get {
                WebRequest pRet = WebRequest.Create(URL);
                pRet.Method = Method;
                pRet.ContentType = ContentType;
                return pRet;
            }
        }

        protected override void OnMessage(MessageEventArgs e) {
            lock (objLock) {
                try {
                    WebRequest pRet = request;
                    string postData = e.Data;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    pRet.ContentLength = byteArray.Length;
                    using (Stream dataStream = pRet.GetRequestStream()) {
                        dataStream.Write(byteArray, 0, byteArray.Length);
                        using (WebResponse response = pRet.GetResponse()) {
                            using (Stream resData = response.GetResponseStream()) {
                                StreamReader reader = new StreamReader(resData);
                                Send(reader.ReadToEnd());
                            }
                        }
                    }
                } catch (Exception ex) {
                    Interface.Log.For(this).Error(ex);
                    Error(ex.Message, ex);
                }
            }
        }

        #region IWebSocket
        public string Method => _socket.Method;

        public string Name => _socket.Name;

        public string URL => _socket.URL;

        public string ContentType => _socket.ContentType;

        #endregion
    }
}
