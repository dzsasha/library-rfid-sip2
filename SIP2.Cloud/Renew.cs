using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using IS.Interface.SIP2;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : IRenew {
        bool ISip2Command<IRenewRequest, IRenewResponse>.execute(ISip2Config config, IRenewRequest request, ref IRenewResponse response) {
            lock (CS) {
                Boolean isSucceeded = true;
                try {
                    using (NCIPMessage message = config.param.GetAnswer(getRenew(config.param, new BarcodeValues() {itemId = request.ItemIdentifier, userId = request.PatronIdentifier, date = request.NbDueDate}))) {
                        foreach (var item in message.getItem<RenewItemResponse>().Items) {
                            if (item is ItemOptionalFields) {
                                if ((item as ItemOptionalFields).BibliographicDescription != null && !String.IsNullOrEmpty((item as ItemOptionalFields).BibliographicDescription.Title)) {
                                    response.TitleIdentifier = (item as ItemOptionalFields).BibliographicDescription.Title;
                                }
                            } else if (item is UserId) {
                                response.PatronIdentifier = (item as UserId).UserIdentifierValue;
                            } else if (item is ItemId) {
                                response.ItemIdentifier = (item as ItemId).ItemIdentifierValue;
                            } else if (item is DateTime) {
                                response.DueDate = (DateTime)item;
                            } else if (item is Problem) {
                                isSucceeded = false;
                                response.ItemIdentifier = request.ItemIdentifier;
                                response.PatronIdentifier = request.PatronIdentifier;
                                response.DueDate = DateTime.Now;
                                Log.For(this).ErrorFormat("ERROR!!! Renew: {0}", new Exception((item as Problem).ProblemDetail));
                            }
                        }
                    }
                    response.Ok = isSucceeded;
                    response.RenewalOk = isSucceeded;
                    response.MagneticMedia = false;
                    response.Desensitize = false;
                    response.Date = DateTime.Now;
                    response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                    if (config.param.GetField("Renew.ScreenMessage") != null && config.param.GetField("Renew.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString((isSucceeded) ? config.param.GetField("Renew.ScreenMessage").Value : config.param.GetField("Renew.ScreenMessage.Error").Value);
                    }
                    if (config.param.GetField("Renew.PrintLine") != null && config.param.GetField("Renew.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("Renew.PrintLine").Value));
                    }
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! Renew: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return true;
            }
        }
    }
}
