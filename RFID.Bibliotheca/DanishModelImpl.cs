using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Interface;

namespace IS.RFID.Bibliotheca {
    public class DanishModelImpl : ModelImpl, IModelEx {
        public DanishModelImpl() : base(TypeModel.Danish) {
            IsInited = true;
            _fields.Add(new FieldImpl() { Name = "ID", Type = TypeField.String, Value = "" });
            _fields.Add(new FieldImpl() { Name = "Library", Type = TypeField.String, Value = "" });
            _fields.Add(new FieldImpl() { Name = "Country", Type = TypeField.String, Value = "" });
        }
        public DanishModelImpl(int iIndex) : this() {
            Index = iIndex;
            Id = External.BibGetItemID(Index);
            if (!String.IsNullOrEmpty(Id)) {
                Library = External.BibGetLibraryInstitutionID(Index);
                Country = External.BibGetLibraryCountryID(Index);
                if (Convert.ToBoolean(External.BibGetIsItemLabel(Index))) Type = TypeItem.Item;
                else if (Convert.ToBoolean(External.BibGetIsUserCard(Index))) Type = TypeItem.Person;
                else Type = TypeItem.Unknown;
            }
        }
        private int _Index { get; set; }
        private readonly List<IField> _fields = new List<IField>();
        internal Boolean IsInited { get; set; }
        internal IField GetField(string name) {
            return _fields.FirstOrDefault(field => field.Name.Equals(name));
        }

        internal static DanishModelImpl Default(int iIndex, string id, IEnumerable<IField> param) {
            DanishModelImpl pRet = new DanishModelImpl() { Id = id, Type = TypeItem.Item, IsInited = false, Index = iIndex };
            (pRet as ModelImpl).Id = id;
            foreach (IField field in param) {
                switch (field.Name) {
                    case "Country":
                        pRet.Country = field.Value.ToString();
                        break;
                    case "ISIL":
                        pRet.Library = field.Value.ToString();
                        break;
                }
            }
            return pRet;
        }

        internal string Library {
            get { return GetField("Library").Value.ToString(); }
            set { GetField("Library").Value = value; }
        }
        internal string Country {
            get { return GetField("Country").Value.ToString(); }
            set { GetField("Country").Value = value; }
        }
        internal int Index { get; set; }
        public new string Id {
            get { return GetField("ID").Value.ToString(); }
            set { GetField("ID").Value = value; }
        }

        public override void Write() {
            switch (Type) {
                case TypeItem.Item: {
                        External.BibInitItemLabel(Index);
                        External.BibSetItemID(Index, Id);
                        break;
                    }
                case TypeItem.Person: {
                        External.BibInitUserCard(Index);
                        External.BibSetUserID(Index, Id);
                        break;
                    }
            }
            External.BibSetLibraryInstitutionID(Index, Library);
            External.BibSetLibraryCountryID(Index, Country);
            External.BibWriteChangedPages(Index);
        }

        #region implementation interface IModelEx

        public IField[] Fields {
            get {
                return _fields.ToArray();
            }
        }
        #endregion
    }
}
