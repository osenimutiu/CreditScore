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
    public class AccountAuthorizeAppService : IFRSDemoAppServiceBase, IAccountAuthorizeAppService
    {
        private readonly IRepository<AccountAuthorize> _accountAuthorizeRepository;
        public AccountAuthorizeAppService(IRepository<AccountAuthorize> accountAuthorizeRepository)
        {
            _accountAuthorizeRepository = accountAuthorizeRepository;

        }

        public async Task<PagedResultDto<AccountAuthorizeListDto>> GetAccountAuthorize(GetAccountAuthorizeInput input)
        {

            var filteredInventories = _accountAuthorizeRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Option.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new AccountAuthorizeListDto()
                              {
                                  Option = o.Option,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<AccountAuthorizeListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
