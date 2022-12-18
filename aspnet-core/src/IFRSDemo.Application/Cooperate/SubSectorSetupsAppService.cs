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
    [AbpAuthorize(AppPermissions.Pages_SubSectorSetups)]
    public class SubSectorSetupsAppService : IFRSDemoAppServiceBase, ISubSectorSetupsAppService
    {
        private readonly IRepository<SubSectorSetup> _subSectorSetupRepository;
        private readonly ISubSectorSetupsExcelExporter _subSectorSetupsExcelExporter;

        public SubSectorSetupsAppService(IRepository<SubSectorSetup> subSectorSetupRepository, ISubSectorSetupsExcelExporter subSectorSetupsExcelExporter)
        {
            _subSectorSetupRepository = subSectorSetupRepository;
            _subSectorSetupsExcelExporter = subSectorSetupsExcelExporter;

        }

        public async Task<PagedResultDto<GetSubSectorSetupForViewDto>> GetAll(GetAllSubSectorSetupsInput input)
        {

            var filteredSubSectorSetups = _subSectorSetupRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Section.Contains(input.Filter) || e.SubHeading.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionFilter), e => e.Section == input.SectionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter);

            var pagedAndFilteredSubSectorSetups = filteredSubSectorSetups
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var subSectorSetups = from o in pagedAndFilteredSubSectorSetups
                                  select new GetSubSectorSetupForViewDto()
                                  {
                                      SubSectorSetup = new SubSectorSetupDto
                                      {
                                          Section = o.Section,
                                          SubHeading = o.SubHeading,
                                          Id = o.Id
                                      }
                                  };

            var totalCount = await filteredSubSectorSetups.CountAsync();

            return new PagedResultDto<GetSubSectorSetupForViewDto>(
                totalCount,
                await subSectorSetups.ToListAsync()
            );
        }

        public async Task<GetSubSectorSetupForViewDto> GetSubSectorSetupForView(int id)
        {
            var subSectorSetup = await _subSectorSetupRepository.GetAsync(id);

            var output = new GetSubSectorSetupForViewDto { SubSectorSetup = ObjectMapper.Map<SubSectorSetupDto>(subSectorSetup) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_SubSectorSetups_Edit)]
        public async Task<GetSubSectorSetupForEditOutput> GetSubSectorSetupForEdit(EntityDto input)
        {
            var subSectorSetup = await _subSectorSetupRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetSubSectorSetupForEditOutput { SubSectorSetup = ObjectMapper.Map<CreateOrEditSubSectorSetupDto>(subSectorSetup) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditSubSectorSetupDto input)
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

        [AbpAuthorize(AppPermissions.Pages_SubSectorSetups_Create)]
        protected virtual async Task Create(CreateOrEditSubSectorSetupDto input)
        {
            var subSectorSetup = ObjectMapper.Map<SubSectorSetup>(input);

            if (AbpSession.TenantId != null)
            {
                subSectorSetup.TenantId = (int?)AbpSession.TenantId;
            }

            await _subSectorSetupRepository.InsertAsync(subSectorSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_SubSectorSetups_Edit)]
        protected virtual async Task Update(CreateOrEditSubSectorSetupDto input)
        {
            var subSectorSetup = await _subSectorSetupRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, subSectorSetup);
        }

        [AbpAuthorize(AppPermissions.Pages_SubSectorSetups_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _subSectorSetupRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetSubSectorSetupsToExcel(GetAllSubSectorSetupsForExcelInput input)
        {

            var filteredSubSectorSetups = _subSectorSetupRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Section.Contains(input.Filter) || e.SubHeading.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SectionFilter), e => e.Section == input.SectionFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubHeadingFilter), e => e.SubHeading == input.SubHeadingFilter);

            var query = (from o in filteredSubSectorSetups
                         select new GetSubSectorSetupForViewDto()
                         {
                             SubSectorSetup = new SubSectorSetupDto
                             {
                                 Section = o.Section,
                                 SubHeading = o.SubHeading,
                                 Id = o.Id
                             }
                         });

            var subSectorSetupListDtos = await query.ToListAsync();

            return _subSectorSetupsExcelExporter.ExportToFile(subSectorSetupListDtos);
        }

    }
}