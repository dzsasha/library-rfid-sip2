using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic
{
	/// <summary>
	/// Общия класс считывателя
	/// </summary>
	public abstract class ReaderImpl : IReader
	{
		protected ReaderImpl()
		{
		}
		/// <summary>
		/// Параметры открытия
		/// </summary>
		internal static List<IField> Parameters = new List<IField>();

		/// <summary>
		/// Чтение меток
		/// </summary>
		/// <returns>прочитанная строка</returns>
		protected abstract string Read();
		/// <summary>
		/// Получение метки
		/// </summary>
		/// <param name="uid">идентификатор метки</param>
		/// <returns>метка</returns>
		protected abstract ItemImpl GetItem(string uid);

		private string _sReaded = "";

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

		public event ErrorEventHandler OnError;
		public event EventHandler OnChange;

		#endregion
	}
}
