using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Interface.RFID;

namespace IS.RFID.IDLogic
{
	public class ItemExImpl : ItemImpl, IItemEx
	{
		public ItemExImpl(string id) : base(id)
		{
		}
		#region implementation interface IItemEx
		public bool Eas
		{
			get
			{
				int iErr = Externals.EasGet((this as IItem).Id);
				switch (iErr)
				{
					case -1: throw new RfidException("ошибка чтения");
					default:
						return Convert.ToBoolean(iErr);
				}
			}
			set
			{
				switch (value ? Externals.EasSet((this as IItem).Id) : Externals.EasReset((this as IItem).Id))
				{
					case -1: throw new RfidException("Ошибка записи (RFID-ридер недоступен)");
					case 0: throw new RfidException(value ? "Не удалось установить противокражный бит" : "Не удалось снять противокражный бит");
				}
			}
		}
		#endregion
	}
}
