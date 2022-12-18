using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Authorization;
using IFRSDemo.Authorization;


namespace IFRSDemo.IfrsLoan
{
    //[AbpAuthorize(AppPermissions.Pages_Tenant_RentAttribute)]
    public class RentAttributeAppService : IFRSDemoAppServiceBase, IRentAttributeAppService
    {
        private readonly IRepository<RentAttribute> _rentAttributeRepository;
        public RentAttributeAppService(IRepository<RentAttribute> rentAttributeRepository)
        {
            _rentAttributeRepository = rentAttributeRepository;
        }

        public ListResultDto<RentAttributeListDto> GetRentAttribute(GetRentAttributeInput input)
        {
            var rentAttributes = _rentAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.RentGroup.Contains(input.Filter) ||
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
               .OrderBy(p => p.RentGroup)
               .ThenBy(p => p.NumberOfLoans)
               .ToList();

            return new ListResultDto<RentAttributeListDto>(ObjectMapper.Map<List<RentAttributeListDto>>(rentAttributes));

        }
    }
}
