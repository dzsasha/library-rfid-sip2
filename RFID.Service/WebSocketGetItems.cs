using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WebSocketSharp;

namespace IS.RFID.Service {
    public class WebSocketGetItems : WebSocketDefault {
        public WebSocketGetItems(IWebSocket webSocket) : base(webSocket) {
            _timer = new Timer(500);
            _timer.Elapsed += _timer_Elapsed;
        }
        private string sReaded = "";
        private void _timer_Elapsed(object sender, ElapsedEventArgs e) {
            lock (objLock) {
                StreamReader reader = null;
                try {
                    _timer.Stop();
                    using (WebResponse response = request.GetResponse()) {
                        Interface.Log.For(this).Debug(((HttpWebResponse)response).StatusDescription);
                        using (Stream dataStream = response.GetResponseStream()) {
                            reader = new StreamReader(dataStream);
                            string read = reader.ReadToEnd();
                            if (!read.Equals(sReaded)) {
                                sReaded = read;
                                Send(sReaded);
                            }
                        }
                    }
                } catch (Exception ex) {
                    Interface.Log.For(this).Error(ex);
                } finally {
                    reader.Close();
                    _timer.Start();
                }
            }
        }

        protected override void OnOpen() {
            base.OnOpen();
            _timer.Start();
        }
        protected override void OnClose(CloseEventArgs e) {
            _timer.Stop();
            base.OnClose(e);
        }

        private Timer _timer = null;
    }
}
