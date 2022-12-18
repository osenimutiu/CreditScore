using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.UserLoanRequest.Dtos;
using IFRSDemo.Dto;

namespace IFRSDemo.UserLoanRequest
{
    public interface IULoanRequestsAppService : IApplicationService
    {
        Task<PagedResultDto<GetULoanRequestForViewDto>> GetAll(GetAllULoanRequestsInput input);

        Task<GetULoanRequestForViewDto> GetULoanRequestForView(int id);

        Task<GetULoanRequestForEditOutput> GetULoanRequestForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditULoanRequestDto input);

        Task Delete(EntityDto input);

    }
}