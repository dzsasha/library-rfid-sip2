using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : IEndPatronSession {
        bool ISip2Command<IEndPatronSessionRequest, IEndPatronSessionResponse>.execute(ISip2Config config, IEndPatronSessionRequest request, ref IEndPatronSessionResponse response) {
            lock (CS) {
                response.EndSession = true;
                response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value.ToString());
                response.PatronIdentifier = request.PatronIdentifier;
                response.Date = DateTime.Now;
                if (config.param.GetField("EndPatronSession.ScreenMessage") != null && config.param.GetField("EndPatronSession.ScreenMessage").Value != null) {
                    response.ScreenMessage = Convert.ToString(config.param.GetField("EndPatronSession.ScreenMessage").Value);
                }
                if (config.param.GetField("EndPatronSession.PrintLine") != null && config.param.GetField("EndPatronSession.PrintLine").Value != null) {
                    response.setPrintLine(config, Convert.ToString(config.param.GetField("EndPatronSession.PrintLine").Value));
                }

                return true;
            }
        }
    }
}
