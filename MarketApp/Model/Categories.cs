using System.Collections.Generic;
using System.Xml.Serialization;

namespace MarketApp.Model
{
    [XmlRoot(ElementName="categories")]
    public class Categories {
        [XmlElement(ElementName="category")]
        public List<Category> Category { get; set; }
    }
}