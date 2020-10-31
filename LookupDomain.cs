using System.Threading.Tasks;
using ISPDB_Lookup.interfaces;

namespace ISPDB_Lookup
{
    public class LookupDomain : ILookupDomain
    {
        public async void Find(string domain)
        {
            using (DownloaderHtml downloader = new DownloaderHtml(string.Concat("https://autoconfig.thunderbird.net/v1.1/",domain)))
            {
                string response = await downloader.Get();

            }
        }
    }
}