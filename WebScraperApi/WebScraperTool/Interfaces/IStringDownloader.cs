using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebScraperTool.Interfaces
{
    public interface IStringDownloader
    {
        Task<Dictionary<string,string>> DownloadValues(List<string> url);

        Task<string> DownloadValue(string url);

    }
}
