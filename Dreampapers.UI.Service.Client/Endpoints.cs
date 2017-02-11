namespace Dreampapers.UI.Service.Client
{
    public static class Endpoints
    {
        //IE 11 -> Mozilla/5.0 (Windows NT 6.3; Trident/7.0; rv:11.0) like Gecko
        public const string USER_AGENT = "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36";

        public const string DOWNLOAD = "http://wallpaperswide.com/download/{0}-{1}.jpg"; //0-name, 1- resolution
        public const string LATEST = "http://wallpaperswide.com/rss/{0}-app_wallpapers-r-latest-p-{1}"; //0-resolution, 1- page
        public const string TOP = "http://wallpaperswide.com/rss/{0}-app_wallpapers-r-top-p-{1}"; //0-resolution, 1- page
        public const string RANDOM = "http://wallpaperswide.com/rss/{0}-app_wallpapers-r-random-p-{1}"; //0-resolution, 1- page
        public const string CATEGORIES = "http://wallpaperswide.com/rss/{0}-app_wallpapers-r-categories"; //0-resolution
        public const string CATEGORY = "http://wallpaperswide.com/rss/{0}-app_wallpapers-r-category-{1}-p-{2}"; //0-resolution, 1-category, 2-page
        public const string MEMBER = "http://wallpaperswide.com/rss/{0}-app_wallpapers-r-favorites-{1}-p-{2}"; //0-resolution, 1-member, 2-page
    }
}
