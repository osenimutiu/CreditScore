using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using System.Collections.Generic;

namespace IFRSDemo.Cooperate
{
    public interface ISetupSubHeadingsAppService : IApplicationService
    {
        Task<PagedResultDto<GetSetupSubHeadingForViewDto>> GetAll(GetAllSetupSubHeadingsInput input);

        Task<GetSetupSubHeadingForViewDto> GetSetupSubHeadingForView(int id);

        Task<GetSetupSubHeadingForEditOutput> GetSetupSubHeadingForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSetupSubHeadingDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSetupSubHeadingsToExcel(GetAllSetupSubHeadingsForExcelInput input);

        Task<List<SetupSubHeadingSectionSetupLookupTableDto>> GetAllSectionSetupForTableDropdown();

    }
}