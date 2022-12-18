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
    public class BusRegNigAppService : IFRSDemoAppServiceBase, IBusRegNigAppService
    {
        private readonly IRepository<BusRegNig> _busRegNigRepository;
        public BusRegNigAppService(IRepository<BusRegNig> busRegNigRepository)
        {
            _busRegNigRepository = busRegNigRepository;

        }

        public async Task<PagedResultDto<BusRegNigListDto>> GetBusRegNig(GetBusRegNigInput input)
        {

            var filteredInventories = _busRegNigRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Option.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new BusRegNigListDto()
                              {
                                  Option = o.Option,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<BusRegNigListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
