using Abp.Application.Services.Dto;
using System;
using Abp.Application.Services;
using System.Collections.Generic;
using IFRSDemo.IfrsLoan.Dto;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.IfrsLoan
{
   public interface IInputDataAppService : IApplicationService
    {
        Task<List<string>> GetInputDataList();
        Task CreateInputData(CreateInputDataInput input);
        Task<PagedResultDto<InputDataListDto>> GetInputData(GetInputDataInput input);
        
        Task DeleteInputData(EntityDto input);

    }
}
