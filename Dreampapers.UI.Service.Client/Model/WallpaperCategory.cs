using System.Xml.Serialization;

namespace Dreampapers.UI.Service.Client.Model
{
    public class WallpaperCategory
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}
