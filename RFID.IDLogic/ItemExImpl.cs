using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using IS.Interface.RFID;
using IS.Interface;

namespace IS.RFID.IDLogic {
    public class ItemExImpl : ItemImpl, IItemEx, IItemModel {
        public ItemExImpl(IConfig config, string id) : base(id) {
            _config = config;
            _modelsImpl.Add(new DanishTypeImpl(config, id));
        }
        private IConfig _config { get; set; }
        #region implementation interface IItemEx
        public bool Eas {
            get { return Externals.EasGet((this as IItem).Id); }
            set { Externals.EasSet((this as IItem).Id, value); }
        }
        #endregion
        #region implementation interface IItemModel

        private readonly List<ITypeModel> _modelsImpl = new List<ITypeModel>();

        public ITypeModel[] Models => _modelsImpl.ToArray();

        #endregion
    }
}
