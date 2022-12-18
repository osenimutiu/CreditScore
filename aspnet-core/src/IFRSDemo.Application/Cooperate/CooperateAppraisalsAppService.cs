using IFRSDemo.Cooperate;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using IFRSDemo.Cooperate.Exporting;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.Cooperate
{
    [AbpAuthorize(AppPermissions.Pages_CooperateAppraisals)]
    public class CooperateAppraisalsAppService : IFRSDemoAppServiceBase, ICooperateAppraisalsAppService
    {
        private readonly IRepository<CooperateAppraisal> _cooperateAppraisalRepository;
        private readonly ICooperateAppraisalsExcelExporter _cooperateAppraisalsExcelExporter;
        private readonly IRepository<SetupQualitative, int> _lookup_setupQualitativeRepository;

        public CooperateAppraisalsAppService(IRepository<CooperateAppraisal> cooperateAppraisalRepository, ICooperateAppraisalsExcelExporter cooperateAppraisalsExcelExporter, IRepository<SetupQualitative, int> lookup_setupQualitativeRepository)
        {
            _cooperateAppraisalRepository = cooperateAppraisalRepository;
            _cooperateAppraisalsExcelExporter = cooperateAppraisalsExcelExporter;
            _lookup_setupQualitativeRepository = lookup_setupQualitativeRepository;

        }

        public async Task<PagedResultDto<GetCooperateAppraisalForViewDto>> GetAll(GetAllCooperateAppraisalsInput input)
        {

            var filteredCooperateAppraisals = _cooperateAppraisalRepository.GetAll()
                        .Include(e => e.SetupQualitativeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CompanyName.Contains(input.Filter) || e.RCNumber.Contains(input.Filter) || e.AccountNumber.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyNameFilter), e => e.CompanyName == input.CompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RCNumberFilter), e => e.RCNumber == input.RCNumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AccountNumberFilter), e => e.AccountNumber == input.AccountNumberFilter)
                        .WhereIf(input.MinScoreFilter != null, e => e.Score >= input.MinScoreFilter)
                        .WhereIf(input.MaxScoreFilter != null, e => e.Score <= input.MaxScoreFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SetupQualitativeQualitativeFilter), e => e.SetupQualitativeFk != null && e.SetupQualitativeFk.Qualitative == input.SetupQualitativeQualitativeFilter);

            var pagedAndFilteredCooperateAppraisals = filteredCooperateAppraisals
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var cooperateAppraisals = from o in pagedAndFilteredCooperateAppraisals
                                      join o1 in _lookup_setupQualitativeRepository.GetAll() on o.SetupQualitativeId equals o1.Id into j1
                                      from s1 in j1.DefaultIfEmpty()

                                      select new GetCooperateAppraisalForViewDto()
                                      {
                                          CooperateAppraisal = new CooperateAppraisalDto
                                          {
                                              CompanyName = o.CompanyName,
                                              RCNumber = o.RCNumber,
                                              AccountNumber = o.AccountNumber,
                                              Score = o.Score,
                                              TenantId = o.TenantId.Value,
                                              Id = o.Id
                                          },
                                          SetupQualitativeQualitative = s1 == null || s1.Qualitative == null ? "" : s1.Qualitative.ToString()
                                      };

            var totalCount = await filteredCooperateAppraisals.CountAsync();

            return new PagedResultDto<GetCooperateAppraisalForViewDto>(
                totalCount,
                await cooperateAppraisals.ToListAsync()
            );
        }

        public async Task<GetCooperateAppraisalForViewDto> GetCooperateAppraisalForView(int id)
        {
            var cooperateAppraisal = await _cooperateAppraisalRepository.GetAsync(id);

            var output = new GetCooperateAppraisalForViewDto { CooperateAppraisal = ObjectMapper.Map<CooperateAppraisalDto>(cooperateAppraisal) };
             
            if (output.CooperateAppraisal.SetupQualitativeId != null)
            {
                var _lookupSetupQualitative = await _lookup_setupQualitativeRepository.FirstOrDefaultAsync((int)output.CooperateAppraisal.SetupQualitativeId);
                output.SetupQualitativeQualitative = _lookupSetupQualitative?.Qualitative?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_CooperateAppraisals_Edit)]
        public async Task<GetCooperateAppraisalForEditOutput> GetCooperateAppraisalForEdit(EntityDto input)
        {
            var cooperateAppraisal = await _cooperateAppraisalRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCooperateAppraisalForEditOutput { CooperateAppraisal = ObjectMapper.Map<CreateOrEditCooperateAppraisalDto>(cooperateAppraisal) };

            if (output.CooperateAppraisal.SetupQualitativeId != null)
            {   
                var _lookupSetupQualitative = await _lookup_setupQualitativeRepository.FirstOrDefaultAsync((int)output.CooperateAppraisal.SetupQualitativeId);
                output.SetupQualitativeQualitative = _lookupSetupQualitative?.Qualitative?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditCooperateAppraisalDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_CooperateAppraisals_Create)]
        protected virtual async Task Create(CreateOrEditCooperateAppraisalDto input)
        {
            var cooperateAppraisal = ObjectMapper.Map<CooperateAppraisal>(input);

            if (AbpSession.TenantId != null)
            {
                cooperateAppraisal.TenantId = (int?)AbpSession.TenantId;
            }

            await _cooperateAppraisalRepository.InsertAsync(cooperateAppraisal);
        }

        [AbpAuthorize(AppPermissions.Pages_CooperateAppraisals_Edit)]
        protected virtual async Task Update(CreateOrEditCooperateAppraisalDto input)
        {
            var cooperateAppraisal = await _cooperateAppraisalRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, cooperateAppraisal);
        }

        [AbpAuthorize(AppPermissions.Pages_CooperateAppraisals_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _cooperateAppraisalRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetCooperateAppraisalsToExcel(GetAllCooperateAppraisalsForExcelInput input)
        {

            var filteredCooperateAppraisals = _cooperateAppraisalRepository.GetAll()
                        .Include(e => e.SetupQualitativeFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.CompanyName.Contains(input.Filter) || e.RCNumber.Contains(input.Filter) || e.AccountNumber.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CompanyNameFilter), e => e.CompanyName == input.CompanyNameFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RCNumberFilter), e => e.RCNumber == input.RCNumberFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.AccountNumberFilter), e => e.AccountNumber == input.AccountNumberFilter)
                        .WhereIf(input.MinScoreFilter != null, e => e.Score >= input.MinScoreFilter)
                        .WhereIf(input.MaxScoreFilter != null, e => e.Score <= input.MaxScoreFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SetupQualitativeQualitativeFilter), e => e.SetupQualitativeFk != null && e.SetupQualitativeFk.Qualitative == input.SetupQualitativeQualitativeFilter);

            var query = (from o in filteredCooperateAppraisals
                         join o1 in _lookup_setupQualitativeRepository.GetAll() on o.SetupQualitativeId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetCooperateAppraisalForViewDto()
                         {
                             CooperateAppraisal = new CooperateAppraisalDto
                             {
                                 CompanyName = o.CompanyName,
                                 RCNumber = o.RCNumber,
                                 AccountNumber = o.AccountNumber,
                                 Score = o.Score,
                                 Id = o.Id
                             },
                             SetupQualitativeQualitative = s1 == null || s1.Qualitative == null ? "" : s1.Qualitative.ToString()
                         });

            var cooperateAppraisalListDtos = await query.ToListAsync();

            return _cooperateAppraisalsExcelExporter.ExportToFile(cooperateAppraisalListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_CooperateAppraisals)]
        public async Task<PagedResultDto<CooperateAppraisalSetupQualitativeLookupTableDto>> GetAllSetupQualitativeForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _lookup_setupQualitativeRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Qualitative != null && e.Qualitative.Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var setupQualitativeList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<CooperateAppraisalSetupQualitativeLookupTableDto>();
            foreach (var setupQualitative in setupQualitativeList)
            {
                lookupTableDtoList.Add(new CooperateAppraisalSetupQualitativeLookupTableDto
                {
                    Id = setupQualitative.Id,
                    DisplayName = setupQualitative.Qualitative?.ToString()
                });
            }

            return new PagedResultDto<CooperateAppraisalSetupQualitativeLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }
    }
}