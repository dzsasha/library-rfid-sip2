using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Marc.Interface;

namespace Marc.RFID.IDLogic
{
	public class ItemModelImpl : ItemExImpl, IItemModel
	{
		public ItemModelImpl(string id, IEnumerable<IField> param) : base(id)
		{
			_modelsImpl.Add(new DanishTypeImpl(id, param));
		}
		#region implementation interface IItemModel

		private readonly List<ITypeModel> _modelsImpl = new List<ITypeModel>();

		public ITypeModel[] Models
		{
			get
			{
				return _modelsImpl.ToArray();
			}
		}
		#endregion
	}
}
