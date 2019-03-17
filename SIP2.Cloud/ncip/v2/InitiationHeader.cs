using IS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.Cloud.ncip.v2 {
    public partial class InitiationHeader {
        public InitiationHeader() { }
        internal InitiationHeader(IField[] param) {
            this.FromAgencyId = new FromAgencyId() { AgencyId = new SchemeValuePair() { Value = Convert.ToString(param.GetField("library").Value), Scheme = "http://informsystema.ru/marc.cloud/ncip" } };
            this.ToAgencyId = new ToAgencyId() { AgencyId = new SchemeValuePair() { Value = Convert.ToString(param.GetField("library").Value), Scheme = "http://informsystema.ru/marc.cloud/ncip" } };
        }
    }
}
