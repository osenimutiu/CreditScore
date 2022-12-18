using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using AutoMapper;
using IFRSDemo.IfrsLoan;
using IFRSDemo.IfrsLoan.Dto;
using System.Linq.Dynamic.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Authorization;
using IFRSDemo.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.IfrsLoan
{
   [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoanScoringOutput)]
    public class ScoringOutputAppService : IFRSDemoAppServiceBase, IScoringOutputAppService
    {
        private readonly IRepository<ScoringOutput> _scoringOutputRepository;
        public ScoringOutputAppService(IRepository<ScoringOutput> scoringOutputRepository)
        {
            _scoringOutputRepository = scoringOutputRepository;

        }

        public ListResultDto<ScoringOutputListDto> GetScoringOutput(GetScoringOutputInput input)
        {
            var scoringOutputs = _scoringOutputRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Score.ToString().Contains(input.Filter) ||
                           p.Risk_Level.Contains(input.Filter) ||
                           p.PD.ToString().Contains(input.Filter) ||
                           p.Good_Bad_Odd.ToString().Contains(input.Filter) ||
                           p.Interest_Rate.ToString().Contains(input.Filter) ||
                           p.Recommendation.Contains(input.Filter) ||
                           p.App_Type.Contains(input.Filter) ||
                           p.Debt_Income_Ratio.ToString().Contains(input.Filter)

               )
               .OrderBy(p => p.App_Type)
               .ThenBy(p => p.Score)
               .ToList();

            return new ListResultDto<ScoringOutputListDto>(ObjectMapper.Map<List<ScoringOutputListDto>>(scoringOutputs));

        }

        public async Task<PagedResultDto<ScoringOutputListDto>> GetScoringOutputB(GetScoringOutputInput input)
        {

            var filteredInventories = _scoringOutputRepository.GetAll()
                        
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), 
                        e => false || 
                        e.Score.ToString().Contains(input.Filter) || 
                        e.Risk_Level.Contains(input.Filter) || 
                        e.PD.ToString().Contains(input.Filter) ||
                        e.Good_Bad_Odd.ToString().Contains(input.Filter) ||
                        e.Interest_Rate.ToString().Contains(input.Filter) ||
                        e.Recommendation.Contains(input.Filter) ||
                        e.App_Type.Contains(input.Filter) ||
                        e.Debt_Income_Ratio.ToString().Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.App_TypeFilter), e => e.App_Type == input.App_TypeFilter);

            var pagedAndFilteredInventories = filteredInventories;
                //.OrderBy(input.Sorting ?? "id asc")
                //.PageBy(input);

            var inventories = from o in pagedAndFilteredInventories
                              
                              select new ScoringOutputListDto()
                              {
                                 
                                  Score = o.Score,
                                  Risk_Level = o.Risk_Level,
                                  PD = o.PD,
                                  Good_Bad_Odd = o.Good_Bad_Odd,
                                  Interest_Rate = o.Interest_Rate,
                                  Recommendation = o.Recommendation,
                                  App_Type = o.App_Type,
                                  Debt_Income_Ratio = o.Debt_Income_Ratio,
                                  Id = o.Id
                              };

            var totalCount = await filteredInventories.CountAsync();

            return new PagedResultDto<ScoringOutputListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }


        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_CreateScoringOutput)]
        public async Task CreateScoringOutput(CreateScoringOutputInput input)
        {
            var scoringOutput = ObjectMapper.Map<ScoringOutput>(input);
            await _scoringOutputRepository.InsertAsync(scoringOutput);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_DeleteScoringOutput)]
        public async Task DeleteScoringOutput(EntityDto input)
        {
            await _scoringOutputRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_EditScoringOutput)]
        public async Task<GetScoringOutputForEditOutput> GetScoringOutputForEdit(GetScoringOutputForEditInput input)
        {
            var scoringOutput = await _scoringOutputRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetScoringOutputForEditOutput>(scoringOutput);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_IfrsLoan_EditScoringOutput)]
        public async Task EditScoringOutput(EditScoringOutputInput input)
        {
            var scoringOutput = await _scoringOutputRepository.GetAsync(input.Id);
            scoringOutput.Score = input.Score;
            scoringOutput.Risk_Level = input.Risk_Level;
            scoringOutput.PD = input.PD;
            scoringOutput.Good_Bad_Odd = input.Good_Bad_Odd;
            scoringOutput.Interest_Rate = input.Interest_Rate;
            scoringOutput.Recommendation = input.Recommendation;
            scoringOutput.Debt_Income_Ratio = input.Debt_Income_Ratio;
            await _scoringOutputRepository.UpdateAsync(scoringOutput);
        }

    }
}
