using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebScraper.Interfaces;
using Moq;
using WebScraperManager.Interfaces;
using Models;
using System.Threading.Tasks;
using WebScraperManager;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebScraperManagerUnitTest
{
    [TestClass]
    public class WebScrapingConductorUnitTest
    {
        Mock<IWebScraperFactory> _mockWebScraperFactory;
        IWebScrapingConductor _webScrapingConductor;
        private readonly string returnType = "string";
        Mock<IWebScraper> _mockScraper;

        [TestInitialize]
        public void Initialize()
        {
            _mockWebScraperFactory = new Mock<IWebScraperFactory>();
            _mockScraper = new Mock<IWebScraper>();
            _mockScraper.Setup(x=> x.Scraper(It.IsAny<ScrapingContext>()))
                        .Returns(Task.FromResult<ActionResult>(new OkObjectResult("result string")));
            _mockWebScraperFactory.Setup(x=>x.CreateScraper(It.Is<string>(y=>y.Equals(returnType))))
                                  .Returns(_mockScraper.Object);
            _webScrapingConductor = new WebScrapingConductor(_mockWebScraperFactory.Object);
        }

        [TestMethod]
        public async Task Verify_Website_Is_Downloaded()
        {
            var context = new ScrapingContext();
            context.ReturnType = "string";
            context.Urls =new List<string>() { "https://www.google.com", "https://www.desitricoaching.com" };

            var result= await _webScrapingConductor.ScrapeWebsite(context) as OkObjectResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.Value.Equals("result string"));
        }
    }
}
