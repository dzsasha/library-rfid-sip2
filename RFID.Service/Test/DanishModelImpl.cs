using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using IS.Interface.RFID;

namespace IS.RFID.Service.Test {
    public class DanishModelImpl : ModelImpl, IModelEx {
        public DanishModelImpl() : base(TypeModel.Danish) {
            _fields.Add(new FieldImpl() { Name = "PrimaryItemId", Type = TypeField.String });
            _fields.Add(new FieldImpl() { Name = "CountryLibrary", Type = TypeField.String });
            _fields.Add(new FieldImpl() { Name = "ISIL", Type = TypeField.String });
        }

        public DanishModelImpl(IConfig config, string id) : this() {
            this._config = config;
            this.Id = id;
            this.Type = TypeItem.Item;
            Read(id);
        }
        private readonly List<IField> _fields = new List<IField>();
        public IField[] Fields => _fields.ToArray();
        internal IField GetField(string name) {
            return _fields.FirstOrDefault(field => field.Name.Equals(name));
        }
        public new string Id {
            get { return GetField("PrimaryItemId").Value.ToString(); }
            set { GetField("PrimaryItemId").Value = value; }
        }
        public override void Write() {
        }

        public override ModelImpl[] Read(string id) {
            _fields.Clear();
            _fields.Add(_config.Fields.GetField("PrimaryItemId"));
            _fields.Add(_config.Fields.GetField("CountryLibrary"));
            _fields.Add(_config.Fields.GetField("ISIL"));
            return (new List<ModelImpl>() { this }).ToArray();
        }
        private IConfig _config { get; set; }
    }
}
