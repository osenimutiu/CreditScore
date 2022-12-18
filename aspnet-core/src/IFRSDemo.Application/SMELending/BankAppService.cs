using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using IFRSDemo.SMELending.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.SMELending
{
   public class BankAppService : IFRSDemoAppServiceBase, IBankAppService
    {
        
        private readonly IRepository<Bank> _bankRepository;
        public BankAppService(IRepository<Bank> bankRepository)
        {
            _bankRepository = bankRepository;
           
        }

        public async Task<PagedResultDto<BankListDto>> GetBank(GetBankInput input)
        {

            var filteredInventories = _bankRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.BankNames.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new BankListDto()
                              {
                                  BankNames = o.BankNames,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<BankListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }



    }
}
