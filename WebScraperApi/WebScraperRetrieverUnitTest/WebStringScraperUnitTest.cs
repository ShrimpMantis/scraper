using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebScraper;
using WebScraperTool.Interfaces;

namespace WebScraperRetrieverUnitTest
{
    [TestClass]
    public class WebStringScraperUnitTest
    {
        Mock<IStringDownloader> _mockStringDownloader;
        IWebStringScraper _webStringScraper;

        [TestInitialize]
        public void Initialize()
        {
            _mockStringDownloader = new Mock<IStringDownloader>();
            _mockStringDownloader.Setup(x => x.DownloadValues(
                                            It.Is<List<string>>(y=>y.Contains("google.com") 
                                            && y.Contains("facebook.com")
                                    )))
                                    .Returns(Task.FromResult(
                                    new Dictionary<string, string>()
                                    {
                                        {"google.com","result of google" },
                                        {"facebook.com","result of facebook" }
                                    }));

            _webStringScraper = new WebStringScraper(_mockStringDownloader.Object);

        }

        [TestMethod]
        public async Task Verify_Scraper_Returns_OkObjectResult()
        {
            var context = new ScrapingContext()
            {
                ReturnType="string",
                Urls= new List<string>()
                {
                    "google.com","facebook.com"
                }
            };
            
            var result = await _webStringScraper.Scraper(context) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            var dictionaryResult = result.Value as Dictionary<string, string>;
            Assert.IsTrue(dictionaryResult.Count.Equals(2));
            Assert.IsTrue(dictionaryResult.ContainsValue("result of google"));
            Assert.IsTrue(dictionaryResult.ContainsValue("result of facebook"));
        }

        [TestMethod]
        public async Task Verify_Scraper_Throws_Exception_When_There_Is_Empty_Url()
        {
            var context = new ScrapingContext()
            {
                ReturnType = "string",
                Urls = new List<string>()
                {
                    "",""
                }
            };

            try
            {
                var result = await _webStringScraper.Scraper(context) as OkObjectResult;
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Equals("url is null or empty\r\nParameter name: urls"));
            }
            
        }


    }
}
