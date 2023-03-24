using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Core.Interfaces
{
    public interface IWebService
    {
        Task<string> GetResponseResult(Encoding? encoding = null);
    }
}