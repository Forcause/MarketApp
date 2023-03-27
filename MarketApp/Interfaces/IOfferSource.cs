using MarketApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketApp.Interfaces
{
    public interface IOfferSource
    {
        Task<IReadOnlyList<Offer>> GetOffers();
    }
}