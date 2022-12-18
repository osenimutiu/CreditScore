using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Abp.Authorization;
using IFRSDemo.Authorization;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_RenttoIncomeAttribute)]
    public class RenttoIncomeAttributeAppService : IFRSDemoAppServiceBase, IRenttoIncomeAttributeAppService
    {
        private readonly IRepository<RenttoIncomeAttribute> _renttoIncomeAttributeRepository;
        public RenttoIncomeAttributeAppService(IRepository<RenttoIncomeAttribute> renttoIncomeAttributeRepository, IRepository<Component, int> componentRepository)
        {
            _renttoIncomeAttributeRepository = renttoIncomeAttributeRepository;
        }

        public ListResultDto<RenttoIncomeAttributeListDto> GetRenttoIncomeAttribute(GetRenttoIncomeAttributeInput input)
        {
            var renttoIncomeAttributes = _renttoIncomeAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.RentToIncomeGroup.Contains(input.Filter) ||
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
               .OrderBy(p => p.RentToIncomeGroup)
               .ThenBy(p => p.NumberOfLoans)
               .ToList();

            return new ListResultDto<RenttoIncomeAttributeListDto>(ObjectMapper.Map<List<RenttoIncomeAttributeListDto>>(renttoIncomeAttributes));

        }
    }
}
