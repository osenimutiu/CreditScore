using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.AllLoanrequest.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.AllLoanrequest
{
    public interface ILoanRequestsAppService : IApplicationService
    {
        Task<PagedResultDto<GetLoanRequestForViewDto>> GetAll(GetAllLoanRequestsInput input);

        Task<GetLoanRequestForViewDto> GetLoanRequestForView(int id);

        Task<GetLoanRequestForEditOutput> GetLoanRequestForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditLoanRequestDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetLoanRequestsToExcel(GetAllLoanRequestsForExcelInput input);

    }
}