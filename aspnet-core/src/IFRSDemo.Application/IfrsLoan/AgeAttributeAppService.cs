using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Linq;
using System;
using System.Collections.Generic;
using Abp.Linq.Extensions;
using Abp.Authorization;
using IFRSDemo.Authorization;
using System.Text;
using IFRSDemo.IfrsLoan.Dto;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_AgeAttribute)]
    public class AgeAttributeAppService : IFRSDemoAppServiceBase, IAgeAttributeAppService
    {
        private readonly IRepository<AgeAttribute> _ageAttributeRepository;
        public AgeAttributeAppService(IRepository<AgeAttribute> ageAttributeRepository)
        {
            _ageAttributeRepository = ageAttributeRepository;
        }

        public ListResultDto<AgeAttributeListDto> GetAgeAttribute(GetAgeAttributeInput input)
        {
            var ageAttributes = _ageAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.AgeGroup.Contains(input.Filter) ||
                        p.NumberOfLoans.ToString().Contains(input.Filter) ||
                        p.NumberOfBadLoans.ToString().Contains(input.Filter) ||
                        p.NumberOfGoodLoans.ToString().Contains(input.Filter) ||
                        p.BadLoanPerc.ToString().Contains(input.Filter) ||
                        p.BinGroup.Contains(input.Filter) ||
                        p.DB.ToString().Contains(input.Filter) ||
                        p.DG.ToString().Contains(input.Filter) ||
                        p.WOE.ToString().Contains(input.Filter) ||
                        p.DG_DB.ToString().Contains(input.Filter) || 
                        p.WoeDGBG.ToString().Contains(input.Filter) ||
                        p.ScoreAfterReg.ToString().Contains(input.Filter) ||
                        p.ScorePoint.ToString().Contains(input.Filter) 

               )
               .OrderBy(p => p.AgeGroup)
               .ThenBy(p => p.NumberOfLoans)
               .ToList();

            return new ListResultDto<AgeAttributeListDto>(ObjectMapper.Map<List<AgeAttributeListDto>>(ageAttributes));

        }

    }
}
