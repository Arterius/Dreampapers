using Dreampapers.UI.Service.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dreampapers.UI.Service.Client
{
    public interface IServiceClient
    {
        Task<WallpaperCategoryCollection> GetWallpaperCategoriesAsync(string resolution);
        Task<WallpaperThumbCollection> GetTopWallpapersThumbsAsync(string resolution, int page);
        Task<WallpaperThumbCollection> GetLatestWallpapersThumbsAsync(string resolution, int page);
        Task<WallpaperThumbCollection> GetRandomWallpapersThumbsAsync(string resolution, int page);
        Task<WallpaperThumbCollection> GetMemberFavoriteWallpapersThumbsAsync(string resolution, string memberName, int page);
        Task<WallpaperThumbCollection> GetCategoryWallpapersThumbsAsync(string resolution, string category, int page);
    }
}
