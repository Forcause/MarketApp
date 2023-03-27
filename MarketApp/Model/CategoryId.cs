using System.Xml.Serialization;

namespace MarketApp.Model
{
    [XmlRoot(ElementName="categoryId")]
    public class CategoryId {
        [XmlAttribute(AttributeName="type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}