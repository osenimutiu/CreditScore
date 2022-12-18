using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;
using System.Collections.Generic;

namespace IFRSDemo.Cooperate
{
    public interface ISubHeadingSetupsAppService : IApplicationService
    {
        Task<PagedResultDto<GetSubHeadingSetupForViewDto>> GetAll(GetAllSubHeadingSetupsInput input);

        Task<GetSubHeadingSetupForViewDto> GetSubHeadingSetupForView(int id);

        Task<GetSubHeadingSetupForEditOutput> GetSubHeadingSetupForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSubHeadingSetupDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSubHeadingSetupsToExcel(GetAllSubHeadingSetupsForExcelInput input);

        Task<List<SubHeadingSetupSectionSetupLookupTableDto>> GetAllSectionSetupForTableDropdown();

    }
}