using System.Threading.Tasks;
using Dreampapers.Service.Client.Model;

namespace Dreampapers.Service.Client
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
