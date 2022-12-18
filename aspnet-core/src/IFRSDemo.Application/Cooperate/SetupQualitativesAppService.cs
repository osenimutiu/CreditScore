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
using IFRSDemo.Curves;

namespace IFRSDemo.Cooperate
{
    [AbpAuthorize(AppPermissions.Pages_SetupQualitatives)]
    public class SetupQualitativesAppService : IFRSDemoAppServiceBase, ISetupQualitativesAppService
    {
        private readonly IRepository<SetupQualitative> _setupQualitativeRepository;
        private readonly ISetupQualitativesExcelExporter _setupQualitativesExcelExporter;
        private readonly IRepository<SectionSetup, int> _lookup_sectionSetupRepository;
        private readonly IRepository<SetupSubHeading, int> _lookup_setupSubHeadingRepository;
        private readonly IRepository<CooperateCustomer, int> _customerRepo;
        private readonly ICurveRepository _demoRepo;
        private readonly IRepository<CooperateScore, int> _cooperateRepo;
        private readonly IRepository<CooperateCutOff, int> _cutOffRepo;





        public SetupQualitativesAppService(IRepository<SetupQualitative> setupQualitativeRepository, ISetupQualitativesExcelExporter setupQualitativesExcelExporter, IRepository<SectionSetup, int> lookup_sectionSetupRepository, IRepository<SetupSubHeading, int> lookup_setupSubHeadingRepository, IRepository<CooperateCustomer, int> customerRepo, ICurveRepository demoRepo, IRepository<CooperateScore, int> cooperateRepo, IRepository<CooperateCutOff, int> cutOffRepo)
        {
            _setupQualitativeRepository = setupQualitativeRepository;
            _setupQualitativesExcelExporter = setupQualitativesExcelExporter;
            _lookup_sectionSetupRepository = lookup_sectionSetupRepository;
            _lookup_setupSubHeadingRepository = lookup_setupSubHeadingRepository;
            _customerRepo = customerRepo;
            _demoRepo = demoRepo;
            _cooperateRepo = cooperateRepo;
            _cutOffRepo = cutOffRepo;

        }

