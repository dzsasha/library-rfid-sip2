using IS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.Cloud.ncip.v2 {
    public partial class NCIPMessage : IDisposable {
        public NCIPMessage() { }
        internal NCIPMessage(IField[] param) {
            this.version = "http://www.niso.org/schemas/ncip/v2_02/ncip_v2_02.xsd";
        }

        #region implements IDisposable
        public void Dispose() {
        }
        #endregion
    }
}
