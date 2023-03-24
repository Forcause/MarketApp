using MarketApp.Core.Services;
using System.Text;

namespace MarketAppTest
{
    public class Tests
    {
        private WebService _webService;

        [SetUp]
        public void Setup()
        {
            _webService = new WebService("http://partner.market.yandex.ru/pages/help/YML.xml");
        }

        [Test]
        public async Task GetRequestTest()
        {
            var res = await _webService.GetResponseResult();
            if (res != null) Assert.Pass();
        }
    }
}