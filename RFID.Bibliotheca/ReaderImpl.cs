using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using System.IO;

namespace IS.RFID.Bibliotheca
{
    [Guid("4DB1230F-89BC-48CB-9019-B265F87A0F88")]
    [ComVisible(true)]
    [ProgId("RFID.Bibliotheca")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ReaderImpl : IReader, IDisposable
    {
        public ReaderImpl() { }
        private List<IField> _params = new List<IField>();
        #region implementation interface IReader
        public IItem[] Items
        {
            get
            {
                List<IItem> lRet = new List<IItem>();
                int iReaded = External.BibInventory();
                if (iReaded > 0)
                {
                    for (int i = 0; i < iReaded; i++)
                    {
                        string sUid = "";
                        External.BibGetTransponderUID(i, ref sUid);
                        lRet.Add(new ItemExModelImpl(i, sUid, _params));
                    }
                    if (OnChange != null) OnChange(this, new EventArgs());
                }
                return lRet.ToArray();
            }
        }

        public event EventHandler OnChange;
        public event ErrorEventHandler OnError;

        public void CloseReader()
        {
            External.BibCloseReader();
        }
        public bool InitReader(IField[] param)
        {
            _params.AddRange(param);
            return External.BibOpenReader() == 0;
        }
        #endregion

        #region implementation interface IDisposable
        public void Dispose()
        {
            CloseReader();
        }

        #endregion
    }
}
