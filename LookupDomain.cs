using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ISPDB_Lookup.interfaces;
using ISPDB_Lookup.Xml;

namespace ISPDB_Lookup
{
    public class LookupDomain : ILookupDomain
    {
        public clientConfig Find(string domain)
        {
            using (DownloaderHtml downloader = new DownloaderHtml(string.Concat(Global.URL_ISPDB,domain)))
            {
                string response =  downloader.Get().Result;
                return ClientConfigDeserializer.Deserialize(response);
            }
        }
    }
}