using MarketApp.Core.Interfaces;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Core.Services
{
    public class WebService : IWebService
    {
        private readonly HttpClient _client;
        private readonly string _url;

        public WebService(string url)
        {
            _client = new HttpClient();
            _url = url;
        }

        public async Task<string> GetResponseResult(Encoding? encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            using var response = await _client.GetAsync(_url);
            var content = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(content, encoding);
            return await reader.ReadToEndAsync();
        }
    }
}