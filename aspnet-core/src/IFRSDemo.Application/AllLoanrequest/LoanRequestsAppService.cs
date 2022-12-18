using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using IFRSDemo.AllLoanrequest.Exporting;
using IFRSDemo.AllLoanrequest.Dtos;
using IFRSDemo.Dto;
using Abp.Application.Services.Dto;
using IFRSDemo.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IFRSDemo.AllLoanrequest
{
    [AbpAuthorize(AppPermissions.Pages_LoanRequests)]
    public class LoanRequestsAppService : IFRSDemoAppServiceBase, ILoanRequestsAppService
    {
        private readonly IRepository<LoanRequest> _loanRequestRepository;
        private readonly ILoanRequestsExcelExporter _loanRequestsExcelExporter;

        public LoanRequestsAppService(IRepository<LoanRequest> loanRequestRepository, ILoanRequestsExcelExporter loanRequestsExcelExporter)
        {
            _loanRequestRepository = loanRequestRepository;
            _loanRequestsExcelExporter = loanRequestsExcelExporter;

        }

        public async Task<PagedResultDto<GetLoanRequestForViewDto>> GetAll(GetAllLoanRequestsInput input)
        {

            var filteredLoanRequests = _loanRequestRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Customer.Contains(input.Filter) || e.LoanType.Contains(input.Filter) || e.Statua.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerFilter), e => e.Customer == input.CustomerFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LoanTypeFilter), e => e.LoanType == input.LoanTypeFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinTenorFilter != null, e => e.Tenor >= input.MinTenorFilter)
                        .WhereIf(input.MaxTenorFilter != null, e => e.Tenor <= input.MaxTenorFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StatuaFilter), e => e.Statua == input.StatuaFilter);

            var pagedAndFilteredLoanRequests = filteredLoanRequests
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var loanRequests = from o in pagedAndFilteredLoanRequests
                               select new GetLoanRequestForViewDto()
                               {
                                   LoanRequest = new LoanRequestDto
                                   {
                                       Customer = o.Customer,
                                       LoanType = o.LoanType,
                                       Amount = o.Amount,
                                       Tenor = o.Tenor,
                                       Statua = o.Statua,
                                       Id = o.Id
                                   }
                               };

            var totalCount = await filteredLoanRequests.CountAsync();

            return new PagedResultDto<GetLoanRequestForViewDto>(
                totalCount,
                await loanRequests.ToListAsync()
            );
        }

        public async Task<GetLoanRequestForViewDto> GetLoanRequestForView(int id)
        {
            var loanRequest = await _loanRequestRepository.GetAsync(id);

            var output = new GetLoanRequestForViewDto { LoanRequest = ObjectMapper.Map<LoanRequestDto>(loanRequest) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_LoanRequests_Edit)]
        public async Task<GetLoanRequestForEditOutput> GetLoanRequestForEdit(EntityDto input)
        {
            var loanRequest = await _loanRequestRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetLoanRequestForEditOutput { LoanRequest = ObjectMapper.Map<CreateOrEditLoanRequestDto>(loanRequest) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditLoanRequestDto input)
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

        [AbpAuthorize(AppPermissions.Pages_LoanRequests_Create)]
        protected virtual async Task Create(CreateOrEditLoanRequestDto input)
        {
            var loanRequest = ObjectMapper.Map<LoanRequest>(input);

            if (AbpSession.TenantId != null)
            {
                loanRequest.TenantId = (int?)AbpSession.TenantId;
            }

            await _loanRequestRepository.InsertAsync(loanRequest);
        }

        [AbpAuthorize(AppPermissions.Pages_LoanRequests_Edit)]
        protected virtual async Task Update(CreateOrEditLoanRequestDto input)
        {
            var loanRequest = await _loanRequestRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, loanRequest);
        }

        [AbpAuthorize(AppPermissions.Pages_LoanRequests_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _loanRequestRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetLoanRequestsToExcel(GetAllLoanRequestsForExcelInput input)
        {

            var filteredLoanRequests = _loanRequestRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Customer.Contains(input.Filter) || e.LoanType.Contains(input.Filter) || e.Statua.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CustomerFilter), e => e.Customer == input.CustomerFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.LoanTypeFilter), e => e.LoanType == input.LoanTypeFilter)
                        .WhereIf(input.MinAmountFilter != null, e => e.Amount >= input.MinAmountFilter)
                        .WhereIf(input.MaxAmountFilter != null, e => e.Amount <= input.MaxAmountFilter)
                        .WhereIf(input.MinTenorFilter != null, e => e.Tenor >= input.MinTenorFilter)
                        .WhereIf(input.MaxTenorFilter != null, e => e.Tenor <= input.MaxTenorFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.StatuaFilter), e => e.Statua == input.StatuaFilter);

            var query = (from o in filteredLoanRequests
                         select new GetLoanRequestForViewDto()
                         {
                             LoanRequest = new LoanRequestDto
                             {
                                 Customer = o.Customer,
                                 LoanType = o.LoanType,
                                 Amount = o.Amount,
                                 Tenor = o.Tenor,
                                 Statua = o.Statua,
                                 Id = o.Id
                             }
                         });

            var loanRequestListDtos = await query.ToListAsync();

            return _loanRequestsExcelExporter.ExportToFile(loanRequestListDtos);
        }

    }
}