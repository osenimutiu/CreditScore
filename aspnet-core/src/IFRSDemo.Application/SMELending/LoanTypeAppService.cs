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
    public class LoanTypeAppService : IFRSDemoAppServiceBase, ILoanTypeAppService
    {
        private readonly IRepository<LoanType> _LoanTypeRepository;
        public LoanTypeAppService(IRepository<LoanType> LoanTypeRepository)
        {
            _LoanTypeRepository = LoanTypeRepository;

        }

        public async Task<PagedResultDto<LoanTypeListDto>> GetLoanType(GetLoanTypeInput input)
        {

            var filteredInventories = _LoanTypeRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.LoanTypes.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new LoanTypeListDto()
                              {
                                  LoanTypes = o.LoanTypes,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<LoanTypeListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
