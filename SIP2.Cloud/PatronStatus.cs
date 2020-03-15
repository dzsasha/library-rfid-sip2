using System;
using System.IO;
using IS.Interface.SIP2;
using IS.SIP2.Cloud.ncip.v2;
using IS.Interface;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : IPatronStatus {
        bool ISip2Command<IPatronStatusRequest, IPatronStatusResponse>.execute(ISip2Config config, IPatronStatusRequest request, ref IPatronStatusResponse response) {
            lock (CS) {
                Boolean isSucceeded = true;
                _status = 0;
                try {
                    using (NCIPMessage message = config.param.GetAnswer(getLookupUser(config.param, new BarcodeValues() {userId = request.PatronIdentifier}))) {
                        foreach (var item in message.getItem<LookupUserResponse>().Items) {
                            if (item is UserOptionalFields userOptionalFields) {
                                if (userOptionalFields.UserLanguage != null) {
                                    //                                response.GetField("language").Value = (item as UserOptionalFields).UserLanguage[0].Value;
                                }
                                if (userOptionalFields.NameInformation != null) {
                                    foreach (var nameInformation in userOptionalFields.NameInformation.Items) {
                                        if (nameInformation is PersonalNameInformation information) {
                                            foreach (var personalNameInformation in information.Items) {
                                                if (personalNameInformation is StructuredPersonalUserName structuredPersonalUserName) {
                                                    response.PersonalName =
                                                        $"{structuredPersonalUserName.GivenName} {structuredPersonalUserName.Surname}";
                                                } else if (personalNameInformation is string) {
                                                    response.PersonalName = (personalNameInformation as string);
                                                }
                                            }
                                        }
                                    }
                                }
                                if (userOptionalFields.BlockOrTrap != null && userOptionalFields.BlockOrTrap.Length > 0) {
                                    foreach (BlockOrTrap block in userOptionalFields.BlockOrTrap) {
                                        if (block.BlockOrTrapType.Value.Equals("Block Check Out")) {
                                            _status |= Convert.ToUInt16(EPatronStatus.PaymentRule);
                                            _status |= Convert.ToUInt16(EPatronStatus.ManyOverdueItems);
                                        }
                                    }
                                }
                            } else if (item is Problem problem) {
                                isSucceeded = false;
                                response.PatronIdentifier = request.PatronIdentifier;
                                Log.For(this).ErrorFormat("ERROR!!! PatronStatus: {0}", new Exception(problem.ProblemDetail));
                            } else if (item is UserId userId) {
                                response.PatronIdentifier = userId.UserIdentifierValue;
                                response.ValidPatron = true;
                                response.ValidPatronPassword = true;
                            }
                        }
                    }
                    response.Language = request.Language;
                    response.PatronStatus = _status;
                    response.Date = DateTime.Now;
                    response.InstitutionId = Convert.ToString(config.param.GetField("InstitutionId").Value.ToString());
                    if (config.param.GetField("PatronStatus.ScreenMessage") != null && config.param.GetField("PatronStatus.ScreenMessage").Value != null) {
                        response.ScreenMessage = Convert.ToString(isSucceeded ? config.param.GetField("PatronStatus.ScreenMessage").Value : config.param.GetField("PatronStatus.ScreenMessage.Error").Value);
                    }
                    if (config.param.GetField("PatronStatus.PrintLine") != null && config.param.GetField("PatronStatus.PrintLine").Value != null) {
                        response.setPrintLine(config, Convert.ToString(config.param.GetField("PatronStatus.PrintLine").Value));
                    }
                } catch (Exception ex) {
                    Log.For(this).ErrorFormat("ERROR!!! PatronStatus: {0}", ex.Message);
                    OnError?.Invoke(this, new ErrorEventArgs(ex));
                }
                return true;
            }
        }
        private ushort _status = 0x0000;
    }
}
