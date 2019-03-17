using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : IPatronInformation {
        bool ISip2Command<IPatronInformationRequest, IPatronInformationResponse>.execute(ISip2Config config,
            IPatronInformationRequest request, ref IPatronInformationResponse response) {
            lock (CS) {
                try {
                    Boolean isSucceeded = true;
                    response.OverDueItemsCount = 0;
                    List<string> loanedItems = new List<string>();
                    List<string> overItems = new List<string>();
                    using (NCIPMessage message =
                        config.param.GetAnswer(getLookupUser(config.param, new BarcodeValues() { userId = request.PatronIdentifier }))) {
                        foreach (var item in message.getItem<LookupUserResponse>().Items) {
                            if (item is UserOptionalFields) {
                                if ((item as UserOptionalFields).UserLanguage != null) {
                                    //                                response.GetField("language").Value = (item as UserOptionalFields).UserLanguage[0].Value;
                                }
                                if ((item as UserOptionalFields).NameInformation != null) {
                                    foreach (var nameInformation in (item as UserOptionalFields).NameInformation.Items) {
                                        var information = nameInformation as PersonalNameInformation;
                                        if (information != null) {
                                            foreach (var personalNameInformation in information.Items) {
                                                if (personalNameInformation is StructuredPersonalUserName) {
                                                    response.PersonalName =
                                                        $"{(personalNameInformation as StructuredPersonalUserName).GivenName} {(personalNameInformation as StructuredPersonalUserName).Surname}";
                                                } else if (personalNameInformation is string) {
                                                    response.PersonalName = (personalNameInformation as string);
                                                }
                                            }
                                        }
                                    }
                                }
                                if ((item as UserOptionalFields).BlockOrTrap != null && (item as UserOptionalFields).BlockOrTrap.Length > 0) {
                                    foreach (BlockOrTrap block in (item as UserOptionalFields).BlockOrTrap) {
                                        if (block.BlockOrTrapType.Value.Equals("Block Check Out")) {
                                            _status |= Convert.ToUInt16(EPatronStatus.ManyOverdueItems);
                                        }
                                    }
                                }
                            } else if (item is Problem) {
                                isSucceeded = false;
                                response.PatronIdentifier = request.PatronIdentifier;
                                Log.For(this).ErrorFormat("ERROR!!! PatronInformation: {0}", new Exception((item as Problem).ProblemDetail));
                            } else if (item is LoanedItem) {
                                if (((item as LoanedItem).Item is DateTime ? (DateTime)(item as LoanedItem).Item : new DateTime()) < DateTime.Now) {
                                    overItems.Add((item as LoanedItem).ItemId.ItemIdentifierValue);
                                } else {
                                    loanedItems.Add((item as LoanedItem).ItemId.ItemIdentifierValue);
                                }
                            } else if (item is UserId) {
                                response.PatronIdentifier = (item as UserId).UserIdentifierValue;
                                response.ValidPatron = true;
                                response.ValidPatronPassword = true;
                            }
                        }
                    }

                    response.ChargedItemsLimit = (config.param.GetField("ReaderMaxOutputLimit") != null) ?
                        Convert.ToInt32(config.param.GetField("ReaderMaxOutputLimit").Value) : 0;
                    response.ChargedItemsCount = loanedItems.Count;
                    if (loanedItems.Count > 0 && request.Summary[2]) {
                        response.ChargedItems = loanedItems.ToArray();
                    }

                    response.OverDueItemsCount = overItems.Count;
                    response.OverDueItemsLimit = 0;
                    if (overItems.Count > 0 && request.Summary[1]) {
                        response.OverDueItems = overItems.ToArray();
                        _status |= Convert.ToUInt16(EPatronStatus.ManyOverdueItems);
                    }

                    response.HoldItemsLimit = (config.param.GetField("ReaderMaxOrderLimit") != null) ?
                        Convert.ToInt32(config.param.GetField("ReaderMaxOrderLimit").Value) : 0;

                    response.HoldItemsCount = 0;
                    response.Language = request.Language;
                    response.PatronStatus = BitConverter.GetBytes(_status);
                    response.Date = DateTime.Now;
                    response.FineItemsCount = 0;
                    response.ReCallItemsCount = 0;
                    response.UnAvailableItemsCount = 0;
                    response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value);
                    if (config.param.GetField("PatronInformation.ScreenMessage") != null && config.param.GetField("PatronInformation.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString(isSucceeded ? config.param.GetField("PatronInformation.ScreenMessage").Value : config.param.GetField("PatronInformation.ScreenMessage.Error").Value);
                    }
                    if (config.param.GetField("PatronInformation.PrintLine") != null && config.param.GetField("PatronInformation.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("PatronInformation.PrintLine").Value));
                    }
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! PatronInformation: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return true;
            }
        }
    }
}
