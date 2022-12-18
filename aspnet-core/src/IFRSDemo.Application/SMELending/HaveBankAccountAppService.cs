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
    public class HaveBankAccountAppService : IFRSDemoAppServiceBase, IHaveBankAccountAppService
    {
        private readonly IRepository<HaveBankAccount> _haveBankAccountRepository;
        public HaveBankAccountAppService(IRepository<HaveBankAccount> haveBankAccountRepository)
        {
            _haveBankAccountRepository = haveBankAccountRepository;

        }

        public async Task<PagedResultDto<HaveBankAccountListDto>> GetHaveBankAccount(GetHaveBankAccountInput input)
        {

            var filteredInventories = _haveBankAccountRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Option.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new HaveBankAccountListDto()
                              {
                                  Option = o.Option,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<HaveBankAccountListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
