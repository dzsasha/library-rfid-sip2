using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : IRenewAll {
        bool ISip2Command<IRenewAllRequest, IRenewAllResponse>.execute(ISip2Config config, IRenewAllRequest request, ref IRenewAllResponse response) {
            lock (CS) {
                bool isSucceeded = true;
                List<String> renewedItems = new List<string>();
                List<String> unrenewedItems = new List<string>();
                using (NCIPMessage message = config.param.GetAnswer(getLookupUser(config.param, new BarcodeValues() { userId = request.PatronIdentifier }))) {
                    foreach (var item in message.getItem<LookupUserResponse>().Items) {
                        if (item is LoanedItem) {
                            using (NCIPMessage msg = config.param.GetAnswer(getRenew(config.param, new BarcodeValues() { itemId = (item as LoanedItem).ItemId.ItemIdentifierValue, userId = request.PatronIdentifier, date = DateTime.Now }))) {
                                foreach (var renewItem in msg.getItem<RenewItemResponse>().Items) {
                                    if (renewItem is Problem) {
                                        unrenewedItems.Add((item as LoanedItem).ItemId.ItemIdentifierValue);
                                    } else if (renewItem is ItemId) {
                                        renewedItems.Add((renewItem as ItemId).ItemIdentifierValue);
                                    }
                                }
                            }
                        }
                    }
                }

                isSucceeded = renewedItems.Count > 0;
                response.Ok = isSucceeded;
                response.RenewedItems = renewedItems.ToArray();
                response.RenewedCount = renewedItems.Count;
                response.UnRenewedItems = unrenewedItems.ToArray();
                response.UnRenewedCount = unrenewedItems.Count;
                response.Date = DateTime.Now;
                response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                if (config.param.GetField("RenewAll.ScreenMessage") != null && config.param.GetField("RenewAll.ScreenMessage").Value != null) {
                    response.ScreenMessage = Convert.ToString((isSucceeded) ? config.param.GetField("RenewAll.ScreenMessage").Value : config.param.GetField("RenewAll.ScreenMessage.Error").Value);
                }
                if (config.param.GetField("RenewAll.PrintLine") != null && config.param.GetField("RenewAll.PrintLine").Value != null) {
                    response.setPrintLine(config, Convert.ToString(config.param.GetField("RenewAll.PrintLine").Value));
                }
                return true;
            }
        }
    }
}
