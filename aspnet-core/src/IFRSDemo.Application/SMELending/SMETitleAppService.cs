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
    public class SMETitleAppService : IFRSDemoAppServiceBase, ISMETitleAppService
    {
        private readonly IRepository<SMETitle> _SMETitleRepository;
        public SMETitleAppService(IRepository<SMETitle> SMETitleRepository)
        {
            _SMETitleRepository = SMETitleRepository;

        }

        public async Task<PagedResultDto<SMETitleListDto>> GetSMETitle(GetSMETitleInput input)
        {

            var filteredInventories = _SMETitleRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.IndivividualTitle.Contains(input.Filter));
            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new SMETitleListDto()
                              {
                                  IndivividualTitle = o.IndivividualTitle,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<SMETitleListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


    }
}
