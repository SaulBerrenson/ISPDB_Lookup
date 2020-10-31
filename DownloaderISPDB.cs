using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using ISPDB_Lookup.interfaces;
using ISPDB_Lookup.Xml;

namespace ISPDB_Lookup
{
    /// <summary>
    /// Downloader all configs from ISP DB
    /// </summary>
    public class DownloaderISPDB : IUpdater
    {
        private string _link;
        private List<clientConfig> configs = null;
        private object _sync = new object();
        /// <summary>
        /// Set base link (url) where ISP DB
        /// </summary>
        /// <param name="link"></param>
        public void SetLink(string link)
        {
            _link = link;
        }

        /// <summary>
        /// Get All Configs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<clientConfig> GetDatabase()
        {
            return configs;
        }

        /// <summary>
        /// Prepare Dataflow and Download all configs
        /// </summary>
        /// <returns></returns>
        public async Task DownloadDatabase()
        {
            if (string.IsNullOrWhiteSpace(_link)) _link = Global.URL_ISPDB;
            await retrieveDatabase();
        }

        /// <summary>
        /// Retrieve all data via dataflow(TPL) with all core of processor
        /// </summary>
        /// <returns></returns>
        private async Task retrieveDatabase()
        {
            
            var executionOption = new ExecutionDataflowBlockOptions() {MaxDegreeOfParallelism = Environment.ProcessorCount, EnsureOrdered = false};
            //Download body database ISP DB
            var downloadHTML = new System.Threading.Tasks.Dataflow.TransformBlock<string, string>(s =>
            {
                using (DownloaderHtml downloader = new DownloaderHtml(Global.URL_ISPDB))
                {
                    return downloader.Get().Result;
                   // return Regex.Matches(htmlDocument, "alt=\"\\[TXT\\]\"></td><td><a href=\"(.*)\">(.*)</a>");
                }
            }, executionOption);
            //Find links for parsing from DB
            var findLinks = new TransformManyBlock<string, string>(htmlDocument =>
            {
                var urls = new List<string>();
                foreach (Match math in Regex.Matches(htmlDocument, "alt=\"\\[TXT\\]\"></td><td><a href=\"(.*)\">(.*)</a>"))
                {
                    urls.Add(string.Concat(Global.URL_ISPDB, math.Groups[2].Value));
                }
                configs = new List<clientConfig>();
                return urls;
            },executionOption);

            //Parsing configs from DB link by link
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

            //Link all blocks
            downloadHTML.LinkTo(findLinks, linkOptions);
            findLinks.LinkTo(downloadClientConfig, linkOptions);

            //Post base URL for ISP DB
            downloadHTML.Post(_link);
            //Wait completion dataflow...
            await downloadHTML.Completion;
        }




       
    }
}