using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ISPDB_Lookup.interfaces;
using ISPDB_Lookup.Xml;

namespace ISPDB_Lookup
{
    /// <summary>
    /// Lookup domain (example: bk.ru or gmail.com)
    /// </summary>
    public class LookupDomain : ILookupDomain
    {
        /// <summary>
        /// Find config for specified domain
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public async Task<clientConfig> Find(string domain)
        {
            using (DownloaderHtml downloader = new DownloaderHtml(string.Concat(Global.URL_ISPDB,domain)))
            {
                string response = await downloader.Get();
                return ClientConfigDeserializer.Deserialize(response);
            }
        }
    }
}