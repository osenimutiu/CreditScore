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
   public interface IScoringInputDataAppService : IApplicationService
    {
       
        Task<PagedResultDto<ScoringInputDataListDto>> GetScoringInputData(GetScoringInputDataInput input);
        Task DeleteScoringInputData(EntityDto input);
        Task<GetScoringInputDataForEditOutput> GetScoringInputDataForEdit(GetScoringInputDataForEditInput input);
        Task EditScoringInputData(EditScoringInputDataInput input);
        void ComputeWholeScore();

        Task<PostResultDto> CreateScoringInputData(List<CreateScoringInputDataDto> input);
    }
}
