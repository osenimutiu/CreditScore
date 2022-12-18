using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Authorization;
using IFRSDemo.Authorization;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_ReturnonAssetsAttribute)]
    public class ReturnonAssetsAttributeAppService : IFRSDemoAppServiceBase, IReturnonAssetsAttributeAppService
    {
        private readonly IRepository<ReturnonAssetsAttribute> _returnonAssetsAttributeRepository;
        public ReturnonAssetsAttributeAppService(IRepository<ReturnonAssetsAttribute> returnonAssetsAttributeRepository)
        {
            _returnonAssetsAttributeRepository = returnonAssetsAttributeRepository;
        }

        public ListResultDto<ReturnonAssetsAttributeListDto> GetReturnonAssetsAttribute(GetReturnonAssetsAttributeInput input)
        {
            var returnonAssetsAttributes = _returnonAssetsAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.ReturnonAssets.Contains(input.Filter)

               )
               //.OrderBy(p => p.featurename)
               //.ThenBy(p => p.lowerBound)
               .ToList();

            return new ListResultDto<ReturnonAssetsAttributeListDto>(ObjectMapper.Map<List<ReturnonAssetsAttributeListDto>>(returnonAssetsAttributes));

        }
    }
}
