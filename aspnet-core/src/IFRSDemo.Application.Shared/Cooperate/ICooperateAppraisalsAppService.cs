using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Cooperate
{
    public interface ICooperateAppraisalsAppService : IApplicationService
    {
        Task<PagedResultDto<GetCooperateAppraisalForViewDto>> GetAll(GetAllCooperateAppraisalsInput input);

        Task<GetCooperateAppraisalForViewDto> GetCooperateAppraisalForView(int id);

        Task<GetCooperateAppraisalForEditOutput> GetCooperateAppraisalForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditCooperateAppraisalDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetCooperateAppraisalsToExcel(GetAllCooperateAppraisalsForExcelInput input);

        Task<PagedResultDto<CooperateAppraisalSetupQualitativeLookupTableDto>> GetAllSetupQualitativeForLookupTable(GetAllForLookupTableInput input);

    }
}