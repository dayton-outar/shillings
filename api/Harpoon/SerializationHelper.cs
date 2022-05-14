
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Harpoon
{
    public class SerializationHelper
    {
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                return Deserialize<T>(stream);
            }
        }

        public static T Deserialize<T>(Stream input)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                using (XmlTextReader reader = new XmlTextReader(input))
                {
                    T result = (T)serializer.Deserialize(reader);
                    return result;
                }
            }
            catch (XmlException)
            {
                // Ignore, return null.
            }
            return default(T);
        }

        public static string Serialize<T>(T item, Type[] IncludedTypes = null)
        {
            string result = string.Empty;

            if (null == IncludedTypes) IncludedTypes = new[] { typeof(object) };

            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = (XmlTextWriter.Create(sw,
                                            new XmlWriterSettings()
                                            {
                                                OmitXmlDeclaration = true,
                                                //Encoding = Encoding.UTF8,
                                                //Indent = true
                                            })))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty);
                    new XmlSerializer(typeof(T), IncludedTypes).Serialize(writer, item, ns);
                    result = sw.ToString();
                }
            }

            return result;
        }
    }
}