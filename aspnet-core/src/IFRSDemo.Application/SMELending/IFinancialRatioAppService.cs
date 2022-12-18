using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.SMELending.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.SMELending
{
   public interface IFinancialRatioAppService : IApplicationService
    {
        Task CreateFinancialRatio(CreateFinancialRatioInput input);
        Task DeleteFinancialRatio(EntityDto input);
        Task<PagedResultDto<FinancialRatioListDto>> GetFinancialRatio(GetFinancialRatioInput input);
        Task<GetFinancialRatioForEditOutput> GetFinancialRatioForEdit(GetFinancialRatioForEditInput input);
        Task EditFinancialRatio(EditFinancialRatioInput input);
    }
}
