using System.Collections.Generic;
using System.Xml.Serialization;

namespace MarketApp.Model
{
    [XmlRoot(ElementName="offers")]
    public class Offers {
        [XmlElement(ElementName="offer")]
        public List<Offer> Offer { get; set; }
    }
}