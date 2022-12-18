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
    public class HaveNINAppService : IFRSDemoAppServiceBase, IHaveNINAppService
    {
        private readonly IRepository<HaveNIN> _haveNINRepository;
        public HaveNINAppService(IRepository<HaveNIN> haveNINRepository)
        {
            _haveNINRepository = haveNINRepository;

        }

        public async Task<PagedResultDto<HaveNINListDto>> GetHaveNIN(GetHaveNINInput input)
        {

            var filteredInventories = _haveNINRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Option.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new HaveNINListDto()
                              {
                                  Option = o.Option,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<HaveNINListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
