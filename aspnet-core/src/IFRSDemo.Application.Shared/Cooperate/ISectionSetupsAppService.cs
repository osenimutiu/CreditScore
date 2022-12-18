using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Cooperate
{
    public interface ISectionSetupsAppService : IApplicationService
    {
        Task<PagedResultDto<GetSectionSetupForViewDto>> GetAll(GetAllSectionSetupsInput input);
        //List<SectionSetupDto> GetAll();

        Task<GetSectionSetupForViewDto> GetSectionSetupForView(int id);

        Task<GetSectionSetupForEditOutput> GetSectionSetupForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSectionSetupDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSectionSetupsToExcel(GetAllSectionSetupsForExcelInput input);

    }
}