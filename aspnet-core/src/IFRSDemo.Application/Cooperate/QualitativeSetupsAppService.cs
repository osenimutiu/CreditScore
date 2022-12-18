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
    [AbpAuthorize(AppPermissions.Pages_QualitativeSetups)]
    public class QualitativeSetupsAppService : IFRSDemoAppServiceBase, IQualitativeSetupsAppService
    {
        private readonly IRepository<QualitativeSetup> _qualitativeSetupRepository;
        private readonly IQualitativeSetupsExcelExporter _qualitativeSetupsExcelExporter;

        public QualitativeSetupsAppService(IRepository<QualitativeSetup> qualitativeSetupRepository, IQualitativeSetupsExcelExporter qualitativeSetupsExcelExporter)
        {
            _qualitativeSetupRepository = qualitativeSetupRepository;
            _qualitativeSetupsExcelExporter = qualitativeSetupsExcelExporter;

        }

        public async Task<PagedResultDto<GetQualitativeSetupForViewDto>> GetAll(GetAllQualitativeSetupsInput input)
        {

            var filteredQualitativeSetups = _qualitativeSetupRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Section.Contains(input.Filter) || e.SubHeading.Contains(input.Filter) || e.Qualitative.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionFilter), e => e.Section == input.SectionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.QualitativeFilter), e => e.Qualitative == input.QualitativeFilter)
                        .WhereIf(input.MinValueFilter != null, e => e.Value >= input.MinValueFilter)
                        .WhereIf(input.MaxValueFilter != null, e => e.Value <= input.MaxValueFilter)
                        .WhereIf(input.StatusFilter.HasValue && input.StatusFilter > -1, e => (input.StatusFilter == 1 && e.Status) || (input.StatusFilter == 0 && !e.Status));

            var pagedAndFilteredQualitativeSetups = filteredQualitativeSetups
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var qualitativeSetups = from o in pagedAndFilteredQualitativeSetups
                                    select new GetQualitativeSetupForViewDto()
                                    {
                                        QualitativeSetup = new QualitativeSetupDto
                                        {
                                            Section = o.Section,
                                            SubHeading = o.SubHeading,
                                            Qualitative = o.Qualitative,
                                            Value = o.Value,
                                            Status = o.Status,
                                            Id = o.Id
                                        }
                                    };

            var totalCount = await filteredQualitativeSetups.CountAsync();

            return new PagedResultDto<GetQualitativeSetupForViewDto>(
                totalCount,
                await qualitativeSetups.ToListAsync()
            );
        }

        public async Task<GetQualitativeSetupForViewDto> GetQualitativeSetupForView(int id)
        {
            var qualitativeSetup = await _qualitativeSetupRepository.GetAsync(id);

            var output = new GetQualitativeSetupForViewDto { QualitativeSetup = ObjectMapper.Map<QualitativeSetupDto>(qualitativeSetup) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_QualitativeSetups_Edit)]
        public async Task<GetQualitativeSetupForEditOutput> GetQualitativeSetupForEdit(EntityDto input)
        {
            var qualitativeSetup = await _qualitativeSetupRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetQualitativeSetupForEditOutput { QualitativeSetup = ObjectMapper.Map<CreateOrEditQualitativeSetupDto>(qualitativeSetup) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditQualitativeSetupDto input)
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

        [AbpAuthorize(AppPermissions.Pages_QualitativeSetups_Create)]
        protected virtual async Task Create(CreateOrEditQualitativeSetupDto input)
        {
            var qualitativeSetup = ObjectMapper.Map<QualitativeSetup>(input);

            if (AbpSession.TenantId != null)
            {
                qualitativeSetup.TenantId = (int?)AbpSession.TenantId;
            }

            await _qualitativeSetupRepository.InsertAsync(qualitativeSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_QualitativeSetups_Edit)]
        protected virtual async Task Update(CreateOrEditQualitativeSetupDto input)
        {
            var qualitativeSetup = await _qualitativeSetupRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, qualitativeSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_QualitativeSetups_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _qualitativeSetupRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetQualitativeSetupsToExcel(GetAllQualitativeSetupsForExcelInput input)
        {

            var filteredQualitativeSetups = _qualitativeSetupRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Section.Contains(input.Filter) || e.SubHeading.Contains(input.Filter) || e.Qualitative.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionFilter), e => e.Section == input.SectionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.QualitativeFilter), e => e.Qualitative == input.QualitativeFilter)
                        .WhereIf(input.MinValueFilter != null, e => e.Value >= input.MinValueFilter)
                        .WhereIf(input.MaxValueFilter != null, e => e.Value <= input.MaxValueFilter)
                        .WhereIf(input.StatusFilter.HasValue && input.StatusFilter > -1, e => (input.StatusFilter == 1 && e.Status) || (input.StatusFilter == 0 && !e.Status));

            var query = (from o in filteredQualitativeSetups
                         select new GetQualitativeSetupForViewDto()
                         {
                             QualitativeSetup = new QualitativeSetupDto
                             {
                                 Section = o.Section,
                                 SubHeading = o.SubHeading,
                                 Qualitative = o.Qualitative,
                                 Value = o.Value,
                                 Status = o.Status,
                                 Id = o.Id
                             }
                         });

            var qualitativeSetupListDtos = await query.ToListAsync();

            return _qualitativeSetupsExcelExporter.ExportToFile(qualitativeSetupListDtos);
        }

    }
}