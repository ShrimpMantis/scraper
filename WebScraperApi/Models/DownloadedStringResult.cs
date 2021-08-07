using System.Collections.Generic;
using Models.Interfaces;

namespace Models
{
    public class DownloadedStringResult<T> : IDownloadedResponse<T>
    {
        public T DownloadedResponse
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }
    }
}
