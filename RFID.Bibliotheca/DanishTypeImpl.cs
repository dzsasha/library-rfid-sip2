using IS.Interface;
using IS.Interface.RFID;
using System.Collections.Generic;

namespace IS.RFID.Bibliotheca {
    public class DanishTypeImpl : TypeModelImpl<DanishModelImpl>, ITypeModel {
        public DanishTypeImpl(int iIndex, string id, IEnumerable<IField> param) : base(TypeModel.Danish, id, false) {
            _param = param;
            _Index = iIndex;
            if (External.BibGetDataModelID(_Index) > 0) {
                Add(new DanishModelImpl(_Index, (Default as DanishModelImpl)));
            }
        }
        private readonly IEnumerable<IField> _param = null;
        private readonly int _Index;

        public override void Add(IModel item) {
            base.Add(item);
            if ((item is DanishModelImpl) && !(item as DanishModelImpl).IsInited) {
                (item as DanishModelImpl).Write();
            }
        }

        public new IModel Default {
            get { return DanishModelImpl.Default(_Index, _id, _param); }
        }
    }
}
