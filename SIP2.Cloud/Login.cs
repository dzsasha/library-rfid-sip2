using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : ILogin {
        bool ISip2Command<ILoginRequest, ILoginResponse>.execute(ISip2Config config, ILoginRequest request, ref ILoginResponse response) {
            lock (CS) {
                response.Ok = true;
                return response.Ok;
            }
        }
    }
}
