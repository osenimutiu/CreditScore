using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.ManualUpload.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.ManualUpload
{
    public interface ITbl_ScoringDataAppService : IApplicationService
    {
        Task<PagedResultDto<Tbl_ScoringDataDto>> GetInputData(GetInputDataInput input);
        List<Tbl_ScoringDataDto> GetInputDataForCount();
    }
}
