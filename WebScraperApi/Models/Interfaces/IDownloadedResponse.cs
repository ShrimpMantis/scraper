using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IDownloadedResponse<T>
    {
        T DownloadedResponse { get; set; }
    }
}
