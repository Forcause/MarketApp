using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MarketApp.Core.Interfaces
{
    internal interface IXmlParserService
    {
        List<XmlElement> ParseDataToElements(string rawData);
    }
}
