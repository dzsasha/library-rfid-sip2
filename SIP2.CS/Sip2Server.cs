using System;
using System.IO;
using System.Net.Sockets;
using IS.Interface.SIP2;
using IS.Interface;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IS.SIP2.CS.SIP2;

namespace IS.SIP2.CS {
    public class Sip2Server : IDisposable {
        private Socket _listener = null;
        private readonly SocketAsyncEventArgs _acceptArgs = new SocketAsyncEventArgs();
        private ISip2 _sip2Client = null;
        private ServiceSection _serviceSection = null;
        public Sip2Server(ServiceSection config) {
            _serviceSection = config;
            _acceptArgs.Completed += new EventHandler<SocketAsyncEventArgs>(AcceptEventArg_Completed);
        }

        internal void Start() {
            try {
                Type typeStart = Type.GetType(_serviceSection.Answers.Name);
                if ((_sip2Client = (ISip2)Activator.CreateInstance(typeStart)) == null) {
                    throw new NullReferenceException();
                } else {
                    if (!_sip2Client.init(_serviceSection.Answers)) {
                        throw new InvalidOperationException();
                    } else {
                        _sip2Client.OnError += Sip2Client_OnError;
                        IPAddress address = IPAddress.Parse(_serviceSection.Answers.Address);
                        IPEndPoint localEndPoint = new IPEndPoint(address, _serviceSection.Answers.Port);
                        _listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, _serviceSection.Answers.Proto);
                        _listener.Bind(localEndPoint);
                        _listener.Listen(_serviceSection.Answers.MaxConnection);
                        AcceptAsync(_acceptArgs);
                    }
                }
            } catch (Exception ex) {
                Log.For(this).Error("Start", ex);
                Sip2Client_OnError(this, new ErrorEventArgs(ex));
            }
        }
        private void AcceptAsync(SocketAsyncEventArgs e) {
            if (!_listener.AcceptAsync(e)) {
                AcceptEventArg_Completed(_listener, e);
            }
        }

        private async void AcceptEventArg_Completed(object sender, SocketAsyncEventArgs e) {
            if (e.SocketError == SocketError.Success) {
                await ReceiveAsync(e.AcceptSocket).ConfigureAwait(false);
                e.AcceptSocket = null;
                AcceptAsync(_acceptArgs);
            }
        }
        public async Task ReceiveAsync(Socket socket) {
            if (socket != null) {
                new Thread(async () => {
                    while (socket.Connected) {
                        try {
                            var buffer = new byte[4096];
                            var byteReads = await Task.Factory.FromAsync(socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, null, socket), socket.EndReceive).ConfigureAwait(false);
                            if (byteReads > 0) {
                                foreach (string sb in _serviceSection.Answers.encoding.GetString(buffer, 0, byteReads).Split(new char[] { '\r' }, StringSplitOptions.RemoveEmptyEntries)) {
                                    Log.For(this).DebugFormat("ReceiveAsync from {0}: {1}", socket.LocalEndPoint.ToString(), sb);
                                    OnReceive?.Invoke(socket, new Sip2MessageEventArgs(sb));
                                    if (!Sip2AnswerImpl.verify(sb)) {
                                        throw new Exception("error checksum");
                                    }
                                    string strSend = _sip2Client.doMessage(sb, _serviceSection.Answers);
                                    if (!Sip2AnswerImpl.verify(strSend)) {
                                        throw new Exception("error checksum");
                                    }
                                    if (!String.IsNullOrEmpty(strSend) && socket.Send(_serviceSection.Answers.encoding.GetBytes(strSend)) > 0) {
                                        socket.Send(new byte[] { 0x0D });
                                        Log.For(this).DebugFormat("send: {0}", strSend);
                                        OnSend?.Invoke(socket, new Sip2MessageEventArgs(strSend));
                                    }
                                }
                            }
                        } catch (Exception ex) {
                            Log.For(this).Error("ReceiveAsync", ex);
                            Sip2Client_OnError(this, new ErrorEventArgs(ex));
                        }
                    }
                }).Start();
            }
        }

        private void Sip2Client_OnError(object sender, ErrorEventArgs e) {
            OnError?.Invoke(sender, e);
        }

        internal void Stop() {
            try {
                if (_listener != null) {
                    _listener.Close();
                    _listener = null;
                }
            } catch (Exception ex) {
                Log.For(this).Error("Stop", ex);
                Sip2Client_OnError(this, new ErrorEventArgs(ex));
            }
        }

        public event EventHandler<Sip2MessageEventArgs> OnReceive;
        public event EventHandler<Sip2MessageEventArgs> OnSend;
        public event ErrorEventHandler OnError;

        #region implementation interface IDisposable
        public void Dispose() {
            Stop();
        }
        #endregion
    }
}
