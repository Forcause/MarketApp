using MarketApp.Core.Interfaces;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System;

namespace MarketApp.Core.Services
{
    public class XmlParserService : IXmlParserService
    {
        public List<XmlElement> ParseDataToElements(string rawData)
        {
            var offersList = new List<XmlElement>();
            var xDoc = new XmlDocument();
            xDoc.LoadXml(rawData);
            offersList.AddRange((from XmlElement offer in xDoc.SelectNodes("//offer") select offer).ToList());
            return offersList;
        }
    }
}
