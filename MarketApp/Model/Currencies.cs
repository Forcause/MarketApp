using System.Xml.Serialization;

namespace MarketApp.Model
{
    [XmlRoot(ElementName="currencies")]
    public class Currencies {
        [XmlElement(ElementName="currency")]
        public Currency Currency { get; set; }
    }
}