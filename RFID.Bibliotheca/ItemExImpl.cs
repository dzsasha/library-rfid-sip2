using IS.Interface;
using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.RFID.Bibliotheca
{
    public class ItemExModelImpl : ItemImpl, IItemEx, IItemModel
    {
        public ItemExModelImpl(int iIndex, string id, IEnumerable<IField> param) : base(id)
        {
            _iIndex = iIndex;
            _modelsImpl.Add(new DanishTypeImpl(iIndex, id, param));
        }
        private int _iIndex { get; set; }
        private readonly List<ITypeModel> _modelsImpl = new List<ITypeModel>();

        #region implementation interface IItemEx
        public bool Eas
        {
            get
            {
                return Convert.ToBoolean(External.BibGetIsItemLabel(_iIndex)) && Convert.ToBoolean(External.BibGetItemCheckedOut(_iIndex));
            }

            set
            {
                External.BibSetItemCheckedOut(_iIndex, Convert.ToInt32(value));
                External.BibWriteChangedPages(_iIndex);
            }
        }
        #endregion

        #region implementation interface IItemModel
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
