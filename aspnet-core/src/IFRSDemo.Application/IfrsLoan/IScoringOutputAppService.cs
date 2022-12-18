using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.IfrsLoan;
using IFRSDemo.IfrsLoan.Dto;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IScoringOutputAppService : IApplicationService
    {
        ListResultDto<ScoringOutputListDto> GetScoringOutput(GetScoringOutputInput input);
        Task<PagedResultDto<ScoringOutputListDto>> GetScoringOutputB(GetScoringOutputInput input);
        Task CreateScoringOutput(CreateScoringOutputInput input);
        Task DeleteScoringOutput(EntityDto input);

        Task<GetScoringOutputForEditOutput> GetScoringOutputForEdit(GetScoringOutputForEditInput input);
        Task EditScoringOutput(EditScoringOutputInput input);
    }
}
