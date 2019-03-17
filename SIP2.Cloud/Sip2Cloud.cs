using IS.Interface.SIP2;
using System;
using System.Collections.Generic;
using IS.Interface;
using System.IO;
using System.Linq;
using IS.SIP2.Cloud.ncip;
using IS.SIP2.Cloud.ncip.v2;

namespace IS.SIP2.Cloud {
    public partial class Sip2Cloud : List<ISip2Cmd>, ISip2 {
        public Sip2Cloud() {
            Add(this as ILogin);
            Add(this as ISCStatus);
            Add(this as IPatronStatus);
            Add(this as IPatronInformation);
            Add(this as IItemInformation);
            Add(this as IRenew);
            Add(this as ICheckIn);
            Add(this as ICheckOut);
            Add(this as IEndPatronSession);
            Add(this as IItemStatusUpdate);
            Add(this as IRenewAll);
        }

        private static object CS = new Object();
        #region implementation ISip2
        public ISip2Cmd[] commands => ToArray();

        public void Sip2Cloud_error(object sender, ErrorEventArgs e) {
            Log.For(sender).Error(e.GetException());
            OnError?.Invoke(this, new ErrorEventArgs(e.GetException()));
        }

        public ISip2Config config { get; private set; }

        public event ErrorEventHandler OnError;
        private readonly List<String> _serverSettings = new List<string>() { "ReaderMaxOutputLimit", "ReaderMaxOrderLimit" };

