using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Dreampapers.Service.Client.Helpers
{
    public static class XmlHelper
    {
        public static XDocument RemoveNamespace(XDocument _xDoc)
        {
            foreach (XElement e in _xDoc.Root.DescendantsAndSelf())
            {
                if (e.Name.Namespace != XNamespace.None)
                {
                    e.Name = XNamespace.None.GetName(e.Name.LocalName);
                }

                if (e.Attributes().Where(a => a.IsNamespaceDeclaration || a.Name.Namespace != XNamespace.None).Any())
                {
                    e.ReplaceAttributes(e.Attributes().Select(a => a.IsNamespaceDeclaration ? null : a.Name.Namespace != XNamespace.None ? new XAttribute(XNamespace.None.GetName(a.Name.LocalName), a.Value) : a));
                }
            }

            return _xDoc;
        }

        public static T ParseXML<T>(string content)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XDocument document = XmlHelper.RemoveNamespace(XDocument.Parse(content));

            T result;
            using (XmlReader reader = document.CreateReader())
            {
                result = (T)serializer.Deserialize(reader);
            }

            return result;
        }

        // Serialize to xml
        public static string ToXml<T>(T value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                serializer.Serialize(xmlWriter, value);
            }
            return stringBuilder.ToString();
        }

        // Deserialize from xml
        public static T FromXml<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T value;
            using (StringReader stringReader = new StringReader(xml))
            {
                object deserialized = serializer.Deserialize(stringReader);
                value = (T)deserialized;
            }

            return value;
        }
    }
}
