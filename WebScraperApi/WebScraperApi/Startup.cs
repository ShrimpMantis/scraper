using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using WebScraper;
using WebScraper.Interfaces;
using WebScraperManager;
using WebScraperManager.Interfaces;
using WebScraperRetriever.Scrapers;
using WebScraperTool;
using WebScraperTool.Interfaces;

namespace WebScraperApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options=> 
            {
                options.AddPolicy("AllowAllOriginPolicy",
                    builder=> 
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            services.AddScoped<IStringDownloader, Downloader>();
            services.AddScoped<WebStringScraper>();
            services.AddScoped<HtmlScraper>();
            services.AddScoped<IWebStringScraper, WebStringScraper>(s => s.GetService<WebStringScraper>());
            services.AddScoped<IHtmlStringScraper, HtmlScraper>(s => s.GetService<HtmlScraper>());
            services.AddScoped<IWebScraperFactory, WebScraperFactory>();
            services.AddScoped<IWebScrapingConductor, WebScrapingConductor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAllOriginPolicy");
            app.UseMvc();
        }
    }
}
