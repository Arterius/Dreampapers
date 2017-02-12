using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dreampapers.Service.Client.Model
{
    [XmlRoot("rss")]
    public sealed class WallpaperThumbCollection
    {
        [XmlElement("page")]
        public int CurrentPage { get; set; }

        [XmlElement("pages")]
        public int TotalPages { get; set; }

        [XmlElement("wallpapers")]
        public int TotalWallpapers { get; set; }

        [XmlArray("channel")]
        [XmlArrayItem("item")]
        public List<WallpaperThumb> WallpaperThumbs { get; set; }
    }
}
