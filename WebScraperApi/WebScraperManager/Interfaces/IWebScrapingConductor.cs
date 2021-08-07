using Microsoft.AspNetCore.Mvc;
using Models;
using System.Threading.Tasks;

namespace WebScraperManager.Interfaces
{
    public interface IWebScrapingConductor
    {
        Task<ActionResult> ScrapeWebsite(ScrapingContext context);
    }
}
