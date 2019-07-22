using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface.SIP2;
using IS.Interface;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : ICheckIn {
        bool ISip2Command<ICheckInRequest, ICheckInResponse>.execute(ISip2Config config, ICheckInRequest request, ref ICheckInResponse response) {
            lock (CS) {
                try {
                    String errString = "";
                    using (NCIPMessage message = config.param.GetAnswer(getCheckIn(config.param, new BarcodeValues() { itemId = request.ItemIdentifier }))) {
                        response.Ok = true;
                        foreach (var item in message.getItem<CheckInItemResponse>().Items) {
                            if (item is ItemId) {
                                response.ItemIdentifier = (item as ItemId).ItemIdentifierValue;
                            } else if (item is ItemOptionalFields) {
                                if ((item as ItemOptionalFields).BibliographicDescription != null && !String.IsNullOrEmpty((item as ItemOptionalFields).BibliographicDescription.Title)) {
                                    response.TitleIdentifier = (item as ItemOptionalFields).BibliographicDescription.Title;
                                }
                                foreach (var location in (item as ItemOptionalFields).Location) {
                                    if (location.LocationType.Value == "Permanent Location") {
                                        response.PermanentLocation = location.LocationName.LocationNameInstance[0].LocationNameValue;
                                    }
                                }
                            } else if (item is UserId) {
                                response.PatronIdentifier = (item as UserId).UserIdentifierValue;
                            } else if (item is Problem) {
                                response.Ok = false;
                                response.ItemIdentifier = request.ItemIdentifier;
                                response.ItemProperties = request.ItemProperties;
                                errString = (item as Problem).ProblemDetail;
                                Log.For(this).ErrorFormat("ERROR!!! CheckIn: {0}", new Exception((item as Problem).ProblemDetail));
                            }
                        }
                        response.Resensitize = response.Ok;
                        response.MagneticMedia = false;
                        response.Alert = false;
                        response.Date = DateTime.Now;
                        response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                        if (config.param.GetField("CheckIn.ScreenMessage") != null && config.param.GetField("CheckIn.ScreenMessage").Value != null) {
                            response.ScreenMessage = response.Ok ? Convert.ToString(config.param.GetField("CheckIn.ScreenMessage").Value) : errString;
                        }
                        if (config.param.GetField("CheckIn.PrintLine") != null && config.param.GetField("CheckIn.PrintLine").Value != null) {
                            response.setPrintLine(config, Convert.ToString(config.param.GetField("CheckIn.PrintLine").Value));
                        }
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
