using IS.Interface;
using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.RFID.Bibliotheca
{
    public class DanishTypeImpl : TypeModelImpl<DanishModelImpl>, ITypeModel
    {
        public DanishTypeImpl(int iIndex, string id, IEnumerable<IField> param) : base(TypeModel.Danish, id)
        {
            _param = param;
            _Index = iIndex;
            if (External.BibGetDataModelID(_Index) > 0)
            {
                string sUid = "";
                External.BibGetItemID(_Index, ref sUid);
                if (!String.IsNullOrEmpty(sUid))
                {
                    string sLibrary = "", sCountry = "", sType = "";
                    External.BibGetLibraryInstitutionID(_Index, ref sLibrary);
                    External.BibGetLibraryCountryID(_Index, ref sCountry);
                    External.BibGetItemType(_Index, ref sType);
                    Add(new DanishModelImpl() { Id = sUid, Library = sLibrary, Country = sCountry, Index = _Index});
                }
            }
        }
        private readonly IEnumerable<IField> _param = null;
        private readonly int _Index;

        public override void Add(IModel item)
        {
            base.Add(item);
            if ((item is DanishModelImpl) && !(item as DanishModelImpl).IsInited)
            {
                (item as DanishModelImpl).Write();
            }
        }

        public new IModel Default
        {
            get { return DanishModelImpl.Default(_Index, _id, _param); }
        }
    }
}
