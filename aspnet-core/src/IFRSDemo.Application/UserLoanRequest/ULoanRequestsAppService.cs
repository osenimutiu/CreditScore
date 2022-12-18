using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using IFRSDemo.UserLoanRequest.Dtos;
using IFRSDemo.Dto;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.UserLoanRequest
{
    [AbpAuthorize(AppPermissions.Pages_ULoanRequests)]
    public class ULoanRequestsAppService : IFRSDemoAppServiceBase, IULoanRequestsAppService
    {
        private readonly IRepository<ULoanRequest> _uLoanRequestRepository;

        public ULoanRequestsAppService(IRepository<ULoanRequest> uLoanRequestRepository)
        {
            _uLoanRequestRepository = uLoanRequestRepository;

        }

        public async Task<PagedResultDto<GetULoanRequestForViewDto>> GetAll(GetAllULoanRequestsInput input)
        {

            var filteredULoanRequests = _uLoanRequestRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.LoanType.Contains(input.Filter) || e.Status.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LoanTypeFilter), e => e.LoanType == input.LoanTypeFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinTenorFilter != null, e => e.Tenor >= input.MinTenorFilter)
                        .WhereIf(input.MaxTenorFilter != null, e => e.Tenor <= input.MaxTenorFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StatusFilter), e => e.Status == input.StatusFilter);

            var pagedAndFilteredULoanRequests = filteredULoanRequests
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var uLoanRequests = from o in pagedAndFilteredULoanRequests
                                select new GetULoanRequestForViewDto()
                                {
                                    ULoanRequest = new ULoanRequestDto
                                    {
                                        LoanType = o.LoanType,
                                        Amount = o.Amount,
                                        Tenor = o.Tenor,
                                        Status = o.Status,
                                        Id = o.Id
                                    }
                                };

            var totalCount = await filteredULoanRequests.CountAsync();

            return new PagedResultDto<GetULoanRequestForViewDto>(
                totalCount,
                await uLoanRequests.ToListAsync()
            );
        }

        public async Task<GetULoanRequestForViewDto> GetULoanRequestForView(int id)
        {
            var uLoanRequest = await _uLoanRequestRepository.GetAsync(id);

            var output = new GetULoanRequestForViewDto { ULoanRequest = ObjectMapper.Map<ULoanRequestDto>(uLoanRequest) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_ULoanRequests_Edit)]
        public async Task<GetULoanRequestForEditOutput> GetULoanRequestForEdit(EntityDto input)
        {
            var uLoanRequest = await _uLoanRequestRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetULoanRequestForEditOutput { ULoanRequest = ObjectMapper.Map<CreateOrEditULoanRequestDto>(uLoanRequest) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditULoanRequestDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_ULoanRequests_Create)]
        protected virtual async Task Create(CreateOrEditULoanRequestDto input)
        {
            var uLoanRequest = ObjectMapper.Map<ULoanRequest>(input);

            if (AbpSession.TenantId != null)
            {
                uLoanRequest.TenantId = (int?)AbpSession.TenantId;
            }

            await _uLoanRequestRepository.InsertAsync(uLoanRequest);
        }

        [AbpAuthorize(AppPermissions.Pages_ULoanRequests_Edit)]
        protected virtual async Task Update(CreateOrEditULoanRequestDto input)
        {
            var uLoanRequest = await _uLoanRequestRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, uLoanRequest);
        }

        [AbpAuthorize(AppPermissions.Pages_ULoanRequests_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _uLoanRequestRepository.DeleteAsync(input.Id);
        }
    }
}