using System.Xml.Serialization;

namespace Dreampapers.UI.Service.Client.Model
{
    public class WallpaperThumb
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string SiteLink { get; set; }

        [XmlElement("thumb")]
        public string ThumbLink { get; set; }

        public string Thumb2Link
        {
            get
            {
                return this.ThumbLink.Replace("-t1", "-t2");
            }
        }

        [XmlElement("wallpaper")]
        public string WallpaperLink { get; set; }
    }
}
