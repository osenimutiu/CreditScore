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
     [AbpAuthorize(AppPermissions.Pages_Tenant_ProductTypeAttribute)]
    public class ProductTypeAttributeAppService : IFRSDemoAppServiceBase, IProductTypeAttributeAppService
    {
        private readonly IRepository<ProductTypeAttribute> _productTypeAttributeRepository;
        public ProductTypeAttributeAppService(IRepository<ProductTypeAttribute> productTypeAttributeRepository)
        {
            _productTypeAttributeRepository = productTypeAttributeRepository;
        }

        public ListResultDto<ProductTypeAttributeListDto> GetProductTypeAttribute(GetProductTypeAttributeInput input)
        {
            var productTypeAttributes = _productTypeAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.ProductType.Contains(input.Filter)

               )
               //.OrderBy(p => p.featurename)
               //.ThenBy(p => p.lowerBound)
               .ToList();

            return new ListResultDto<ProductTypeAttributeListDto>(ObjectMapper.Map<List<ProductTypeAttributeListDto>>(productTypeAttributes));

        }

    }
}
