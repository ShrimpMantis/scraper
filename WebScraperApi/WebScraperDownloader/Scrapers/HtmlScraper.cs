using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebScraper.Interfaces;

namespace WebScraperRetriever.Scrapers
{
    public interface IHtmlStringScraper : IWebScraper
    {

    }
    public class HtmlScraper : IHtmlStringScraper
    {
        public Task<ActionResult> Scraper(ScrapingContext param)
        {
            throw new System.NotImplementedException();
        }
    }
}
