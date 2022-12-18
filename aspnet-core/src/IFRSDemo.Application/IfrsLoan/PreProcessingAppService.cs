using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using IFRSDemo.IfrsLoan;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using IFRSDemo.Authorization;
using Microsoft.EntityFrameworkCore;


namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_Tenant_PreProcessing)]
    public class PreProcessingAppService : IFRSDemoAppServiceBase, IPreProcessingAppService
    {
        private readonly IRepository<PreProcessing> _preProcessingRepository;
        public PreProcessingAppService(IRepository<PreProcessing> preProcessingRepository)
        {
            _preProcessingRepository = preProcessingRepository;
        }

        public ListResultDto<PreProcessingListDto> GetPreProcessing(GetPreProcessingInput input)
        {
            var preProcessings = _preProcessingRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.name.Contains(input.Filter) ||
                           p.num_null.ToString().Contains(input.Filter) ||
                           p.outl_ier.ToString().Contains(input.Filter) ||
                           p.components.Contains(input.Filter) ||
                           p.num.ToString().Contains(input.Filter) ||
                           p.combination.Contains(input.Filter)

               )
               .OrderBy(p => p.name)
               .ThenBy(p => p.combination)
               .ToList();

            return new ListResultDto<PreProcessingListDto>(ObjectMapper.Map<List<PreProcessingListDto>>(preProcessings));

        }

    }
}
