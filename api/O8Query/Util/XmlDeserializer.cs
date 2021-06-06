using System.IO;
using System.Xml.Serialization;

namespace O8Query.Util
{
    internal class XmlDeserializer<T>
    {
        internal static T Convert(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringReader reader4Serializer = new StringReader(xml);
            T obj = (T)serializer.Deserialize(reader4Serializer);
            reader4Serializer.Close();

            return obj;
        }
    }
}