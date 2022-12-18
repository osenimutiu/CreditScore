using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization.Permissions.Dto;

namespace IFRSDemo.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
