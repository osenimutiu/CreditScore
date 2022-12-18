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
    [AbpAuthorize(AppPermissions.Pages_SectionSetups)]
    public class SectionSetupsAppService : IFRSDemoAppServiceBase, ISectionSetupsAppService
    {
        private readonly IRepository<SectionSetup> _sectionSetupRepository;
        private readonly ISectionSetupsExcelExporter _sectionSetupsExcelExporter;

        public SectionSetupsAppService(IRepository<SectionSetup> sectionSetupRepository, ISectionSetupsExcelExporter sectionSetupsExcelExporter)
        {
            _sectionSetupRepository = sectionSetupRepository;
            _sectionSetupsExcelExporter = sectionSetupsExcelExporter;

        }

        public async Task<PagedResultDto<GetSectionSetupForViewDto>> GetAll(GetAllSectionSetupsInput input)
        {

            var filteredSectionSetups = _sectionSetupRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Section.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionFilter), e => e.Section == input.SectionFilter)
                        .WhereIf(input.MinPositionFilter != null, e => e.Position >= input.MinPositionFilter)
                        .WhereIf(input.MaxPositionFilter != null, e => e.Position <= input.MaxPositionFilter)
                        .WhereIf(input.ActiveFilter.HasValue && input.ActiveFilter > -1, e => (input.ActiveFilter == 1 && e.Active) || (input.ActiveFilter == 0 && !e.Active));

            var pagedAndFilteredSectionSetups = filteredSectionSetups
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var sectionSetups = from o in pagedAndFilteredSectionSetups
                                select new GetSectionSetupForViewDto()
                                {
                                    SectionSetup = new SectionSetupDto
                                    {
                                        Section = o.Section,
                                        Position = o.Position,
                                        Active = o.Active,
                                        Id = o.Id
                                    }
                                };

            var totalCount = await filteredSectionSetups.CountAsync();

            return new PagedResultDto<GetSectionSetupForViewDto>(
                totalCount,
                await sectionSetups.ToListAsync()
            );
        }

        //public List<SectionSetupDto> GetAll()
        //{
        //    var result = from o in _sectionSetupRepository.GetAll() select new SectionSetupDto()
        //    {
        //        Section = o.Section,
        //        Position = o.Position,
        //        Active = o.Active,
        //        Id = o.Id
        //    };
        //    int count = result.Count();
        //    return result.ToList();

        //}

        public async Task<GetSectionSetupForViewDto> GetSectionSetupForView(int id)
        {
            var sectionSetup = await _sectionSetupRepository.GetAsync(id);

            var output = new GetSectionSetupForViewDto { SectionSetup = ObjectMapper.Map<SectionSetupDto>(sectionSetup) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_SectionSetups_Edit)]
        public async Task<GetSectionSetupForEditOutput> GetSectionSetupForEdit(EntityDto input)
        {
            var sectionSetup = await _sectionSetupRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSectionSetupForEditOutput { SectionSetup = ObjectMapper.Map<CreateOrEditSectionSetupDto>(sectionSetup) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSectionSetupDto input)
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

        [AbpAuthorize(AppPermissions.Pages_SectionSetups_Create)]
        protected virtual async Task Create(CreateOrEditSectionSetupDto input)
        {
            var sectionSetup = ObjectMapper.Map<SectionSetup>(input);

            if (AbpSession.TenantId != null)
            {
                sectionSetup.TenantId = (int?)AbpSession.TenantId;
            }

            await _sectionSetupRepository.InsertAsync(sectionSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_SectionSetups_Edit)]
        protected virtual async Task Update(CreateOrEditSectionSetupDto input)
        {
            var sectionSetup = await _sectionSetupRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, sectionSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_SectionSetups_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _sectionSetupRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSectionSetupsToExcel(GetAllSectionSetupsForExcelInput input)
        {

            var filteredSectionSetups = _sectionSetupRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Section.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionFilter), e => e.Section == input.SectionFilter)
                        .WhereIf(input.MinPositionFilter != null, e => e.Position >= input.MinPositionFilter)
                        .WhereIf(input.MaxPositionFilter != null, e => e.Position <= input.MaxPositionFilter)
                        .WhereIf(input.ActiveFilter.HasValue && input.ActiveFilter > -1, e => (input.ActiveFilter == 1 && e.Active) || (input.ActiveFilter == 0 && !e.Active));

            var query = (from o in filteredSectionSetups
                         select new GetSectionSetupForViewDto()
                         {
                             SectionSetup = new SectionSetupDto
                             {
                                 Section = o.Section,
                                 Position = o.Position,
                                 Active = o.Active,
                                 Id = o.Id
                             }
                         });

            var sectionSetupListDtos = await query.ToListAsync();

            return _sectionSetupsExcelExporter.ExportToFile(sectionSetupListDtos);
        }

    }
}