using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic
{
	/// <summary>
	/// Имплементация считывателя карт читателя
	/// </summary>
	[Guid("8C7C7086-04C0-4AD6-A693-97C6F017FB64")]
	[ComVisible(true)]
	[ProgId("RFID.Mifare")]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	public class CardReaderImpl : ReaderImpl
	{
		public CardReaderImpl() { }
		/// <summary>
		/// Чтение меток
		/// </summary>
		/// <returns>прочитанная строка</returns>
		protected override string Read()
		{
			return Externals.CardReaderRead();
		}
		/// <summary>
		/// Получение метки
		/// </summary>
		/// <param name="uid">идентификатор метки</param>
		/// <returns>метка</returns>
		protected override ItemImpl GetItem(string uid)
		{
			return new ItemImpl(uid);
		}
		public override bool IsConnected
		{
			get { return Convert.ToBoolean(Externals.IsCardReaderOnline()); }
		}
	}
}
