using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Marc.Interface;

namespace Marc.RFID.IDLogic
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

		private string sReaded = "";

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
					sReaded = Read();
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
		/// <summary>
		/// Получить прочитанные метки
		/// </summary>
		public IItem[] Items
		{
			get
			{
				List<IItem> items = new List<IItem>();
				try
				{
					string uids = Read();
					if (uids.Length > 0 || uids != sReaded)
					{
						items.AddRange(uids.Split(',').Select(GetItem));
						if (OnChange != null && uids != sReaded)
						{
							OnChange(this, new EventArgs());
						}
						sReaded = uids;
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
				return items.ToArray();
			}
		}

		public event ErrorEventHandler OnError;
		public event EventHandler OnChange;

		#endregion
	}
}
