using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using ISPDB_Lookup.interfaces;
using ISPDB_Lookup.Xml;

namespace ISPDB_Lookup
{
    public class DownloaderISPDB : IUpdater
    {
        private string _link;
        private List<clientConfig> configs = new List<clientConfig>();
        private object _sync = new object();
        public void SetLink(string link)
        {
            _link = link;
        }


        public List<clientConfig> GetDatabase()
        {
            return null;
        }

        public void DownloadDatabase()
        {
            if (string.IsNullOrWhiteSpace(_link)) _link = Global.URL_ISPDB;

           retrieveDatabase();
        }

        private void retrieveDatabase()
        {
            var executionOption = new ExecutionDataflowBlockOptions() {MaxDegreeOfParallelism = Environment.ProcessorCount, EnsureOrdered = false};

            var downloadHTML = new System.Threading.Tasks.Dataflow.TransformBlock<string, string>(s =>
            {
                using (DownloaderHtml downloader = new DownloaderHtml(Global.URL_ISPDB))
                {
                    return downloader.Get().Result;
                   // return Regex.Matches(htmlDocument, "alt=\"\\[TXT\\]\"></td><td><a href=\"(.*)\">(.*)</a>");
                }
            }, executionOption);
            var findLinks = new TransformManyBlock<string, string>(htmlDocument =>
            {
                var urls = new List<string>();
                foreach (Match math in Regex.Matches(htmlDocument, "alt=\"\\[TXT\\]\"></td><td><a href=\"(.*)\">(.*)</a>"))
                {
                    urls.Add(string.Concat(Global.URL_ISPDB, math.Groups[2].Value));
                }

                return urls;
            },executionOption);

            var downloadClientConfig = new ActionBlock<string>(url =>
            {
                using (DownloaderHtml downloader = new DownloaderHtml(url))
                {
                    string response = downloader.Get().Result;
                    var config = ClientConfigDeserializer.Deserialize(response);
                    if(config==null) return;
                    configs.Add(config);
                }
            }, executionOption);
            var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

            downloadHTML.LinkTo(findLinks, linkOptions);
            findLinks.LinkTo(downloadClientConfig, linkOptions);

            downloadHTML.Post(_link);
            downloadHTML.Completion.GetAwaiter().GetResult();
        }




       
    }
}