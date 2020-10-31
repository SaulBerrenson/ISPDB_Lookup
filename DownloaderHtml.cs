using System;
using System.Net;
using System.Threading.Tasks;

namespace ISPDB_Lookup
{
    internal class DownloaderHtml : IDisposable
    {
        public DownloaderHtml(string url)
        {
            _url = url;
        }

        private string _url;

        public async Task<string> Get()
        {
            string _out = string.Empty;

           
            using (WebClient httpClient = new WebClient())
            {
               await Task.Factory.StartNew(() =>
               {
                   try
                   {
                       _out = httpClient.DownloadString(new Uri(_url));
                   }
                   catch { }
               });
            }
            return _out;
        }

        public void Dispose()
        {
        }
    }
}