        public async Task<PagedResultDto<GetSetupQualitativeForViewDto>> GetAll(GetAllSetupQualitativesInput input)
        {

            var filteredSetupQualitatives = _setupQualitativeRepository.GetAll()
                        .Include(e => e.SectionSetupFk)
                        .Include(e => e.SetupSubHeadingFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Qualitative.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.QualitativeFilter), e => e.Qualitative == input.QualitativeFilter)
                        .WhereIf(input.MinValueFilter != null, e => e.Value >= input.MinValueFilter)
                        .WhereIf(input.MaxValueFilter != null, e => e.Value <= input.MaxValueFilter)
                        .WhereIf(input.StatusFilter.HasValue && input.StatusFilter > -1, e => (input.StatusFilter == 1 && e.Status) || (input.StatusFilter == 0 && !e.Status))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionSetupSectionFilter), e => e.SectionSetupFk != null && e.SectionSetupFk.Section == input.SectionSetupSectionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SetupSubHeadingSubHeadingFilter), e => e.SetupSubHeadingFk != null && e.SetupSubHeadingFk.SubHeading == input.SetupSubHeadingSubHeadingFilter);

            var pagedAndFilteredSetupQualitatives = filteredSetupQualitatives
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var setupQualitatives = from o in pagedAndFilteredSetupQualitatives
                                    join o1 in _lookup_sectionSetupRepository.GetAll() on o.SectionSetupId equals o1.Id into j1
                                    from s1 in j1.DefaultIfEmpty()

                                    join o2 in _lookup_setupSubHeadingRepository.GetAll() on o.SetupSubHeadingId equals o2.Id into j2
                                    from s2 in j2.DefaultIfEmpty()

                                    select new GetSetupQualitativeForViewDto()
                                    {
                                        SetupQualitative = new SetupQualitativeDto
                                        {
                                            Qualitative = o.Qualitative,
                                            Value = o.Value,
                                            Status = o.Status,
                                            Id = o.Id
                                        },
                                        SectionSetupSection = s1 == null || s1.Section == null ? "" : s1.Section.ToString(),
                                        SetupSubHeadingSubHeading = s2 == null || s2.SubHeading == null ? "" : s2.SubHeading.ToString()
                                    };

            var totalCount = await filteredSetupQualitatives.CountAsync();

            return new PagedResultDto<GetSetupQualitativeForViewDto>(
                totalCount,
                await setupQualitatives.ToListAsync()
            );
        }
        public IEnumerable<Object> GetApprovedQualitative(int SubHeadingParam)
        {
            var result = (from o in _setupQualitativeRepository.GetAll().Where(x => x.SetupSubHeadingId == SubHeadingParam && x.Status == true)
                    select new
                    {
                        SectionSetupId = o.SectionSetupId,
                        SetupSubHeadingId = o.SetupSubHeadingId,
                        Qualitative = o.Qualitative,
                        Value = o.Value,
                        Status = o.Status,
                        Id = o.Id
                    }).ToList();
            return result;
        }
        public IEnumerable<Object> GetCutOff()
        {
            int param = 1;
            var res = from a in _cutOffRepo.GetAll()
                      select new
                      {
                          CutOff = a.CuttOff,
                          Id = a.Id
                      };
            return res.OrderByDescending(x => x.Id).Take(param).ToArray();
        }

        public async Task<GetCooperateScoreForEditOutput> GetRetailScoreItemEdit(GetCooperateScoreForEditInput input)
        {
            var item = await _cooperateRepo.GetAsync(input.Id);
            return ObjectMapper.Map<GetCooperateScoreForEditOutput>(item);
        }
        public double GetLatestCooperateScore()
        {
            //var item = _cooperateRepo.GetAll().OrderByDescending(c=>c.Score).FirstOrDefault().Score;
            var item = _cooperateRepo.GetAll().OrderBy(c => c.Id).LastOrDefault().Score;
            return item;
        }
        public async Task EditCooperateScore(EditCooperateScoreInput input)
        {
            var item = await _cooperateRepo.GetAsync(input.Id);
            item.CompanyId = input.CompanyId;
            item.Score = input.Score;
            await _cooperateRepo.UpdateAsync(item);
        }
        public IEnumerable<Object> GetExistingCooperate()
        {
            var result = from b in _customerRepo.GetAll()
                         select new
                         {
                             CompanyName = b.CompanyName,
                             RCNumber = b.RCNumber,
                             AccountNo = b.AccountNo,
                             Id = b.Id
                         };
            return result.ToList();
        }
        public ApiResponseDto AddExistingCooperateScore(CreateCooperateScoreDto input)
        {

            var item = ObjectMapper.Map<CooperateScore>(input);
            _cooperateRepo.InsertAsync(item);
            return new ApiResponseDto { Status = 200, Message = $"Score computed succesfully" };
        }
        public async Task<GetSetupQualitativeForViewDto> GetSetupQualitativeForView(int id)
        {
            var setupQualitative = await _setupQualitativeRepository.GetAsync(id);

            var output = new GetSetupQualitativeForViewDto { SetupQualitative = ObjectMapper.Map<SetupQualitativeDto>(setupQualitative) };

            if (output.SetupQualitative.SectionSetupId != null)
            {
                var _lookupSectionSetup = await _lookup_sectionSetupRepository.FirstOrDefaultAsync((int)output.SetupQualitative.SectionSetupId);
                output.SectionSetupSection = _lookupSectionSetup?.Section?.ToString();
            }

            if (output.SetupQualitative.SetupSubHeadingId != null)
            {
                var _lookupSetupSubHeading = await _lookup_setupSubHeadingRepository.FirstOrDefaultAsync((int)output.SetupQualitative.SetupSubHeadingId);
                output.SetupSubHeadingSubHeading = _lookupSetupSubHeading?.SubHeading?.ToString();
            }

            return output;
        }
        public IEnumerable<Object> GetDetailScores()
        {
            var result = (from a in _cooperateRepo.GetAll()
                          join b in _customerRepo.GetAll() on a.CompanyId equals b.Id
                          select new
                          {
                              CompanyName = b.CompanyName,
                              RCNumber = b.RCNumber,
                              AccountNo = b.AccountNo,
                              Score = a.Score,
                              Id = a.Id
                          }).ToList();
            return result;
        }
        public ApiResponseDto InsertNewCoperateScore(string param1, string param2, string param3, double param4)
        {
            bool isExist = _customerRepo.GetAll().Where(t => t.RCNumber == param3).Any();
            if (isExist)
            {
                return new ApiResponseDto { Status = 203, Message = $"Cooperate with RC Number '{param3}' already exist" };
            }
            bool res = _demoRepo.InsertNewCoperateScore(param1, param2, param3, param4);
            if (res)
            {
                return new ApiResponseDto { Status = 200, Message = $"Score computed succesfully" };
            }
            return new ApiResponseDto();
        }

        [AbpAuthorize(AppPermissions.Pages_SetupQualitatives_Edit)]
        public async Task<GetSetupQualitativeForEditOutput> GetSetupQualitativeForEdit(EntityDto input)
        {
            var setupQualitative = await _setupQualitativeRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSetupQualitativeForEditOutput { SetupQualitative = ObjectMapper.Map<CreateOrEditSetupQualitativeDto>(setupQualitative) };

            if (output.SetupQualitative.SectionSetupId != null)
            {
                var _lookupSectionSetup = await _lookup_sectionSetupRepository.FirstOrDefaultAsync((int)output.SetupQualitative.SectionSetupId);
                output.SectionSetupSection = _lookupSectionSetup?.Section?.ToString();
            }

            if (output.SetupQualitative.SetupSubHeadingId != null)
            {
                var _lookupSetupSubHeading = await _lookup_setupSubHeadingRepository.FirstOrDefaultAsync((int)output.SetupQualitative.SetupSubHeadingId);
                output.SetupSubHeadingSubHeading = _lookupSetupSubHeading?.SubHeading?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSetupQualitativeDto input)
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

        [AbpAuthorize(AppPermissions.Pages_SetupQualitatives_Create)]
        protected virtual async Task Create(CreateOrEditSetupQualitativeDto input)
        {
            var setupQualitative = ObjectMapper.Map<SetupQualitative>(input);

            if (AbpSession.TenantId != null)
            {
                setupQualitative.TenantId = (int?)AbpSession.TenantId;
            }

            await _setupQualitativeRepository.InsertAsync(setupQualitative);
        }

        [AbpAuthorize(AppPermissions.Pages_SetupQualitatives_Edit)]
        protected virtual async Task Update(CreateOrEditSetupQualitativeDto input)
        {
            var setupQualitative = await _setupQualitativeRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, setupQualitative);
        }

        [AbpAuthorize(AppPermissions.Pages_SetupQualitatives_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _setupQualitativeRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSetupQualitativesToExcel(GetAllSetupQualitativesForExcelInput input)
        {

            var filteredSetupQualitatives = _setupQualitativeRepository.GetAll()
                        .Include(e => e.SectionSetupFk)
                        .Include(e => e.SetupSubHeadingFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Qualitative.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.QualitativeFilter), e => e.Qualitative == input.QualitativeFilter)
                        .WhereIf(input.MinValueFilter != null, e => e.Value >= input.MinValueFilter)
                        .WhereIf(input.MaxValueFilter != null, e => e.Value <= input.MaxValueFilter)
                        .WhereIf(input.StatusFilter.HasValue && input.StatusFilter > -1, e => (input.StatusFilter == 1 && e.Status) || (input.StatusFilter == 0 && !e.Status))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionSetupSectionFilter), e => e.SectionSetupFk != null && e.SectionSetupFk.Section == input.SectionSetupSectionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SetupSubHeadingSubHeadingFilter), e => e.SetupSubHeadingFk != null && e.SetupSubHeadingFk.SubHeading == input.SetupSubHeadingSubHeadingFilter);

            var query = (from o in filteredSetupQualitatives
                         join o1 in _lookup_sectionSetupRepository.GetAll() on o.SectionSetupId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         join o2 in _lookup_setupSubHeadingRepository.GetAll() on o.SetupSubHeadingId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         select new GetSetupQualitativeForViewDto()
                         {
                             SetupQualitative = new SetupQualitativeDto
                             {
                                 Qualitative = o.Qualitative,
                                 Value = o.Value,
                                 Status = o.Status,
                                 Id = o.Id
                             },
                             SectionSetupSection = s1 == null || s1.Section == null ? "" : s1.Section.ToString(),
                             SetupSubHeadingSubHeading = s2 == null || s2.SubHeading == null ? "" : s2.SubHeading.ToString()
                         });

            var setupQualitativeListDtos = await query.ToListAsync();

            return _setupQualitativesExcelExporter.ExportToFile(setupQualitativeListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_SetupQualitatives)]
        public async Task<List<SetupQualitativeSectionSetupLookupTableDto>> GetAllSectionSetupForTableDropdown()
        {
            return await _lookup_sectionSetupRepository.GetAll()
                .Select(sectionSetup => new SetupQualitativeSectionSetupLookupTableDto
                {
                    Id = sectionSetup.Id,
                    DisplayName = sectionSetup == null || sectionSetup.Section == null ? "" : sectionSetup.Section.ToString()
                }).ToListAsync();
        }

        [AbpAuthorize(AppPermissions.Pages_SetupQualitatives)]
        public async Task<List<SetupQualitativeSetupSubHeadingLookupTableDto>> GetAllSetupSubHeadingForTableDropdown()
        {
            return await _lookup_setupSubHeadingRepository.GetAll()
                .Select(setupSubHeading => new SetupQualitativeSetupSubHeadingLookupTableDto
                {
                    Id = setupSubHeading.Id,
                    DisplayName = setupSubHeading == null || setupSubHeading.SubHeading == null ? "" : setupSubHeading.SubHeading.ToString()
                }).ToListAsync();
        }

    }
}