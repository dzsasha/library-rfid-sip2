using IS.Interface;
using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.IDLogic {
    [Guid("6CCE520B-8459-475C-BD0C-2FED7F7F94E7")]
    [ComVisible(true)]
    [ProgId("RFID.IDLogic")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ReaderImpl : IReader, IConfig, IDisposable {
        public ReaderImpl() {
            _params.Add(new FieldImpl() { Description = "Страна", Name = "Country", Type = TypeField.String, Value = "RU" });
            _params.Add(new FieldImpl() { Description = "ISIL", Name = "ISIL", Type = TypeField.String, Value = "" });
        }

        public IField[] Fields => _params.ToArray();

        public string ProgId => "RFID.IDLogic";
        private List<IField> _params = new List<IField>();
        private ItemExImpl GetItem(string id) {
            return new ItemExImpl(this, id.Split('=')[0]);
        }
        #region implemenatation interface IReader
        public IItem[] Items {
            get {
                List<IItem> lRet = new List<IItem>();
                try {
                    string sRead = Externals.RfidReadData();
                    if (!String.IsNullOrEmpty(sRead)) {
                        lRet.AddRange(sRead.Split(',').Select(GetItem));
                        OnChange?.Invoke(this, new EventArgs());
                    }
                } catch (Exception ex) {
                    Log.For(this).Error(this, ex);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return lRet.ToArray();
            }
        }

        public event EventHandler OnChange;
        public event ErrorEventHandler OnError;

        public void CloseReader() {
            try {
            } catch (Exception ex) {
                Log.For(this).Error(this, ex);
                OnError?.Invoke(this, new ErrorEventArgs(ex));
            }
        }
        public bool InitReader(IField[] param) {
            try {
                foreach (IField field in param) {
                    switch (field.Name) {
                        case "Country":
                            _params[0].Value = field.Value;
                            break;
                        case "ISIL":
                            _params[1].Value = field.Value;
                            break;
                    }
                }
                return Externals.IsReaderOnline();
            } catch (Exception ex) {
                Log.For(this).Error(this, ex);
                OnError?.Invoke(this, new ErrorEventArgs(ex));
            }
            return false;
        }
        #endregion

        #region implemenatation interface IDisposable
        public void Dispose() {
            CloseReader();
        }
        #endregion
    }
}
