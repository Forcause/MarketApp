using System.Xml.Serialization;

namespace MarketApp.Model
{
    [XmlRoot(ElementName="currency")]
    public class Currency {
        [XmlAttribute(AttributeName="id")]
        public string Id { get; set; }
        [XmlAttribute(AttributeName="rate")]
        public string Rate { get; set; }
        [XmlAttribute(AttributeName="plus")]
        public string Plus { get; set; }
    }
}