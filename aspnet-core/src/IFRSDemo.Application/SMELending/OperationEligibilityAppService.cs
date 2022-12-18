using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using IFRSDemo.SMELending.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.SMELending
{
    public class OperationEligibilityAppService : IFRSDemoAppServiceBase, IOperationEligibilityAppService
    {
        private readonly IRepository<Operation_Eligibility> _operationEligibilityRepository;
        public OperationEligibilityAppService(IRepository<Operation_Eligibility> operationEligibilityRepository)
        {
            _operationEligibilityRepository = operationEligibilityRepository;

        }

        public async Task<PagedResultDto<OperationEligibilityListDto>> GetOperationEligibility(GetOperationEligibilityInput input)
        {

            var filteredInventories = _operationEligibilityRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Option.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new OperationEligibilityListDto()
                              {
                                  Option = o.Option,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<OperationEligibilityListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
