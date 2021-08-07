using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace WebScraper.Interfaces
{
    public interface IWebScraper
    {
        Task<ActionResult> Scraper(ScrapingContext param);
    }
}
