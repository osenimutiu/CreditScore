using System.Threading.Tasks;
using Abp.Application.Services;
using IFRSDemo.Configuration.Tenants.Dto;

namespace IFRSDemo.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
