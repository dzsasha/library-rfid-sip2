using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using IS.Interface;
using IS.Interface.RFID;
using System.Text;
using System.Collections.Generic;

namespace IS.RFID.SmartCard {
    [Guid("2D268B6C-5C02-4922-A955-C712C8F9F310")]
    [ComVisible(true)]
    [ProgId("RFID.SmartCard")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class SmartCardsImpl : IReader, IConfig, IDisposable {
        public SmartCardsImpl() {
            _params.Add(new FieldImpl() { Description = "DLL Tools export", Name = "DllTool", Type = TypeField.String, Value = "" });
            _params.Add(new FieldImpl() { Description = "Функция замены идентификатора", Name = "NumberReplace", Type = TypeField.String, Value = "" });
        }

        private IntPtr _hContext = IntPtr.Zero;
        private List<IField> _params = new List<IField>();
        List<string> readersList = new List<string>();

        private OnNumberReplace _numberReplace = NumberReplace;
        private IntPtr DllTool = IntPtr.Zero;

        private static string NumberReplace(IntPtr input, int length) {
            string sOut = "";
            byte[] data = new byte[length];
            Marshal.Copy(input, data, 0, length);
            for(int i = 0; i < length; i++) {
                sOut += String.Format("{0:x2}", data[i]);
            }
            return sOut;
        }

        #region implementation interface IConfig
        public IField[] Fields {
            get { return _params.ToArray(); }
        }
        public string ProgId { get { return "RFID.SmartCard"; } }
        #endregion

        #region implementation interface IReader
        public IItem[] Items {
            get {
                HashSet<ItemImpl> lRet = new HashSet<ItemImpl>();
                IntPtr phCard = IntPtr.Zero;
                IntPtr ActiveProtocol = IntPtr.Zero;
                foreach(string reader in readersList) {
                    try {
                        if(External.SCardConnect(_hContext, reader, 2, 3, ref phCard, ref ActiveProtocol) == External.SCardFunctionReturnCodes.SCARD_S_SUCCESS) {
                            byte[] ucByteSend = { 0xFF, 0xCA, 0x00, 0x00, 0x00 };
                            byte[] receivedUID = new byte[255];
                            UInt32 outBytes = (UInt32)receivedUID.Length;
                            IntPtr ioSend = IntPtr.Zero;
                            switch(ActiveProtocol.ToInt32()) {
                                case 1: {
                                        ioSend = External.GetPciT0();
                                        break;
                                    }
                                case 2: {
                                        ioSend = External.GetPciT1();
                                        break;
                                    }
                            }
                            if(External.SCardTransmit(phCard, ioSend, ucByteSend, (UInt32)ucByteSend.Length, IntPtr.Zero, receivedUID, ref outBytes) == External.SCardFunctionReturnCodes.SCARD_S_SUCCESS) {
                                IntPtr ip = Marshal.AllocHGlobal(Convert.ToInt32(outBytes));
                                Marshal.Copy(receivedUID, 0, ip, Convert.ToInt32(outBytes));
                                lRet.Add(new ItemImpl(_numberReplace(ip, Convert.ToInt32(outBytes))));
                                OnChange?.Invoke(this, new EventArgs());
                            }
                        }
                    } finally {
                        External.SCardDisconnect(phCard, 0);
                    }
                }
                return lRet.ToArray();
            }
        }

        public event EventHandler OnChange;
        public event ErrorEventHandler OnError;

        public void CloseReader() {
            readersList.Clear();
            External.SCardReleaseContext(_hContext);
        }

        public bool InitReader(IField[] param) {
            bool bRet = false;
            readersList.Clear();
            try {
                if(External.SCardEstablishContext(0, IntPtr.Zero, IntPtr.Zero, out _hContext) == External.SCardFunctionReturnCodes.SCARD_S_SUCCESS) {
                    uint pcchReaders = 1024;
                    byte[] mszReaders = new byte[pcchReaders];
                    if(External.SCardListReaders(_hContext, null, mszReaders, ref pcchReaders) == External.SCardFunctionReturnCodes.SCARD_S_SUCCESS) {
                        readersList.AddRange(Encoding.ASCII.GetString(mszReaders, 0, Convert.ToInt32(pcchReaders)).Split('\0'));
                        bRet = true;
                        Log.For(this).InfoFormat("Connect readers: {0}", String.Join(", ", readersList));
                        foreach(IField field in param) {
                            if(field.Name.ToUpper().Equals("DllTool".ToUpper()) && DllTool == IntPtr.Zero) {
                                DllTool = External.LoadLibrary(field.Value.ToString());
                            } else if(field.Name.ToUpper().Equals("NumberReplace".ToUpper()) && DllTool != IntPtr.Zero) {
                                IntPtr pAddressNumberReplace = External.GetProcAddress(DllTool, field.Value.ToString());
                                if(pAddressNumberReplace != IntPtr.Zero) {
                                    _numberReplace = (OnNumberReplace)Marshal.GetDelegateForFunctionPointer(pAddressNumberReplace, typeof(OnNumberReplace));
                                }
                            }
                        }
                    }
                }
            } catch(Exception ex) {
                Log.For(this).Error(ex.Message);
                OnError?.Invoke(this, new ErrorEventArgs(ex));
            }
            return bRet;
        }

        #endregion

        #region implementation interface IDisposable
        public void Dispose() {
            if(DllTool != IntPtr.Zero)
                External.FreeLibrary(DllTool);
            CloseReader();
        }
        #endregion
    }
}
