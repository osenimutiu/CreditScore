using System.Threading.Tasks;
using IFRSDemo.Sessions.Dto;

namespace IFRSDemo.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
