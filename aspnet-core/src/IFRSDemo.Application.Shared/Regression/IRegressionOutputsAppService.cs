using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.Regression.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.Regression
{
    public interface IRegressionOutputsAppService : IApplicationService
    {
        Task<PagedResultDto<GetRegressionOutputForViewDto>> GetAll(GetAllRegressionOutputsInput input);

        Task<GetRegressionOutputForViewDto> GetRegressionOutputForView(int id);

        Task<GetRegressionOutputForEditOutput> GetRegressionOutputForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditRegressionOutputDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetRegressionOutputsToExcel(GetAllRegressionOutputsForExcelInput input);

    }
}