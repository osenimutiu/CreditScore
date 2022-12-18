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
   public class GenderTypeAppService : IFRSDemoAppServiceBase, IGenderTypeAppService
    {
        private readonly IRepository<GenderType> _genderTypeRepository;
        public GenderTypeAppService(IRepository<GenderType> genderTypeRepository)
        {
            _genderTypeRepository = genderTypeRepository;
            
        }

        public async Task<PagedResultDto<GenderTypeListDto>> GetGenderType(GetGenderTypeInput input)
        {

            var filteredInventories = _genderTypeRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.Type.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new GenderTypeListDto()
                              {
                                  Type = o.Type,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<GenderTypeListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
