using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.Service.Test {
    public class ItemExImpl : ItemImpl, IItemEx, IItemModel {
        public ItemExImpl(IConfig config, string id) : base(id) {
            this._config = config;
            _modelsImpl.Add(new DanishTypeImpl(config, id));
        }

        public bool Eas {
            get { return Convert.ToBoolean(_config.Fields.GetField("eas").Value); }
            set { _config.Fields.GetField("eas").Value = value; }
        }

        public ITypeModel[] Models => _modelsImpl.ToArray();
        private IConfig _config { get; set; }
        private readonly List<ITypeModel> _modelsImpl = new List<ITypeModel>();
    }
}
