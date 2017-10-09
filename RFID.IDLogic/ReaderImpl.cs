using IS.Interface;
using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.IDLogic
{
    [Guid("6CCE520B-8459-475C-BD0C-2FED7F7F94E7")]
    [ComVisible(true)]
    [ProgId("RFID.IDLogic")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ReaderImpl : IReader, IDisposable
    {
        public ReaderImpl() { }
        private string _readed = "";
        private List<IField> _params = new List<IField>();
        private ItemExImpl GetItem(string id)
        {
            return new ItemExImpl(id.Split('=')[0], id.Split('=')[1], _params);
        }
        #region implemenatation interface IReader
        public IItem[] Items
        {
            get
            {
                List<IItem> lRet = new List<IItem>();
                try
                {
                    string sRead = Externals.RfidReadData();
                    if (!String.IsNullOrEmpty(sRead))
                    {
                        lRet.AddRange(sRead.Split(',').Select(GetItem));
                        if (OnChange != null) OnChange(this, new EventArgs());
                    }
                }
                catch (Exception ex)
                {
                    Log.For(this).Error(this, ex);
                    if (OnError != null) OnError(this, new ErrorEventArgs(ex));
                }
                return lRet.ToArray();
            }
        }

        public event EventHandler OnChange;
        public event ErrorEventHandler OnError;

        public void CloseReader()
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.For(this).Error(this, ex);
                if (OnError != null) OnError(this, new ErrorEventArgs(ex));
            }
        }
        public bool InitReader(IField[] param)
        {
            try
            {
                _params.AddRange(param);
                return Externals.IsReaderOnline();
            }
            catch (Exception ex)
            {
                Log.For(this).Error(this, ex);
                if (OnError != null) OnError(this, new ErrorEventArgs(ex));
            }
            return false;
        }
        #endregion

        #region implemenatation interface IDisposable
        public void Dispose()
        {
            CloseReader();
        }
        #endregion
    }
}
