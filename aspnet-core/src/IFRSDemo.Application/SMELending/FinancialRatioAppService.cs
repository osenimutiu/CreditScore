//using Abp.Application.Services.Dto;
//using Abp.Collections.Extensions;
//using Abp.Domain.Repositories;
//using Abp.Runtime.Session;
//using IFRSDemo.SMELending.Dtos;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using Abp.Extensions;

using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Linq;
using Abp.Linq.Extensions;
using IFRSDemo.SMELending.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Runtime.Session;


namespace IFRSDemo.SMELending
{
   public class FinancialRatioAppService : IFRSDemoAppServiceBase, IFinancialRatioAppService
    {
        private readonly IRepository<FinancialRatio> _financialRatioRepository;
        private readonly IAbpSession _abp;

        public FinancialRatioAppService(IRepository<FinancialRatio> financialRatioRepository, IAbpSession abp)
        {
            _financialRatioRepository = financialRatioRepository;
            _abp = abp;

        }

        public async Task<PagedResultDto<FinancialRatioListDto>> GetFinancialRatio(GetFinancialRatioInput input)
        {
            var filteredInventories = _financialRatioRepository.GetAll()

                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false ||
                        e.RatioName.Contains(input.Filter) ||
                        e.RatioDefinition.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RatioNameFilter), e => e.RatioName == input.RatioNameFilter);

            var pagedAndFilteredInventories = filteredInventories;
            //.OrderBy(input.Sorting ?? "id asc")
            //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories

                              select new FinancialRatioListDto()
                              {

                                  RatioName = o.RatioName,
                                  RatioDefinition = o.RatioDefinition,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();


            return new PagedResultDto<FinancialRatioListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


        //public async Task<PagedResultDto<FinancialRatioListDto>> GetFinancialRatio(GetFinancialRatioInput input)
        //{
        //    var filteredInventories = _financialRatioRepository.GetAll()

        //                .WhereIf(
        //                !input.Filter.IsNullOrEmpty(),
        //                p => p.RatioName.Contains(input.Filter) ||
        //                     p.RatioDefinition.Contains(input.Filter))
        //                    .WhereIf(!string.IsNullOrWhiteSpace(input.RatioNameFilter), e => e.RatioName == input.RatioNameFilter);
        //    var pagedAndFilteredInventories = filteredInventories;
        //    //.OrderBy(input.Sorting ?? "id asc")
        //    //.PageBy(input);
        //    var inventories = from o in pagedAndFilteredInventories




        //                      select new FinancialRatioListDto()
        //                      {
        //                          RatioName = o.RatioName,
        //                          RatioDefinition = o.RatioDefinition,
        //                          Id = o.Id,
        //                      };

        //    var totalCount = await filteredInventories.CountAsync();


        //    return new PagedResultDto<FinancialRatioListDto>(
        //        totalCount,
        //        await inventories.ToListAsync()
        //    );
        //}
        public async Task CreateFinancialRatio(CreateFinancialRatioInput input)
        {
            input.TenantId = _abp.GetTenantId();
            var financialRatio = ObjectMapper.Map<FinancialRatio>(input);
            await _financialRatioRepository.InsertAsync(financialRatio);
        }


        public async Task DeleteFinancialRatio(EntityDto input)
        {
            await _financialRatioRepository.DeleteAsync(input.Id);
        }

        
        public async Task<GetFinancialRatioForEditOutput> GetFinancialRatioForEdit(GetFinancialRatioForEditInput input)
        {
            var FinancialRatio = await _financialRatioRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetFinancialRatioForEditOutput>(FinancialRatio);
        }

       
        public async Task EditFinancialRatio(EditFinancialRatioInput input)
        {
            var financialRatio = await _financialRatioRepository.GetAsync(input.Id);
            financialRatio.RatioName = input.RatioName;
            financialRatio.RatioDefinition = input.RatioDefinition;
           
            await _financialRatioRepository.UpdateAsync(financialRatio);
        }

    }
}
