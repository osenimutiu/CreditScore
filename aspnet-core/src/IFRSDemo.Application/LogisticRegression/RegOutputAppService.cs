using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using IFRSDemo.LogisticRegression.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Abp.Authorization;
using IFRSDemo.Authorization;

namespace IFRSDemo.LogisticRegression
{
    [AbpAuthorize(AppPermissions.Pages_RegOutput)]
    public class RegOutputAppService : IFRSDemoAppServiceBase, IRegOutputAppService
    {
        private readonly IRepository<RegOutput> _repo;
        private readonly IRepository<RegOutputRunData> _runDateRepo;

        public RegOutputAppService(IRepository<RegOutput> repo, IRepository<RegOutputRunData> runDateRepo)
        {
            _repo = repo;
            _runDateRepo = runDateRepo;
        }

        public void InserRunDate()
        {
            RegOutputRunData obj = new RegOutputRunData();
            obj.RunDate = DateTime.Now;
            _runDateRepo.InsertAsync(obj);
        }

        public async Task<PagedResultDto<RegOutputDto>> GetAll(GetAllRegOutputInput input)
        {
            var filteredInventories = _repo.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.ParamName.Contains(input.Filter) || 
                        e.Coeff_Estimate.ToString().Contains(input.Filter) || 
                        e.Std_Error.ToString().Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ParamNameFilter), e => e.ParamName == input.ParamNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Coeff_EstimateFilter), e => e.Coeff_Estimate.ToString() == input.Coeff_EstimateFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Std_ErrorFilter), e => e.Std_Error.ToString() == input.Std_ErrorFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.t_valueFilter), e => e.t_value.ToString() == input.t_valueFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.p_valueFilter), e => e.p_value.ToString() == input.p_valueFilter);

            var pagedAndFilteredInventories = filteredInventories
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);
            var inventories = from o in pagedAndFilteredInventories
                              select new RegOutputDto
                              {
                                  ParamName = o.ParamName,
                                  Coeff_Estimate = o.Coeff_Estimate,
                                  Std_Error = o.Std_Error,
                                  t_value = o.t_value,
                                  p_value = o.p_value,
                                  Id = o.Id
                              }; 
            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<RegOutputDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }

        public List<RegOutputRunDataDto> GetLastRunDate()
        {
            int i = 1;
            var result = from e in _runDateRepo.GetAll()
                         select new RegOutputRunDataDto()
                         {
                             RunDate = e.RunDate,
                             Id = e.Id
                         };
            return result.OrderByDescending(x => x.RunDate).Take(i).ToList();
        }
    }
}
