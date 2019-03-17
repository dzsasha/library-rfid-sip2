using IS.Interface.RFID;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IS.Interface;
using System.IO;
using System.ServiceModel.Configuration;

namespace IS.RFID.Service.Test {
    [Guid("E138F5BC-3924-4D58-AC06-26D1F19F7E3E")]
    [ComVisible(true)]
    [ProgId("RFID.Test")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ReaderImpl : IReader, IConfig, IDisposable {
        public ReaderImpl() {
            fields.Add(new FieldImpl() { Description = "Идентификатор", Name = "id", Type = TypeField.String });
            fields.Add(new FieldImpl() { Description = "Противокражный бит", Name = "eas", Type = TypeField.Boolean });
            fields.Add(new FieldImpl() { Description = "PrimaryItemId", Name = "PrimaryItemId", Type = TypeField.String });
            fields.Add(new FieldImpl() { Description = "Страна", Name = "CountryLibrary", Type = TypeField.String, Value = "RU"});
            fields.Add(new FieldImpl() { Description = "ISIL", Name = "ISIL", Type = TypeField.String, Value = "00000000000" });
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ExtensionsSection extensions = configuration.GetSection("system.serviceModel/extensions") as ExtensionsSection;
            ExtensionElement extension = new ExtensionElement("JsonBehaviorExtensionElement");
            JsonBehaviorExtensionElement test = new JsonBehaviorExtensionElement();
            extension.Type = test.GetType().AssemblyQualifiedName;
            extensions?.BehaviorExtensions.Add(extension);
            BehaviorsSection behaviors = configuration.GetSection("system.serviceModel/behaviors") as BehaviorsSection;
            EndpointBehaviorElement element = new EndpointBehaviorElement("testMarcCloud");
            element.Add(test);
            if (element.CanAdd(new JsonBehaviorExtensionElement()))
                behaviors?.EndpointBehaviors.Add(element);
        }
        private List<IField> fields = new List<IField>();

        #region IReader
        public IItem[] Items {
            get {
                List<IItem> result = new List<IItem>();
                foreach (IField field in fields) {
                    if (field.Name.Equals("id")) {
                        result.Add(new ItemExImpl(this, field.Value.ToString()));
                    }
                }
                return result.ToArray();
            }
        }

        public string ProgId => "RFID.Test";

        public IField[] Fields => fields.ToArray();
        public void BeforeWrite(Configuration configuration) {}

        public event EventHandler OnChange;
        public event ErrorEventHandler OnError;

        public void CloseReader() {
        }

        public bool InitReader(IField[] param) {
            foreach (IField field in param) {
                foreach (IField sourceField in fields) {
                    if (sourceField.Name.Equals(field.Name)) {
                        sourceField.Value = field.Value;
                    }
                }
            }
            return true;
        }
        #endregion

        #region IDisposable
        public void Dispose() {
        }
        #endregion
    }
}
