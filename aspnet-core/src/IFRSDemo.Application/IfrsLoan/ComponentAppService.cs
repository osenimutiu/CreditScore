using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using IFRSDemo.IfrsLoan;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Linq.Extensions;
using System.Linq;

namespace IFRSDemo.IfrsLoan
{
   public class ComponentAppService : IFRSDemoAppServiceBase, IComponentAppService
    {
        private readonly IRepository<Component> _componentRepository;
        public ComponentAppService(IRepository<Component> componentRepository)
        {
            _componentRepository = componentRepository;
        }

        public ListResultDto<ComponentListDto> GetComponent(GetComponentInput input)
        {
            var components = _componentRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Name.Contains(input.Filter) 
               )
               .OrderBy(p => p.Name)
              // .ThenBy(p => p.Name)
               .ToList();

            return new ListResultDto<ComponentListDto>(ObjectMapper.Map<List<ComponentListDto>>(components));

        }

    }
}
