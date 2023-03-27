using MarketApp.Model;
using MarketApp.Interfaces;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Xml.Serialization;

namespace MarketApp.Services
{
    public class WebService : IWebService
    {
        private readonly string _url;
        private readonly HttpClient _client;

        public WebService(string url)
        {
            _url = url;
            _client = new HttpClient();
        }

        public async Task<YmlCatalog> GetRequestEncodedAsync(Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            using var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(content, encoding);
            var result = await reader.ReadToEndAsync();

            var serializer = new XmlSerializer(typeof(YmlCatalog));
            using var stringToSerialize = new StringReader(result);
            var ymlCatalog = (YmlCatalog)serializer.Deserialize(stringToSerialize);

            return ymlCatalog;
        }
    }
}