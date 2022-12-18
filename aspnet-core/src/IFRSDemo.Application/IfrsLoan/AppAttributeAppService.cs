using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public class AppAttributeAppService : IFRSDemoAppServiceBase, IAppAttributeAppService
    {
        private readonly IRepository<AppAttribute> _appAttributeRepository;
        public AppAttributeAppService(IRepository<AppAttribute> appAttributeRepository)
        {
            _appAttributeRepository = appAttributeRepository;
        }
        public ListResultDto<AppAttributeListDto> GetAppAttribute(GetAppAttributeInput input)
        {
            var appAttributes = _appAttributeRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.ApplicanType.Contains(input.Filter)
               )
               .OrderBy(p => p.ApplicanType)
               // .ThenBy(p => p.Name)
               .ToList();

            return new ListResultDto<AppAttributeListDto>(ObjectMapper.Map<List<AppAttributeListDto>>(appAttributes));

        }

    }
}
