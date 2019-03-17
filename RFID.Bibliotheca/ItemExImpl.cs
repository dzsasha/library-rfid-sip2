using IS.Interface;
using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.RFID.Bibliotheca {
    public class ItemExModelImpl : ItemImpl, IItemEx, IItemModel {
        public ItemExModelImpl(int iIndex, string id, IEnumerable<IField> param) : base(id) {
            _iIndex = iIndex;
            _modelsImpl.Add(new DanishTypeImpl(iIndex, id, param));
        }
        private int _iIndex { get; set; }
        private readonly List<ITypeModel> _modelsImpl = new List<ITypeModel>();

        #region implementation interface IItemEx
        public bool Eas {
            get {
                try {
                    return !((External.BibGetIsItemLabel(_iIndex) > 0) && Convert.ToBoolean(External.BibGetItemCheckedOut(_iIndex)));
                } catch (RfidException) {
                    return false;
                }
            } set {
                External.BibSetItemCheckedOut(_iIndex, value ? 0 : 1);
                External.BibWriteChangedPages(_iIndex);
            }
        }
        #endregion

        #region implementation interface IItemModel
        public ITypeModel[] Models {
            get {
                return _modelsImpl.ToArray();
            }
        }
        #endregion
    }
}
