using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using Abp.Domain.Repositories;
using System.Threading.Tasks;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Runtime.Session;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using IFRSDemo.Authorization;

namespace IFRSDemo.IfrsLoan
{
    [AbpAuthorize(AppPermissions.Pages_InputDataValueCollector)]
    public class InputDataValueCollectorAppService : IFRSDemoAppServiceBase, IInputDataValueCollectorAppService
    {
        private readonly IRepository<InputDataValueCollector> _inputDataValueCollectorRepository;
        private readonly IInputDataValueCollectorRepository _inputDataRepository;
        private readonly IRepository<collectAttribute> _collectorRepository;
        private readonly IAbpSession _abp;
        public InputDataValueCollectorAppService(IRepository<InputDataValueCollector> inputDataValueCollectorRepository, IAbpSession abp, IInputDataValueCollectorRepository inputDataRepository,
                                                 IRepository<collectAttribute> collectorRepository)
        {
            _inputDataValueCollectorRepository = inputDataValueCollectorRepository;
            _abp = abp;
            _inputDataRepository = inputDataRepository;
            _collectorRepository = collectorRepository;
        }

        public async Task CreateInputDataValueCollector(CreateInputDataValueCollectorInput input)
        {
            input.TenantId = _abp.GetTenantId();
            var histogram = ObjectMapper.Map<InputDataValueCollector>(input);
            await _inputDataValueCollectorRepository.InsertAsync(histogram);
        }

        public void CreateSelectedAttributes(string param1, int param2)
        {
            param2 = _abp.GetTenantId();
            _inputDataRepository.CreateSelectedAttributes(param1, param2);
        }

        [AbpAuthorize(AppPermissions.Pages_GetInputDataValueCollector)]
        public async Task<PagedResultDto<InputDataValueCollectorListDto>> GetInputDataValueCollectorInput(GetInputDataValueCollectorInput input)
        {
            var filteredInputs = _inputDataValueCollectorRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.SelectedValues.Contains(input.Filter));
                        
            var pagedAndFilteredDataCollectors = filteredInputs
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);
            var dataCollector = from o in pagedAndFilteredDataCollectors

                                select new InputDataValueCollectorListDto()
                              {

                                  SelectedValues = o.SelectedValues,
                                  Id = o.Id
                              };

            var totalCount = await filteredInputs.CountAsync();


            return new PagedResultDto<InputDataValueCollectorListDto>(
                totalCount,
                await dataCollector.ToListAsync()
            );
        }
        [AbpAuthorize(AppPermissions.Pages_DeleteSelectedAttributes)]
        public async Task DeleteSelectedAttributes(EntityDto input)
        {
            await _inputDataValueCollectorRepository.DeleteAsync(input.Id);
        }

        public CollectAttributeDto[] GetCollectAttribute()
        {
            var rre = from e in _collectorRepository.GetAll()
                      select new CollectAttributeDto()
                      {
                          attributes = e.attributes,
                          Id = e.Id
                      };
            return rre.ToArray();
        }

        public void FillCreditExclusion()
        {
            _inputDataRepository.FillCreditExclusion();
        }
    }
}
