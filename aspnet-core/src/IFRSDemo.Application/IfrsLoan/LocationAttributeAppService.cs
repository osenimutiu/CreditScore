using System;
using System.Collections.Generic;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using System.Text;
using Abp.Authorization;
using IFRSDemo.Authorization;
using System.Linq;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_LocationAttribute)]
    public class LocationAttributeAppService : IFRSDemoAppServiceBase, ILocationAttributeAppService
    {
        private readonly IRepository<LocationAttribute> _locationAttributeRepository;
        public LocationAttributeAppService(IRepository<LocationAttribute> locationAttributeRepository)
        {
            _locationAttributeRepository = locationAttributeRepository;
        }

        public ListResultDto<LocationAttributeListDto> GetLocationAttribute(GetLocationAttributeInput input)
        {
            var locationAttributes = _locationAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.LocationGroup.Contains(input.Filter) ||
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
               .OrderBy(p => p.LocationGroup)
               .ThenBy(p => p.NumberOfLoans)
               .ToList();

            return new ListResultDto<LocationAttributeListDto>(ObjectMapper.Map<List<LocationAttributeListDto>>(locationAttributes));

        }
    }
}
