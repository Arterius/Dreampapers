using System;
using Windows.Foundation;
using Windows.Web.Http;
using Windows.Web.Http.Headers;

namespace Dreampapers.UI.Service.Client
{
    public interface IHttpClient
    {
        HttpRequestHeaderCollection DefaultRequestHeaders { get; }
        IAsyncOperationWithProgress<string, HttpProgress> GetStringAsync(Uri uri);
    }
}
