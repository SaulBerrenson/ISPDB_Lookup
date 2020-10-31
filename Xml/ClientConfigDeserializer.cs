using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ISPDB_Lookup.Xml
{
    internal static class ClientConfigDeserializer
    {
        public static clientConfig Deserialize(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(clientConfig));
            XmlReader xmlReader = XmlReader.Create(new StringReader(xml));
            var canDeserialize = serializer.CanDeserialize(xmlReader);
            return (serializer.Deserialize(xmlReader) as clientConfig);
        }
    }
}