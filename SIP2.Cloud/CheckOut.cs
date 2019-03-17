using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;
using IS.Interface;
using IS.SIP2.Cloud.ncip.v2;
using System.IO;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : ICheckOut {
        bool ISip2Command<ICheckOutRequest, ICheckOutResponse>.execute(ISip2Config config, ICheckOutRequest request, ref ICheckOutResponse response) {
            lock (CS) {
                try {
                    bool isOk = false;
                    String errString = "";
                    if (!request.Cancel) {
                        using (NCIPMessage message = config.param.GetAnswer(getCheckOut(config.param, new BarcodeValues() { itemId = request.ItemIdentifier, userId = request.PatronIdentifier, date = request.DueDate }))) {
                            foreach (var item in message.getItem<CheckOutItemResponse>().Items) {
                                if (item is Problem) {
                                    isOk = false;
                                    response.PatronIdentifier = request.PatronIdentifier;
                                    response.ItemIdentifier = request.ItemIdentifier;
                                    response.DueDate = DateTime.Now;
                                    errString = (item as Problem).ProblemDetail;
                                    Log.For(this).ErrorFormat("ERROR!!! CheckOut: {0}", new Exception((item as Problem).ProblemDetail));
                                } else {
                                    isOk = true;
                                }
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
                                }
                            }
                        }
                    } else {    // Тут отмена операции
                        using (NCIPMessage message = config.param.GetAnswer(getUndoCheckOut(config.param, new BarcodeValues() { itemId = request.ItemIdentifier, userId = request.PatronIdentifier, date = request.DueDate }))) {
                            foreach (var item in message.getItem<UndoCheckOutItemResponse>().Items) {
                                if (item is Problem) {
                                    isOk = false;
                                    response.PatronIdentifier = request.PatronIdentifier;
                                    response.ItemIdentifier = request.ItemIdentifier;
                                    errString = (item as Problem).ProblemDetail;
                                    Log.For(this).ErrorFormat("ERROR!!! CheckOut: {0}", new Exception((item as Problem).ProblemDetail));
                                } else {
                                    isOk = true;
                                }
                                if (item is UserId) {
                                    response.PatronIdentifier = (item as UserId).UserIdentifierValue;
                                } else if (item is ItemId) {
                                    response.ItemIdentifier = (item as ItemId).ItemIdentifierValue;
                                }
                            }
                        }
                    }
                    response.Ok = isOk;
                    response.Desensitize = !request.Cancel && isOk;
                    response.RenewalOk = !request.Cancel && isOk;
                    response.MagneticMedia = false;
                    response.Date = DateTime.Now;
                    response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                    if (config.param.GetField("CheckOut.ScreenMessage") != null && config.param.GetField("CheckOut.ScreenMessage").Value != null) {
                        response.ScreenMessage = response.Ok ? Convert.ToString(config.param.GetField("CheckOut.ScreenMessage").Value) : errString;
                    }
                    if (config.param.GetField("CheckOut.PrintLine") != null && config.param.GetField("CheckOut.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("CheckOut.PrintLine").Value));
                    }
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! CheckIn: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return true;
            }
        }
    }
}