        public bool init(ISip2Config _config) {
            bool bRet = false;
            try {
                config = _config;
                using (NCIPVersionMessage answer = config.param.GetAnswer(new NCIPVersionMessage(config.param))) {
                    if (answer.Item.GetType() == typeof(LookupVersionResponse)) {
                        foreach (string version in (answer.Item as LookupVersionResponse).VersionSupported) {
                            if ("2.0".Equals(version)) {
                                bRet = true;
                            }
                        }
                    }
                }

                foreach (string limit in _serverSettings) {
                    using (NCIPMessage message = config.param.GetAnswer(getLookupRequest(config.param, "com.informsystema.models.shared.CMSettingTypes", limit))) {
                        foreach (var item in message.getItem<LookupRequestResponse>().Items) {
                            if (item is RequestId) {
                                config.AddParam(new FieldImpl() { Name = (item as RequestId).RequestIdentifierType.Value, Type = TypeField.String, Value = (item as RequestId).RequestIdentifierValue });
                            } else if (item is Problem) {
                                Log.For(this).ErrorFormat("ERROR!!! LookupRequest({0}): {1}", limit, new Exception((item as Problem).ProblemDetail));
                            }
                        }
                    }
                }
                if (bRet) {
                    using (NCIPMessage message = config.param.GetAnswer(getLookupAgency(config.param))) {
                        foreach (var item in message.getItem<LookupAgencyResponse>().Items) {
                            if ((item is OrganizationNameInformation) && (item as OrganizationNameInformation).OrganizationNameType.Value != "InstitutionId") {
                                config.AddParam(new FieldImpl() { Name = "InstitutionId", Type = TypeField.String, Value = (item as OrganizationNameInformation).OrganizationName });
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                Log.For(this).Error("init: ", ex);
                OnError?.Invoke(this, new ErrorEventArgs(ex));
            }
            return bRet;
        }
        #endregion

        private SchemeValuePair[] getElementTypes(string[] values) {
            return values.Select(value => new SchemeValuePair() { Scheme = "http://infomsystema.ru/marc.cloud/ncip", Value = value }).ToArray();
        }

        internal class BarcodeValues {
            public string userId { get; set; }
            public string itemId { get; set; }
            public DateTime date { get; set; }
        }

        internal NCIPMessage getLookupAgency(IField[] param) {
            List<Object> items = new List<Object> {
                new LookupAgency() {
                    InitiationHeader = new InitiationHeader(param),
                    AgencyId = new SchemeValuePair() {
                        Value = Convert.ToString(param.GetField("library").Value),
                        Scheme = "http://infomsystema.ru/marc.cloud/ncip"},
                    AgencyElementType = getElementTypes(new string[] {"skName", "InstitutionId"})}
            };
            NCIPMessage result = new NCIPMessage(param) {
                Items = items.ToArray()
            };
            return result;
        }
        private NCIPMessage getLookupUser(IField[] param, BarcodeValues values) {
            List<Object> items = new List<Object> {
                new LookupUser() {
                    InitiationHeader = new InitiationHeader(param),
                    Items = new object[] {
                        new UserId() {
                            UserIdentifierValue = values.userId,
                            UserIdentifierType = new SchemeValuePair() {
                                    Value = "skBarCode",
                                    Scheme = "http://informsystema.ru/marc.cloud/ncip"},
                            AgencyId = new SchemeValuePair() {
                                Value = Convert.ToString(param.GetField("library").Value),
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip" }
                        }},
                    UserElementType = getElementTypes(new string[] {"UserId", "NameInformation", "UserLanguage", "BlockOrTrap", "DateOfBirth"}),
                    LoanedItemsDesired = new LoanedItemsDesired(),
                    RequestedItemsDesired = new RequestedItemsDesired()
                }
            };
            NCIPMessage result = new NCIPMessage(param) { Items = items.ToArray() };
            return result;
        }
        private NCIPMessage getLookupItem(IField[] param, BarcodeValues values) {
            List<Object> items = new List<Object> {
                new LookupItem() {
                    InitiationHeader = new InitiationHeader(param),
                    Item = new ItemId() {
                        AgencyId = new SchemeValuePair() {
                            Value = Convert.ToString(param.GetField("library").Value),
                            Scheme = "http://infomsystema.ru/marc.cloud/ncip"},
                        ItemIdentifierType = new SchemeValuePair() {
                            Value = "skBarCode", Scheme = "http://informsystema.ru/marc.cloud/ncip"},
                        ItemIdentifierValue = values.itemId},
                    ItemElementType = getElementTypes(new string[] {
                        "BibliographicDescription", "ItemUseRestrictionType", "CirculationStatus",
                        "HoldQueueLength", "ItemDescription", "Location"}),
                    CurrentBorrowerDesired = new CurrentBorrowerDesired(),
                    CurrentRequestersDesired = new CurrentRequestersDesired()
                }
            };
            NCIPMessage result = new NCIPMessage(param) { Items = items.ToArray() };
            return result;
        }
        private NCIPMessage getCheckIn(IField[] param, BarcodeValues values) {
            NCIPMessage result = new NCIPMessage(param) {
                Items = new Object[] {
                    new CheckInItem() {
                        InitiationHeader = new InitiationHeader(param),
                        ItemId = new ItemId() {
                            AgencyId = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = Convert.ToString(param.GetField("library").Value) },
                            ItemIdentifierType = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = "skBarCode" },
                            ItemIdentifierValue = values.itemId },
                        ItemElementType = getElementTypes(new string[] { "BibliographicDescription", "ItemUseRestrictionType", "CirculationStatus", "HoldQueueLength", "ItemDescription", "Location" }),
                        UserElementType = getElementTypes(new string[] { "UserId", "NameInformation", "UserLanguage", "BlockOrTrap", "DateOfBirth" })
                    }
                }
            };
            return result;
        }
        private NCIPMessage getCheckOut(IField[] param, BarcodeValues values) {
            NCIPMessage result = new NCIPMessage(param) {
                Items = new Object[] {
                    new CheckOutItem() {
                        InitiationHeader = new InitiationHeader(param),
                        MandatedAction = new MandatedAction() {
                            DateEventOccurred = DateTime.Now
                        },
                        ItemId = new ItemId() {
                            AgencyId = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = Convert.ToString(param.GetField("library").Value) },
                            ItemIdentifierType = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = "skBarCode" },
                            ItemIdentifierValue = values.itemId },
                        Items = new Object[] {
                            new UserId() {
                                UserIdentifierValue = values.userId,
                                UserIdentifierType =  new SchemeValuePair() {
                                    Value = "skBarCode",
                                    Scheme = "http://informsystema.ru/marc.cloud/ncip" },
                                AgencyId = new SchemeValuePair() {
                                    Value = Convert.ToString(param.GetField("library").Value),
                                    Scheme = "http://infomsystema.ru/marc.cloud/ncip" }
                            }
                        },
                        ItemElementType = getElementTypes(new string[] { "BibliographicDescription", "ItemUseRestrictionType", "CirculationStatus", "HoldQueueLength", "ItemDescription", "Location" }),
                        UserElementType = getElementTypes(new string[] { "UserId", "NameInformation", "UserLanguage", "BlockOrTrap", "DateOfBirth" })
                    }
                }
            };

            return result;
        }

        private NCIPMessage getRenew(IField[] param, BarcodeValues values) {
            NCIPMessage result = new NCIPMessage(param) {
                Items = new Object[] {
                    new RenewItem() {
                        InitiationHeader = new InitiationHeader(param),
                        Items = new Object[] {
                            new UserId() {
                                UserIdentifierValue = values.userId,
                                UserIdentifierType = new SchemeValuePair() {
                                    Value = "skBarCode",
                                    Scheme = "http://informsystema.ru/marc.cloud/ncip"
                                },
                                AgencyId = new SchemeValuePair() {
                                    Value = Convert.ToString(param.GetField("library").Value),
                                    Scheme = "http://infomsystema.ru/marc.cloud/ncip" }
                            }
                        },
                        ItemId = new ItemId() {
                            AgencyId = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = Convert.ToString(param.GetField("library").Value) },
                            ItemIdentifierType = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = "skBarCode" },
                            ItemIdentifierValue = values.itemId },
                        DesiredDateDue = values.date,
                        ItemElementType = getElementTypes(new string[] { "BibliographicDescription", "ItemUseRestrictionType", "CirculationStatus", "HoldQueueLength", "ItemDescription", "Location" }),
                        UserElementType = getElementTypes(new string[] { "UserId", "NameInformation", "UserLanguage", "BlockOrTrap", "DateOfBirth" })
                    }
                }
            };
            return result;
        }

