using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Cooperate.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Cooperate
{
    public interface IQualitativeSetupsAppService : IApplicationService
    {
        Task<PagedResultDto<GetQualitativeSetupForViewDto>> GetAll(GetAllQualitativeSetupsInput input);

        Task<GetQualitativeSetupForViewDto> GetQualitativeSetupForView(int id);

        Task<GetQualitativeSetupForEditOutput> GetQualitativeSetupForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditQualitativeSetupDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetQualitativeSetupsToExcel(GetAllQualitativeSetupsForExcelInput input);

    }
}