using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.Service.Test {
    public class DanishTypeImpl : TypeModelImpl<DanishModelImpl>, ITypeModel {
        public DanishTypeImpl(IConfig config, string id) : base(TypeModel.Danish, id, false)
        {
            this._config = config;
            Add(new DanishModelImpl(config, id));
        }
        private IConfig _config { get; set; }
    }
}
