using System;
using System.Collections.Generic;
using IS.Interface.SIP2;
using IS.SIP2.Cloud.ncip.v2;
using IS.Interface;
using System.IO;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : ISCStatus {
        bool ISip2Command<ISCStatusRequest, ISCStatusResponse>.execute(ISip2Config config, ISCStatusRequest request, ref ISCStatusResponse response) {
            lock (CS) {
                response.CheckinOk = true;
                response.CheckoutOk = true;
                response.OnlineStatus = true;
                response.OfflineOk = true;
                response.RenewalPolicy = true;
                response.StatusUpdateOk = true;
                response.TerminalLocation = "";
                response.SupportedMessages = "YYYNYYYYYNYYNNYY";
//              response.SupportedMessages = "0123456789012345";
                response.RetriesAllowed = 5;
                response.TimeoutPeriod = 120;
                response.Version = request.Version;
                config.Version = request.Version;
                response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                try {
                    config.AddParam(new FieldImpl() { Name = "MaxPrintWidth", Type = TypeField.Integer, Value = request.MaxPrintWidth });
                    response.Date = DateTime.Now;
                    if (config.param.GetField("SCStatus.ScreenMessage") != null && config.param.GetField("SCStatus.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString(config.param.GetField("SCStatus.ScreenMessage").Value);
                    }
                    if (config.param.GetField("SCStatus.PrintLine") != null && config.param.GetField("SCStatus.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("SCStatus.PrintLine").Value));
                    }
                    response.LibraryName = config.param.GetField("InstitutionId").Value.ToString();
                    return true;
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! SCStatus: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                    throw;
                }
            }
        }
    }
}
