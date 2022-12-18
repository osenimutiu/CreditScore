using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Abp.Runtime.Session;
using System.Linq.Dynamic.Core;
using System.Text;
using IFRSDemo.IfrsLoan.Dto;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;

namespace IFRSDemo.IfrsLoan
{
   public class InputDataAppService : IFRSDemoAppServiceBase, IInputDataAppService
    {
        private readonly IInputDataRepository _inputDataRepository;
        private readonly IAbpSession _abp;
        private readonly IRepository<InputData> _inputDataDropdownRepository;
        public InputDataAppService(IInputDataRepository inputDataRepository, IRepository<InputData> inputDataDropdownRepository, IAbpSession abp)
        {
            _inputDataRepository = inputDataRepository;
            _inputDataDropdownRepository = inputDataDropdownRepository;
            _abp = abp;
        }

        public async Task<List<string>> GetInputDataList()
        {
            return await _inputDataRepository.GetDropdown();
        }

        public async Task<PagedResultDto<InputDataListDto>> GetInputData(GetInputDataInput input)
        {

            var filteredInventories = _inputDataDropdownRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Attributes.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new InputDataListDto()
                              {
                                  Attributes = o.Attributes,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<InputDataListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }

        public async Task DeleteInputData(EntityDto input)
        {
            await _inputDataDropdownRepository.DeleteAsync(input.Id);
        }

        public async Task CreateInputData(CreateInputDataInput input)
        {
            //input.TenantId = _abp.GetTenantId();
            var InputData = ObjectMapper.Map<InputData>(input);
            await _inputDataDropdownRepository.InsertAsync(InputData);
        }


    }
}
