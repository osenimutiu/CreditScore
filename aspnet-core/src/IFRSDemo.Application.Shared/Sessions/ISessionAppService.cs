using System.Threading.Tasks;
using Abp.Application.Services;
using IFRSDemo.Sessions.Dto;

namespace IFRSDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
