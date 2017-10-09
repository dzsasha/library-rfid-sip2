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

<<<<<<< HEAD
        public event EventHandler OnChange;
        public event ErrorEventHandler OnError;
=======
		#region IReader
		/// <summary>
		/// Есть соединение с реадером
		/// </summary>
		public abstract bool IsConnected { get; }
		/// <summary>
		/// Инициализация реадера
		/// </summary>
		/// <param name="param">параметры</param>
		/// <returns>успешность открытия</returns>
		public virtual bool InitReader(IField[] param)
		{
			bool bRet = false;
			try
			{
				Parameters.Clear();
				bRet = IsConnected;
				if (bRet)
				{
					foreach (IField field in param)
					{
						Parameters.Add(field);
					}
				}
			}
			catch (Exception ex)
			{
				if (OnError != null)
				{
					OnError(this, new ErrorEventArgs(ex));
				}
				bRet = false;
			}
			return bRet;
		}
		/// <summary>
		/// Закрыть реадер
		/// </summary>
		public virtual void CloseReader()
		{
		}
		private List<IItem> _items = new List<IItem>();
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		public IItem[] Items
		{
			get
			{
				try
				{
					string uids = Read();
					if (uids != _sReaded)
					{
						_items.Clear();
						if (!String.IsNullOrEmpty(uids)) _items.AddRange(uids.Split(',').Select(GetItem));
						if (uids != _sReaded)
						{
							Log.For(this).Debug(String.Format("Readed items: {0}", uids));
						}
						if (OnChange != null && uids != _sReaded)
						{
							OnChange(this, new EventArgs());
						}
						_sReaded = uids;
					}
				}
				catch (Exception ex)
				{
					if (OnError != null)
					{
						OnError(this, new ErrorEventArgs(ex));
					}
					throw ex;
				}
				return _items.ToArray();
			}
		}
>>>>>>> c98aac993646d9ea9acf4b796036a67558f56eb0

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
