using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.LogisticRegression.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.LogisticRegression
{
    public interface ILogisticRegressionInputsAppService : IApplicationService
    {
        Task<PagedResultDto<GetLogisticRegressionInputForViewDto>> GetAll(GetAllLogisticRegressionInputsInput input);

        Task<GetLogisticRegressionInputForViewDto> GetLogisticRegressionInputForView(int id);

        Task<GetLogisticRegressionInputForEditOutput> GetLogisticRegressionInputForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLogisticRegressionInputDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetLogisticRegressionInputsToExcel(GetAllLogisticRegressionInputsForExcelInput input);

    }
}