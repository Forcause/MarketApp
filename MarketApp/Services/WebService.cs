using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MarketApp.Services
{
    internal class WebService
    {
        private readonly string _uri;
        private readonly HttpClient _client;

        public WebService()
        {
            _uri = "https://yastatic.net/market-export/_/partner/help/YML.xml";
            _client = new HttpClient();
        }

        public async Task<List<XmlElement>> GetOfferAsync()
        {
            using var response = await _client.GetAsync(_uri);
            var content = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(content, Encoding.GetEncoding("windows-1251"));
            var res = await reader.ReadToEndAsync();
            var xDoc = new XmlDocument();
            xDoc.LoadXml(res);
            var offersList = (from XmlElement offer in xDoc.SelectNodes("//offer") select offer).ToList();
            return offersList;
        }
    }
}