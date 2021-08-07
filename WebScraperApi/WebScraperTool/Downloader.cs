using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebScraperTool.Interfaces;

namespace WebScraperTool
{
    public class Downloader:IStringDownloader
    {
        public async Task<Dictionary<string, string>> DownloadValues(List<string> urls)
        {
            Dictionary<string, string> downloadedSiteStrings = new Dictionary<string, string>(urls.Select(x => new KeyValuePair<string, string>(x, string.Empty)));

            foreach (var url in urls)
            {
                var result = await DownloadValue(url);
                if (downloadedSiteStrings.ContainsKey(url))
                {
                    downloadedSiteStrings[url] = result;
                }
            }

            return downloadedSiteStrings;
        }

        public async Task<string> DownloadValue(string url)
        {
            using (WebClient client = new WebClient())
            {
                var downloadStringTaskResult = await client.DownloadStringTaskAsync(new Uri(url));
                return downloadStringTaskResult;
            }
        }

      
    }
}
