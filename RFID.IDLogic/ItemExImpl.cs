using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using IS.Interface.RFID;
using IS.Interface;

namespace IS.RFID.IDLogic
{
	public class ItemExImpl : ItemImpl, IItemEx, IItemModel
    {
		public ItemExImpl(string id, string dm, IEnumerable<IField> param) : base(id)
		{
            _modelsImpl.Add(new DanishTypeImpl(id, dm, param));
        }
        #region implementation interface IItemEx
        public bool Eas
		{
			get { return Externals.EasGet((this as IItem).Id); }
			set { Externals.EasSet((this as IItem).Id, value); }
		}
        #endregion
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
