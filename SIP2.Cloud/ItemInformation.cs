using IS.Interface;
using IS.Interface.SIP2;
using IS.SIP2.Cloud.ncip.v2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.SIP2.Cloud {
    partial class Sip2Cloud : IItemInformation {
        bool ISip2Command<IItemInformationRequest, IItemInformationResponse>.execute(ISip2Config config, IItemInformationRequest request, ref IItemInformationResponse response) {
            lock (CS) {
                Boolean isSucceeded = true;
                try {
                    response.ItemIdentifier = request.ItemIdentifier;
                    using (NCIPMessage message = config.param.GetAnswer(getLookupItem(config.param, new BarcodeValues() {itemId = request.ItemIdentifier}))) {
                        foreach (var item in message.getItem<LookupItemResponse>().Items) {
                            if (item is ItemOptionalFields) {
                                if ((item as ItemOptionalFields).SecurityMarker != null) {
                                    if ((item as ItemOptionalFields).SecurityMarker.Value.Equals("None")) {
                                        response.SecurityMarker = SecurityMarker.None;
                                    } else if ((item as ItemOptionalFields).SecurityMarker.Value.Equals("Other")) {
                                        response.SecurityMarker = SecurityMarker.Other;
                                    } else if ((item as ItemOptionalFields).SecurityMarker.Value.Equals("Tattle")) {
                                        response.SecurityMarker = SecurityMarker.Tattle;
                                    } else if ((item as ItemOptionalFields).SecurityMarker.Value.Equals("Whisper")) {
                                        response.SecurityMarker = SecurityMarker.Whisper;
                                    }
                                }
                                if ((item as ItemOptionalFields).DateDue != null) {
                                    response.DueDate = (item as ItemOptionalFields).DateDue;
                                }
                                if ((item as ItemOptionalFields).BibliographicDescription != null) {
                                    response.TitleIdentifier = (item as ItemOptionalFields).BibliographicDescription.Title;
                                }
                                if ((item as ItemOptionalFields).CirculationStatus != null) {
                                    if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Not Available")) {
                                        response.CirculationStatus = Sip2CirculationStatus.Other;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("On Order")) {
                                        response.CirculationStatus = Sip2CirculationStatus.OnOrder;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Available On Shelf")) {
                                        response.CirculationStatus = Sip2CirculationStatus.Available;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("On Loan")) {
                                        response.CirculationStatus = Sip2CirculationStatus.Charged;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("ChargedNotRecall")) {
                                        response.CirculationStatus = Sip2CirculationStatus.ChargedNotRecall;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("In Process")) {
                                        response.CirculationStatus = Sip2CirculationStatus.InProcess;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Recalled")) {
                                        response.CirculationStatus = Sip2CirculationStatus.ReCalled;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("HoldShelf")) {
                                        response.CirculationStatus = Sip2CirculationStatus.HoldShelf;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Waiting To Be Reshelved")) {
                                        response.CirculationStatus = Sip2CirculationStatus.HoldShelf;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("In Transit Between Library Locations")) {
                                        response.CirculationStatus = Sip2CirculationStatus.InTransit;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Claimed Returned Or Never Borrowed")) {
                                        response.CirculationStatus = Sip2CirculationStatus.ClaimedReurned;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Lost")) {
                                        response.CirculationStatus = Sip2CirculationStatus.Lost;
                                    } else if ((item as ItemOptionalFields).CirculationStatus.Value.Equals("Missing")) {
                                        response.CirculationStatus = Sip2CirculationStatus.Missing;
                                    }
                                }
                                if ((item as ItemOptionalFields).Location != null) {
                                    foreach (var test in ((item as ItemOptionalFields).Location)) {
                                        foreach (LocationNameInstance instance in test.LocationName.LocationNameInstance) {
                                            response.CurrentLocation = instance.LocationNameValue;
                                        }
                                    }
                                }
                            } else if (item is Problem) {
                                isSucceeded = false;
                                response.ItemIdentifier = request.ItemIdentifier;
                                Log.For(this).ErrorFormat("ERROR!!! ItemInformation: {0}", new Exception((item as Problem).ProblemDetail));
                            }
                        }
                    }
                    if (config.param.GetField("ItemInformation.ScreenMessage") != null && config.param.GetField("ItemInformation.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString((isSucceeded) ? config.param.GetField("ItemInformation.ScreenMessage").Value : config.param.GetField("ItemInformation.ScreenMessage.Error").Value);
                    }
                    if (config.param.GetField("ItemInformation.PrintLine") != null && config.param.GetField("ItemInformation.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("ItemInformation.PrintLine").Value));
                    }
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! ItemInformation: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return true;
            }
        }
    }
}
