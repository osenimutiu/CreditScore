using System.Threading.Tasks;
using Abp.Application.Services;
using IFRSDemo.Editions.Dto;
using IFRSDemo.MultiTenancy.Dto;

namespace IFRSDemo.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}