using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dreampapers.UI.Service.Client.Model
{
    [XmlRoot("categories")]
    public class WallpaperCategoryCollection
    {
        public WallpaperCategoryCollection()
        {
            Categories = new List<WallpaperCategory>();
        }

        [XmlElement("category")]
        public List<WallpaperCategory> Categories { get; set; }
    }
}
