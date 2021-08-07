using Models;

namespace WebScraper.Interfaces
{
    public interface IWebScraperFactory
    {
        IWebScraper CreateScraper(string resultType);
    }
}
