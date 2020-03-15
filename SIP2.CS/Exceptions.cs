using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.CS {
    public class CheckSumException : Exception {
        public CheckSumException() : base("error checksum") {}
    }

    public class RequiredFieldException : Exception {
        public RequiredFieldException() : base("required field") { }
    }

}
