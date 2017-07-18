using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic
{
	/// <summary>
	/// Имплементация RFID-считывателя
	/// </summary>
	[Guid("772B6C85-AB9C-4688-A761-C3DCB26A1CF6")]
	[ComVisible(true)]
	[ProgId("RFID.IDLogic")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class RfidReaderImpl : ReaderImpl, IDisposable
	{
		/// <summary>
		/// Конструктор по умолчанию
		/// </summary>
		public RfidReaderImpl() : base()
		{
		}
		/// <summary>
		/// Чтение меток
		/// </summary>
		/// <returns>прочитанная строка</returns>
		protected override string Read()
		{
			return Externals.RfidRead();
		}
		/// <summary>
		/// Получение метки
		/// </summary>
		/// <param name="uid">идентификатор метки</param>
		/// <returns>метка</returns>
		protected override ItemImpl GetItem(string uid)
		{
			return new ItemModelImpl(uid, Parameters);
		}
		/// <summary>
		/// Считыватель подключен
		/// </summary>
		public override bool IsConnected
		{
			get { return Convert.ToBoolean(Externals.IsRfidReaderOnline()); }
		}

		#region IDisposable
		public void Dispose()
		{
		}
		#endregion
	}
}
