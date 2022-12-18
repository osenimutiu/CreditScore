using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.SMELending.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.SMELending
{
   public interface ISMELendingApplyAppService : IApplicationService
    {
       
        Task<PagedResultDto<SMELendingApplyListDto>> GetSMELendingApply(GetSMELendingApplyInput input);
        Task CreateSMELendingApply(CreateSMELendingApplyInput input);
        Task<SMELendingApplyListDto> GetSMELendingApplyForView(int id);
        Task DeleteSMELendingApply(EntityDto input);
    }
}
