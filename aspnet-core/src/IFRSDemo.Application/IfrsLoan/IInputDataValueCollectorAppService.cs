using Abp.Application.Services;
using IFRSDemo.IfrsLoan.Dto;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IFRSDemo.IfrsLoan
{
   public interface IInputDataValueCollectorAppService : IApplicationService
    {
        Task CreateInputDataValueCollector(CreateInputDataValueCollectorInput input);
        public void CreateSelectedAttributes(string param1, int param2);
        Task<PagedResultDto<InputDataValueCollectorListDto>> GetInputDataValueCollectorInput(GetInputDataValueCollectorInput input);
        Task DeleteSelectedAttributes(EntityDto input);
        CollectAttributeDto[] GetCollectAttribute();
        void FillCreditExclusion();
    }
}
