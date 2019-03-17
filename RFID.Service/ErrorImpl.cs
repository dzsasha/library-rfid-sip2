using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IS.RFID.Service {
    [DataContract(Name = "Error", Namespace = "http://informsystema.com/marc/service/")]
    public class ErrorImpl {
        public ErrorImpl(Exception ex) {
            ErrorMessage = ex.Message;
        }
        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
