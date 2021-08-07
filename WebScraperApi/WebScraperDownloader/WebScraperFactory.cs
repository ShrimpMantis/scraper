using WebScraper.Interfaces;
using WebScraperRetriever.Scrapers;

namespace WebScraper
{
    public class WebScraperFactory: IWebScraperFactory
    {
        IWebStringScraper _stringWebScraper;
        IHtmlStringScraper _htmlStringScraper;
        public WebScraperFactory(IWebStringScraper stringWebScraper,
                                 IHtmlStringScraper htmlStringScraper)
        {
            _stringWebScraper = stringWebScraper;
            _htmlStringScraper = htmlStringScraper;
        }
        public IWebScraper CreateScraper(string resultType)
        {
            switch (resultType)
            {
                case "string":
                    return _stringWebScraper;
                case "html":
                    return _htmlStringScraper;
                
                default:
                    throw new System.Exception("context is not supported");
            }
            
        }

    }
}
