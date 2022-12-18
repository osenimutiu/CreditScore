using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.SetUp.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.SetUp
{
    public interface ISetUpItemAppService : IApplicationService
    {
        Task CreateSetUp(CreateSetUpItemDto input);
        ListResultDto<MethodListDto> GetSetUp();
        ListResultDto<SetUpItemListDto> GetSetUpList();
		ListResultDto<SplittingMethodListDto> GetSplittingMethod();
        Task<GetSetUpItemForEditOutput> GetSetUpItemEdit(GetSetUpItemForEditInput input);
        Task EditSetUpItem(EditSetUpItemInput input);
    }
}
