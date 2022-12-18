using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Linq;
using Abp.Linq.Extensions;
using Abp.Authorization;
using IFRSDemo.Authorization;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
    //[AbpAuthorize(AppPermissions.Pages_Tenant_CreditPreprocessing)]
    public class CreditPreprocessingAppService : IFRSDemoAppServiceBase, ICreditPreprocessingAppService
    {
        private readonly IRepository<CreditPreprocessing> _creditPreprocessingRepository;
        public CreditPreprocessingAppService(IRepository<CreditPreprocessing> creditPreprocessingRepository)
        {
            _creditPreprocessingRepository = creditPreprocessingRepository;
        }

        public ListResultDto<CreditPreprocessingListDto> GetCreditPreprocessing(GetCreditPreprocessingInput input)
        {
            var creditPreprocessings = _creditPreprocessingRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Name.Contains(input.Filter) ||
                   p.NumNull.ToString().Contains(input.Filter) ||
                   p.OutlIer.ToString().Contains(input.Filter) ||
                   p.Components.Contains(input.Filter) ||
                   p.Num.ToString().Contains(input.Filter) ||
                   p.Combination.ToString().Contains(input.Filter)
               )
               .OrderBy(p => p.Name)
               .ThenBy(p => p.Components)
               .ToList();

            return new ListResultDto<CreditPreprocessingListDto>(ObjectMapper.Map<List<CreditPreprocessingListDto>>(creditPreprocessings));

        }
    }
}
