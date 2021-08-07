using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using WebScraperManager.Interfaces;

namespace WebScraperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebScraperController : ControllerBase
    {
        IWebScrapingConductor _webScrapingConductor;

        public WebScraperController(IWebScrapingConductor webScrapingConductor)
        {
            _webScrapingConductor = webScrapingConductor;
        }

        /// <summary>
        /// return result of downloading the source given by the urls
        /// according to the return type mentioned in the parameter
        /// </summary>
        /// <param name="urls"></param>
        /// <param name="returnType"></param>
        /// <returns></returns>
        [HttpGet]
        //("{content}")
        public async Task<ActionResult> Get([FromQuery] ScrapingContext context)
        {
            return await _webScrapingConductor.ScrapeWebsite(context) ;
        }


    }
}
