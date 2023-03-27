using MarketApp.Model;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Interfaces
{
    public interface IWebService
    {
        Task<YmlCatalog> GetRequestEncodedAsync(Encoding encoding = null);
    }
}