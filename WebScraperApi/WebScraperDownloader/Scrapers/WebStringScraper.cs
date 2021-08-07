using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraper.Interfaces;
using WebScraperTool.Interfaces;

namespace WebScraper
{
    public interface IWebStringScraper:IWebScraper
    {
    }
    public class WebStringScraper : IWebStringScraper
    { 
        private readonly IStringDownloader _stringDownloader;

        public WebStringScraper(IStringDownloader stringDownloader)
        {
            _stringDownloader = stringDownloader;
        }

        public async Task<ActionResult> Scraper(ScrapingContext context)
        {
            var givenContext = context as ScrapingContext;
            ValidateUrls(givenContext.Urls);
            var result = await _stringDownloader.DownloadValues(givenContext.Urls);
            if (result.Count == 0)
            {
                throw new Exception("result is null or empty");
            }

            return new OkObjectResult(result);
        }

        #region private methods
        private static void ValidateUrls(List<string> urls)
        {
            Predicate<string> emptyString = (string element) =>
            {
                element.Replace(" ", "");
                return element.Equals(string.Empty);
            };

            var test = urls.FindIndex(emptyString);

            if (urls.Count == 0 || urls.FindIndex(emptyString) >= 0)
            {
                throw new ArgumentNullException(nameof(urls), "url is null or empty");
            }
        }

        #endregion

    }


}
