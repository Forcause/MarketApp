using Android.Media.Audiofx;
using Android.Renderscripts;
using MarketApp.Interfaces;
using MarketApp.Model;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Services
{
    public class YmlCatalogOfferSource : IOfferSource
    {
        private readonly WebService _webService;

        public YmlCatalogOfferSource(string uri)
        {
            _webService = new WebService(uri);
        }

        public async Task<IReadOnlyList<Offer>> GetOffers()
        {
            var ymlCatalogues = await _webService.GetRequestEncodedAsync(Encoding.GetEncoding("windows-1251"));
            return ymlCatalogues.Shop.Offers.Offer;
        }
    }
}