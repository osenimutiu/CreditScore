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
    [AbpAuthorize(AppPermissions.Pages_SetupSubHeadings)]
    public class SetupSubHeadingsAppService : IFRSDemoAppServiceBase, ISetupSubHeadingsAppService
    {
        private readonly IRepository<SetupSubHeading> _setupSubHeadingRepository;
        private readonly ISetupSubHeadingsExcelExporter _setupSubHeadingsExcelExporter;
        private readonly IRepository<SectionSetup, int> _lookup_sectionSetupRepository;

        public SetupSubHeadingsAppService(IRepository<SetupSubHeading> setupSubHeadingRepository, ISetupSubHeadingsExcelExporter setupSubHeadingsExcelExporter, IRepository<SectionSetup, int> lookup_sectionSetupRepository)
        {
            _setupSubHeadingRepository = setupSubHeadingRepository;
            _setupSubHeadingsExcelExporter = setupSubHeadingsExcelExporter;
            _lookup_sectionSetupRepository = lookup_sectionSetupRepository;

        }

        public async Task<PagedResultDto<GetSetupSubHeadingForViewDto>> GetAll(GetAllSetupSubHeadingsInput input)
        {

            var filteredSetupSubHeadings = _setupSubHeadingRepository.GetAll()
                        .Include(e => e.SectionSetupFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.SubHeading.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionSetupSectionFilter), e => e.SectionSetupFk != null && e.SectionSetupFk.Section == input.SectionSetupSectionFilter);

            var pagedAndFilteredSetupSubHeadings = filteredSetupSubHeadings
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var setupSubHeadings = from o in pagedAndFilteredSetupSubHeadings
                                   join o1 in _lookup_sectionSetupRepository.GetAll() on o.SectionSetupId equals o1.Id into j1
                                   from s1 in j1.DefaultIfEmpty()

                                   select new GetSetupSubHeadingForViewDto()
                                   {
                                       SetupSubHeading = new SetupSubHeadingDto
                                       {
                                           SubHeading = o.SubHeading,
                                           Id = o.Id
                                       },
                                       SectionSetupSection = s1 == null || s1.Section == null ? "" : s1.Section.ToString()
                                   };

            var totalCount = await filteredSetupSubHeadings.CountAsync();

            return new PagedResultDto<GetSetupSubHeadingForViewDto>(
                totalCount,
                await setupSubHeadings.ToListAsync()
            );
        }

        public async Task<GetSetupSubHeadingForViewDto> GetSetupSubHeadingForView(int id)
        {
            var setupSubHeading = await _setupSubHeadingRepository.GetAsync(id);

            var output = new GetSetupSubHeadingForViewDto { SetupSubHeading = ObjectMapper.Map<SetupSubHeadingDto>(setupSubHeading) };

            if (output.SetupSubHeading.SectionSetupId != null)
            {
                var _lookupSectionSetup = await _lookup_sectionSetupRepository.FirstOrDefaultAsync((int)output.SetupSubHeading.SectionSetupId);
                output.SectionSetupSection = _lookupSectionSetup?.Section?.ToString();
            }

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_SetupSubHeadings_Edit)]
        public async Task<GetSetupSubHeadingForEditOutput> GetSetupSubHeadingForEdit(EntityDto input)
        {
            var setupSubHeading = await _setupSubHeadingRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSetupSubHeadingForEditOutput { SetupSubHeading = ObjectMapper.Map<CreateOrEditSetupSubHeadingDto>(setupSubHeading) };

            if (output.SetupSubHeading.SectionSetupId != null)
            {
                var _lookupSectionSetup = await _lookup_sectionSetupRepository.FirstOrDefaultAsync((int)output.SetupSubHeading.SectionSetupId);
                output.SectionSetupSection = _lookupSectionSetup?.Section?.ToString();
            }

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSetupSubHeadingDto input)
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

        [AbpAuthorize(AppPermissions.Pages_SetupSubHeadings_Create)]
        protected virtual async Task Create(CreateOrEditSetupSubHeadingDto input)
        {
            var setupSubHeading = ObjectMapper.Map<SetupSubHeading>(input);

            if (AbpSession.TenantId != null)
            {
                setupSubHeading.TenantId = (int?)AbpSession.TenantId;
            }

            await _setupSubHeadingRepository.InsertAsync(setupSubHeading);
        }

        [AbpAuthorize(AppPermissions.Pages_SetupSubHeadings_Edit)]
        protected virtual async Task Update(CreateOrEditSetupSubHeadingDto input)
        {
            var setupSubHeading = await _setupSubHeadingRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, setupSubHeading);
        }

        [AbpAuthorize(AppPermissions.Pages_SetupSubHeadings_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _setupSubHeadingRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSetupSubHeadingsToExcel(GetAllSetupSubHeadingsForExcelInput input)
        {

            var filteredSetupSubHeadings = _setupSubHeadingRepository.GetAll()
                        .Include(e => e.SectionSetupFk)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.SubHeading.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionSetupSectionFilter), e => e.SectionSetupFk != null && e.SectionSetupFk.Section == input.SectionSetupSectionFilter);

            var query = (from o in filteredSetupSubHeadings
                         join o1 in _lookup_sectionSetupRepository.GetAll() on o.SectionSetupId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()

                         select new GetSetupSubHeadingForViewDto()
                         {
                             SetupSubHeading = new SetupSubHeadingDto
                             {
                                 SubHeading = o.SubHeading,
                                 Id = o.Id
                             },
                             SectionSetupSection = s1 == null || s1.Section == null ? "" : s1.Section.ToString()
                         });

            var setupSubHeadingListDtos = await query.ToListAsync();

            return _setupSubHeadingsExcelExporter.ExportToFile(setupSubHeadingListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_SetupSubHeadings)]
        public async Task<List<SetupSubHeadingSectionSetupLookupTableDto>> GetAllSectionSetupForTableDropdown()
        {
            return await _lookup_sectionSetupRepository.GetAll()
                .Select(sectionSetup => new SetupSubHeadingSectionSetupLookupTableDto
                {
                    Id = sectionSetup.Id,
                    DisplayName = sectionSetup == null || sectionSetup.Section == null ? "" : sectionSetup.Section.ToString()
                }).ToListAsync();
        }

    }
}