        private NCIPMessage getUndoCheckOut(IField[] param, BarcodeValues values) {
            NCIPMessage result = new NCIPMessage(param) {
                Items = new Object[] {
                    new UndoCheckOutItem() {
                        InitiationHeader = new InitiationHeader(param),
                        ItemId = new ItemId() {
                            AgencyId = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = Convert.ToString(param.GetField("library").Value) },
                            ItemIdentifierType = new SchemeValuePair() {
                                Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                Value = "skBarCode" },
                            ItemIdentifierValue = values.itemId },
                        Items = new Object[] {
                            new UserId() {
                                AgencyId = new SchemeValuePair() {
                                    Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                    Value = Convert.ToString(param.GetField("library").Value) },
                                UserIdentifierValue = values.userId,
                                UserIdentifierType = new SchemeValuePair() {
                                    Value = "skBarCode",
                                    Scheme = "http://informsystema.ru/marc.cloud/ncip" }
                            }
                        },
                        MandatedAction = new MandatedAction() {
                            DateEventOccurred = values.date
                        }
                    }
                }
            };
            return result;
        }

        private NCIPMessage getLookupRequest(IField[] param, string type, string value) {
            NCIPMessage result = new NCIPMessage(param) {
                Items = new object[] {
                    new LookupRequest() {
                        InitiationHeader = new InitiationHeader(param),
                        Items = new object[] {
                            new RequestId() {
                                AgencyId = new SchemeValuePair() {
                                    Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                    Value = Convert.ToString(param.GetField("library").Value) },
                                RequestIdentifierType = new SchemeValuePair() {
                                    Scheme = "http://infomsystema.ru/marc.cloud/ncip",
                                    Value = type },
                                RequestIdentifierValue = value
                            }
                        }
                    }
                }
            };
            return result;
        }
    }
}
