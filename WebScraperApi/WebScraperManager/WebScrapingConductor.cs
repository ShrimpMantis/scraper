using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;
using WebScraper.Interfaces;
using WebScraperManager.Interfaces;

namespace WebScraperManager
{
    public class WebScrapingConductor:IWebScrapingConductor
    {
        private readonly IWebScraperFactory _webScraperFactory;
        public WebScrapingConductor(IWebScraperFactory webScraperFactory)
        {
            _webScraperFactory = webScraperFactory;
        }

        public async Task<ActionResult> ScrapeWebsite(ScrapingContext context)
        {
            var scraper = _webScraperFactory.CreateScraper(context.ReturnType);
            var result = await scraper.Scraper(context);
            return result;
        }

    }
}
