using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Linq;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Authorization;
using IFRSDemo.Authorization;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_IncomeAttribute)]
    public class IncomeAttributeAppService : IFRSDemoAppServiceBase, IIncomeAttributeAppService
    {
        private readonly IRepository<IncomeAttribute> _incomeAttributeRepository;
        public IncomeAttributeAppService(IRepository<IncomeAttribute> incomeAttributeRepository)
        {
            _incomeAttributeRepository = incomeAttributeRepository;
        }

        public ListResultDto<IncomeAttributeListDto> GetIncomeAttribute(GetIncomeAttributeInput input)
        {
            var incomeAttributes = _incomeAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.IncomeRange.Contains(input.Filter)

               )
               //.OrderBy(p => p.featurename)
               //.ThenBy(p => p.lowerBound)
               .ToList();

            return new ListResultDto<IncomeAttributeListDto>(ObjectMapper.Map<List<IncomeAttributeListDto>>(incomeAttributes));

        }
    }
}
