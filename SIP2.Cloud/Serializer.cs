using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace IS.SIP2.Cloud {
    public class Serializer {
        public static string SerializeObject(object obj, Type type) {
            var setting = new XmlWriterSettings() { OmitXmlDeclaration = true, Indent = true };
            var xml = new StringBuilder();
            using (var writer = XmlWriter.Create(xml, setting)) {
                var nsSerializer = new XmlSerializerNamespaces();
                nsSerializer.Add(string.Empty, string.Empty);

                var xmlSerializer = new XmlSerializer(type);
                xmlSerializer.Serialize(writer, obj, nsSerializer);
            }
            return xml.ToString();
        }

        public static object DeserializeObject(string xml, Type type) {
            var xs = new XmlSerializer(type);
            var stringReader = new StringReader(xml);
            var obj = xs.Deserialize(stringReader);
            stringReader.Close();
            return obj;
        }
    }
}
