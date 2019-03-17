using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using System.IO;

namespace IS.RFID.Bibliotheca {
    [Guid("4DB1230F-89BC-48CB-9019-B265F87A0F88")]
    [ComVisible(true)]
    [ProgId("RFID.Bibliotheca")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ReaderImpl : IReader, IConfig, IDisposable {
        public ReaderImpl() {
            _params.Add(new FieldImpl() { Description = "Страна", Name = "Country", Type = TypeField.String, Value = "RU" });
            _params.Add(new FieldImpl() { Description = "ISIL", Name = "ISIL", Type = TypeField.String, Value = "" });
            Log.For(this).Info(this);
        }
        private List<IField> _params = new List<IField>();

        #region implementation interface IConfig
        public IField[] Fields {
            get { return _params.ToArray(); }
        }
        public string ProgId { get { return "RFID.Bibliotheca"; } }
        #endregion

        #region implementation interface IReader
        public IItem[] Items {
            get {
                List<IItem> lRet = new List<IItem>();
                try {
                    int iReaded = External.BibInventory();
                    if (iReaded > 0) {
                        for (int i = 0; i < iReaded; i++) {
                            lRet.Add(new ItemExModelImpl(i, External.BibGetTransponderUID(i), _params));
                        }
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
                Log.For(this).DebugFormat("CloseReader");
                External.BibCloseReader();
            } catch (Exception ex) {
                Log.For(this).Error(this, ex);
                OnError?.Invoke(this, new ErrorEventArgs(ex));
            }
        }
        public bool InitReader(IField[] param) {
            try {
                Log.For(this).DebugFormat("InitReader");
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
                return External.BibOpenReader() == 0;
            } catch (Exception ex) {
                Log.For(this).Error(this, ex);
                OnError?.Invoke(this, new ErrorEventArgs(ex));
                return false;
            }
        }
        #endregion

        #region implementation interface IDisposable
        public void Dispose() {
            CloseReader();
        }

        #endregion
    }
}
