using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Cooperate
{
    public interface ISubSectorSetupsAppService : IApplicationService
    {
        Task<PagedResultDto<GetSubSectorSetupForViewDto>> GetAll(GetAllSubSectorSetupsInput input);

        Task<GetSubSectorSetupForViewDto> GetSubSectorSetupForView(int id);

        Task<GetSubSectorSetupForEditOutput> GetSubSectorSetupForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditSubSectorSetupDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetSubSectorSetupsToExcel(GetAllSubSectorSetupsForExcelInput input);

    }
}