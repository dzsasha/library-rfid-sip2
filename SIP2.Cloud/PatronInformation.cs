using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.IO;
using IS.Interface;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : IPatronInformation {
        bool ISip2Command<IPatronInformationRequest, IPatronInformationResponse>.execute(ISip2Config config,
            IPatronInformationRequest request, ref IPatronInformationResponse response) {
            lock(CS) {
                _status = 0;
                Boolean isSucceeded = true;
                try {
                    response.OverDueItemsCount = 0;
                    List<string> loanedItems = new List<string>();
                    List<string> holdItems = new List<string>();
                    List<string> overItems = new List<string>();
                    using(NCIPMessage message =
                        config.param.GetAnswer(getLookupUser(config.param, new BarcodeValues() { userId = request.PatronIdentifier }))) {
                        foreach(var item in message.getItem<LookupUserResponse>().Items) {
                            if(item is UserOptionalFields fields) {
                                if(fields.UserLanguage != null) {
                                    //                                response.GetField("language").Value = (item as UserOptionalFields).UserLanguage[0].Value;
                                }
                                if(fields.NameInformation != null) {
                                    foreach(var nameInformation in fields.NameInformation.Items) {
                                        if(nameInformation is PersonalNameInformation information) {
                                            foreach(var personalNameInformation in information.Items) {
                                                if(personalNameInformation is StructuredPersonalUserName name) {
                                                    response.PersonalName =
                                                        $"{name.GivenName} {name.Surname}";
                                                } else if(personalNameInformation is string s) {
                                                    response.PersonalName = s;
                                                }
                                            }
                                        }
                                    }
                                }
                                if(fields.BlockOrTrap != null && fields.BlockOrTrap.Length > 0) {
                                    foreach(BlockOrTrap block in fields.BlockOrTrap) {
                                        if(block.BlockOrTrapType.Value.Equals("Block Check Out")) {
                                            _status |= Convert.ToUInt16(EPatronStatus.PaymentRule);
                                            _status |= Convert.ToUInt16(EPatronStatus.ManyOverdueItems);
                                        }
                                    }
                                }
                            } else if(item is Problem problem) {
                                isSucceeded = false;
                                response.PatronIdentifier = request.PatronIdentifier;
                                Log.For(this).ErrorFormat("ERROR!!! PatronInformation: {0}", new Exception(problem.ProblemDetail));
                            } else if(item is LoanedItem loanedItem) {
                                if((loanedItem.Item as DateTime? ?? new DateTime()).Date < DateTime.Now.Date) {
                                    overItems.Add(loanedItem.ItemId.ItemIdentifierValue);
                                } else {
                                    loanedItems.Add(loanedItem.ItemId.ItemIdentifierValue);
                                }
                            } else if(item is RequestedItem requestedItem) {
                                foreach(var requestedItemItem in requestedItem.Items) {
                                    if(requestedItemItem is ItemId itemId) {
                                        holdItems.Add(itemId.ItemIdentifierValue);
                                    }
                                }
                            } else if(item is UserId id) {
                                response.PatronIdentifier = id.UserIdentifierValue;
                                response.ValidPatron = true;
                                response.ValidPatronPassword = true;
                            }
                        }
                    }

                    response.ChargedItemsLimit = (config.param.GetField("ReaderMaxOutputLimit") != null) ?
                        Convert.ToInt32(config.param.GetField("ReaderMaxOutputLimit").Value) : 0;
                    response.ChargedItemsCount = loanedItems.Count;
                    if(response.ChargedItemsCount == response.ChargedItemsLimit) {
                        _status |= Convert.ToUInt16(EPatronStatus.ManyOverdueItems);
                    }
                    if(loanedItems.Count > 0 && request.Summary[2]) {
                        response.ChargedItems = loanedItems.ToArray();
                    }

                    response.OverDueItemsCount = overItems.Count;
                    response.OverDueItemsLimit = 0;
                    if(overItems.Count > 0 && request.Summary[1]) {
                        response.OverDueItems = overItems.ToArray();
                        _status |= Convert.ToUInt16(EPatronStatus.ManyOverdueItems);
                    }

                    response.HoldItemsLimit = (config.param.GetField("ReaderMaxOrderLimit") != null) ?
                        Convert.ToInt32(config.param.GetField("ReaderMaxOrderLimit").Value) : 0;

                    response.HoldItemsCount = holdItems.Count;
                    if (holdItems.Count > 0 && request.Summary[0]) {
                        response.HoldItems = holdItems.ToArray();
                    }
                    response.Language = request.Language;
                    response.PatronStatus = _status;
                    response.Date = DateTime.Now;
                    response.FineItemsCount = 0;
                    response.ReCallItemsCount = 0;
                    response.UnAvailableItemsCount = 0;
                    response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                    if(config.param.GetField("PatronInformation.ScreenMessage") != null && config.param.GetField("PatronInformation.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString(isSucceeded ? config.param.GetField("PatronInformation.ScreenMessage").Value : config.param.GetField("PatronInformation.ScreenMessage.Error").Value);
                    }
                    if(config.param.GetField("PatronInformation.PrintLine") != null && config.param.GetField("PatronInformation.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("PatronInformation.PrintLine").Value));
                    }
                } catch(Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! PatronInformation: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return true;
            }
        }
    }
}
