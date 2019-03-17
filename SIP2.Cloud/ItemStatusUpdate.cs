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
    public partial class Sip2Cloud : IItemStatusUpdate {
        bool ISip2Command<IItemStatusUpdateRequest, IItemStatusUpdateResponse>.execute(ISip2Config config,
            IItemStatusUpdateRequest request, ref IItemStatusUpdateResponse response) {
            lock (CS) {
                response.ItemPropertiesOk = true;
                try {
                    using (NCIPMessage message = config.param.GetAnswer(getLookupItem(config.param, new BarcodeValues() {itemId = request.ItemIdentifier}))) {
                        foreach (var item in message.getItem<LookupItemResponse>().Items) {
                            if (item is ItemOptionalFields) {
                                if ((item as ItemOptionalFields).BibliographicDescription != null) {
                                    response.TitleIdentifier = (item as ItemOptionalFields).BibliographicDescription.Title;
                                }
                            } else if (item is Problem) {
                                response.ItemPropertiesOk = false;
                                Log.For(this).ErrorFormat("ERROR!!! ItemStatusUpdate: {0}", new Exception((item as Problem).ProblemDetail));
                            }
                        }
                    }

                    response.ItemIdentifier = request.ItemIdentifier;
                    response.date = DateTime.Now;
                    response.ItemProperties = "0";
                    if (config.param.GetField("ItemStatusUpdate.ScreenMessage") != null && config.param.GetField("ItemStatusUpdate.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString(response.ItemPropertiesOk ? config.param.GetField("ItemStatusUpdate.ScreenMessage").Value : config.param.GetField("ItemStatusUpdate.ScreenMessage.Error").Value);
                    }
                    if (config.param.GetField("ItemStatusUpdate.PrintLine") != null && config.param.GetField("ItemStatusUpdate.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("ItemStatusUpdate.PrintLine").Value));
                    }
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! ItemStatusUpdate: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }

                return true;
            }
        }
    }
}
