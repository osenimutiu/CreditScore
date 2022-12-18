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
    [AbpAuthorize(AppPermissions.Pages_SubHeadingSetups)]
    public class SubHeadingSetupsAppService : IFRSDemoAppServiceBase, ISubHeadingSetupsAppService
    {
        private readonly IRepository<SubHeadingSetup> _subHeadingSetupRepository;
        private readonly ISubHeadingSetupsExcelExporter _subHeadingSetupsExcelExporter;
        private readonly IRepository<SectionSetup, int> _lookup_sectionSetupRepository;

        public SubHeadingSetupsAppService(IRepository<SubHeadingSetup> subHeadingSetupRepository, ISubHeadingSetupsExcelExporter subHeadingSetupsExcelExporter, IRepository<SectionSetup, int> lookup_sectionSetupRepository)
        {
            _subHeadingSetupRepository = subHeadingSetupRepository;
            _subHeadingSetupsExcelExporter = subHeadingSetupsExcelExporter;
            _lookup_sectionSetupRepository = lookup_sectionSetupRepository;

        }

        public async Task<PagedResultDto<GetSubHeadingSetupForViewDto>> GetAll(GetAllSubHeadingSetupsInput input)
        {

            var filteredSubHeadingSetups = _subHeadingSetupRepository.GetAll()
                        .Include(e => e.SectionSetupFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.SubHeading.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionSetupSectionFilter), e => e.SectionSetupFk != null && e.SectionSetupFk.Section == input.SectionSetupSectionFilter);

            var pagedAndFilteredSubHeadingSetups = filteredSubHeadingSetups
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var subHeadingSetups = from o in pagedAndFilteredSubHeadingSetups
                                   join o1 in _lookup_sectionSetupRepository.GetAll() on o.SectionSetupId equals o1.Id into j1
                                   from s1 in j1.DefaultIfEmpty()

                                   select new GetSubHeadingSetupForViewDto()
                                   {
                                       SubHeadingSetup = new SubHeadingSetupDto
                                       {
                                           SubHeading = o.SubHeading,
                                           Id = o.Id
                                       },
                                       SectionSetupSection = s1 == null || s1.Section == null ? "" : s1.Section.ToString()
                                   };

            var totalCount = await filteredSubHeadingSetups.CountAsync();

            return new PagedResultDto<GetSubHeadingSetupForViewDto>(
                totalCount,
                await subHeadingSetups.ToListAsync()
            );
        }

        public async Task<GetSubHeadingSetupForViewDto> GetSubHeadingSetupForView(int id)
        {
            var subHeadingSetup = await _subHeadingSetupRepository.GetAsync(id);

            var output = new GetSubHeadingSetupForViewDto { SubHeadingSetup = ObjectMapper.Map<SubHeadingSetupDto>(subHeadingSetup) };

            if (output.SubHeadingSetup.SectionSetupId != null)
            {
                var _lookupSectionSetup = await _lookup_sectionSetupRepository.FirstOrDefaultAsync((int)output.SubHeadingSetup.SectionSetupId);
                output.SectionSetupSection = _lookupSectionSetup?.Section?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_SubHeadingSetups_Edit)]
        public async Task<GetSubHeadingSetupForEditOutput> GetSubHeadingSetupForEdit(EntityDto input)
        {
            var subHeadingSetup = await _subHeadingSetupRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSubHeadingSetupForEditOutput { SubHeadingSetup = ObjectMapper.Map<CreateOrEditSubHeadingSetupDto>(subHeadingSetup) };

            if (output.SubHeadingSetup.SectionSetupId != null)
            {
                var _lookupSectionSetup = await _lookup_sectionSetupRepository.FirstOrDefaultAsync((int)output.SubHeadingSetup.SectionSetupId);
                output.SectionSetupSection = _lookupSectionSetup?.Section?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSubHeadingSetupDto input)
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

        [AbpAuthorize(AppPermissions.Pages_SubHeadingSetups_Create)]
        protected virtual async Task Create(CreateOrEditSubHeadingSetupDto input)
        {
            var subHeadingSetup = ObjectMapper.Map<SubHeadingSetup>(input);

            if (AbpSession.TenantId != null)
            {
                subHeadingSetup.TenantId = (int?)AbpSession.TenantId;
            }

            await _subHeadingSetupRepository.InsertAsync(subHeadingSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_SubHeadingSetups_Edit)]
        protected virtual async Task Update(CreateOrEditSubHeadingSetupDto input)
        {
            var subHeadingSetup = await _subHeadingSetupRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, subHeadingSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_SubHeadingSetups_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _subHeadingSetupRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSubHeadingSetupsToExcel(GetAllSubHeadingSetupsForExcelInput input)
        {

            var filteredSubHeadingSetups = _subHeadingSetupRepository.GetAll()
                        .Include(e => e.SectionSetupFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.SubHeading.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionSetupSectionFilter), e => e.SectionSetupFk != null && e.SectionSetupFk.Section == input.SectionSetupSectionFilter);

            var query = (from o in filteredSubHeadingSetups
                         join o1 in _lookup_sectionSetupRepository.GetAll() on o.SectionSetupId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetSubHeadingSetupForViewDto()
                         {
                             SubHeadingSetup = new SubHeadingSetupDto
                             {
                                 SubHeading = o.SubHeading,
                                 Id = o.Id
                             },
                             SectionSetupSection = s1 == null || s1.Section == null ? "" : s1.Section.ToString()
                         });

            var subHeadingSetupListDtos = await query.ToListAsync();

            return _subHeadingSetupsExcelExporter.ExportToFile(subHeadingSetupListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_SubHeadingSetups)]
        public async Task<List<SubHeadingSetupSectionSetupLookupTableDto>> GetAllSectionSetupForTableDropdown()
        {
            return await _lookup_sectionSetupRepository.GetAll()
                .Select(sectionSetup => new SubHeadingSetupSectionSetupLookupTableDto
                {
                    Id = sectionSetup.Id,
                    DisplayName = sectionSetup == null || sectionSetup.Section == null ? "" : sectionSetup.Section.ToString()
                }).ToListAsync();
        }

    }
}