using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dreampapers.UI.Service.Client.Helpers;
using Dreampapers.UI.Service.Client.Model;

namespace Dreampapers.UI.Service.Client
{
    public enum ServiceCommand
    {
        DownloadWallpaper,
        LatestWallpapers,
        TopWallpapers,
        RandomWallpapers,
        CategoryWallpapers,
        WallpaperCategories,
        MemberWallpapers
    }

    public class WallpaperServiceClient : IServiceClient
    {
        private Dictionary<ServiceCommand, string> _endpoints = new Dictionary<ServiceCommand, string>()
        {
            { ServiceCommand.DownloadWallpaper, Endpoints.DOWNLOAD},
            { ServiceCommand.LatestWallpapers, Endpoints.LATEST },
            { ServiceCommand.TopWallpapers, Endpoints.TOP },
            { ServiceCommand.RandomWallpapers, Endpoints.RANDOM },
            { ServiceCommand.CategoryWallpapers, Endpoints.CATEGORY },
            { ServiceCommand.MemberWallpapers, Endpoints.MEMBER },
            { ServiceCommand.WallpaperCategories, Endpoints.CATEGORIES },
        };

        private IHttpClient _httpClient;

        public WallpaperServiceClient(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WallpaperCategoryCollection> GetWallpaperCategoriesAsync(string resolution)
        {
            string requestUri = string.Format(_endpoints[ServiceCommand.WallpaperCategories], resolution);

            string result = await MakeRequest(new Uri(requestUri));
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }

            WallpaperCategoryCollection wallpaperCategoryCollection = null;
            try
            {
                wallpaperCategoryCollection = XmlHelper.ParseXML<WallpaperCategoryCollection>(result);
            }
            catch { }

            return wallpaperCategoryCollection;
        }

        public async Task<WallpaperThumbCollection> GetTopWallpapersThumbsAsync(string resolution, int page)
        {
            if (string.IsNullOrEmpty(resolution) || page <= 0)
            {
                return null;
            }

            string requestUri = string.Format(_endpoints[ServiceCommand.TopWallpapers], resolution, page);
            return await GetWallpapersThumbAsync(requestUri);
        }

        public async Task<WallpaperThumbCollection> GetLatestWallpapersThumbsAsync(string resolution, int page)
        {
            if (string.IsNullOrEmpty(resolution) || page <= 0)
            {
                return null;
            }

            string requestUri = string.Format(_endpoints[ServiceCommand.LatestWallpapers], resolution, page);
            return await GetWallpapersThumbAsync(requestUri);
        }

        public async Task<WallpaperThumbCollection> GetRandomWallpapersThumbsAsync(string resolution, int page)
        {
            if (string.IsNullOrEmpty(resolution) || page <= 0)
            {
                return null;
            }

            string requestUri = string.Format(_endpoints[ServiceCommand.RandomWallpapers], resolution, page);
            return await GetWallpapersThumbAsync(requestUri);
        }

        public async Task<WallpaperThumbCollection> GetMemberFavoriteWallpapersThumbsAsync(string resolution, string memberName, int page)
        {
            if (string.IsNullOrEmpty(resolution) || string.IsNullOrEmpty(memberName) || page <= 0)
            {
                return null;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(memberName);
            string memberNameBase64 = Convert.ToBase64String(bytes);

            string requestUri = string.Format(_endpoints[ServiceCommand.MemberWallpapers], resolution, memberNameBase64, page);
            return await GetWallpapersThumbAsync(requestUri);
        }

        public async Task<WallpaperThumbCollection> GetCategoryWallpapersThumbsAsync(string resolution, string category, int page)
        {
            if (string.IsNullOrEmpty(resolution) || string.IsNullOrEmpty(category) || page <= 0)
            {
                return null;
            }

            string requestUri = string.Format(_endpoints[ServiceCommand.CategoryWallpapers], resolution, category, page);
            return await GetWallpapersThumbAsync(requestUri);
        }

        private async Task<WallpaperThumbCollection> GetWallpapersThumbAsync(string requestUri)
        {
            string result = await MakeRequest(new Uri(requestUri));
            if (string.IsNullOrEmpty(result) || result.Contains("No wallpapers found"))
            {
                return null;
            }

            WallpaperThumbCollection wallpaperThumbCollection = null;
            try
            {
                wallpaperThumbCollection = XmlHelper.ParseXML<WallpaperThumbCollection>(result);
            }
            catch { }

            return wallpaperThumbCollection;
        }

        private async Task<string> MakeRequest(Uri requestUri, string referer = null)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", Endpoints.USER_AGENT);
                string response = await _httpClient.GetStringAsync(requestUri);

                return response;
            }
            catch
            {
                return null;
            }
        }
    }
}
