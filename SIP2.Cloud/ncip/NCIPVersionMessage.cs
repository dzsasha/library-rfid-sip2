using IS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.Cloud.ncip {
    public partial class NCIPVersionMessage : IDisposable {
        public NCIPVersionMessage() { }
        internal NCIPVersionMessage(IField[] param) {
            this.Item = new LookupVersion() {
                FromAgencyId = new FromAgencyId() { UniqueAgencyId = new UniqueAgencyId() { Scheme = "http://informsystema.ru/marc.cloud/ncip", Value = Convert.ToString(param.GetField("library").Value) } },
                ToAgencyId = new ToAgencyId() { UniqueAgencyId = new UniqueAgencyId() { Scheme = "http://informsystema.ru/marc.cloud/ncip", Value = Convert.ToString(param.GetField("library").Value) } }
            };
        }

        public T getItem<T>() {
            return (T)this.Item;
        }

        #region implements IDisposable
        public void Dispose() {
        }
        #endregion
    }
}
