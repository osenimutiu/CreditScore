using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Linq;
using Abp.Linq.Extensions;
using IFRSDemo.SMELending.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Runtime.Session;

namespace IFRSDemo.SMELending
{
   public class SMELendingApplyAppService : IFRSDemoAppServiceBase, ISMELendingApplyAppService
    {
        private readonly IRepository<SMELendingApply> _sMELendingRepository;
        
        private readonly IRepository<LoanType> _loanType;
        private readonly IRepository<Bank> _bankName;
        private readonly IAbpSession _abp;
        public SMELendingApplyAppService(IRepository<SMELendingApply> sMELendingRepository, IRepository<LoanType> loanType, IAbpSession abp, IRepository<Bank> bankName)
        {
            _sMELendingRepository = sMELendingRepository;
            _abp = abp;
            _loanType = loanType;
            _bankName = bankName;
        }

        public async Task<PagedResultDto<SMELendingApplyListDto>> GetSMELendingApply(GetSMELendingApplyInput input)
        {
            var filteredInventories = _sMELendingRepository.GetAll()
                        .Include(e => e.LoanTypeFK)
                        .Include(e => e.BankFK)
                        .WhereIf(
                        !input.Filter.IsNullOrEmpty(),
                        p => p.ApplicatioNo.ToString().Contains(input.Filter) ||
                        p.BusinessName.Contains(input.Filter) ||
                             p.LoanTypeId.ToString().Contains(input.Filter) ||
                             p.LoanAmount.ToString().Contains(input.Filter) ||
                             p.LoanTenor.ToString().Contains(input.Filter) ||
                             p.Bvn.Contains(input.Filter) ||
                             p.Email.Contains(input.Filter) ||
                             p.Password.Contains(input.Filter) ||
                             p.TitleId.ToString().Contains(input.Filter) ||
                             p.BusinessAccountNo.Contains(input.Filter) ||
                             p.FirstName.Contains(input.Filter) ||
                             p.LastName.Contains(input.Filter) ||
                             p.MiddleName.Contains(input.Filter) ||
                             p.DateOfBirth.Contains(input.Filter) ||
                             p.GenderId.ToString().Contains(input.Filter) ||
                             p.Phone.Contains(input.Filter) ||
                             p.BankId.ToString().Contains(input.Filter) ||
                             p.BusinessAccountNo.Contains(input.Filter))
                            .WhereIf(!string.IsNullOrWhiteSpace(input.BusinessNameFilter), e => e.BusinessName == input.BusinessNameFilter);
                 
            var pagedAndFilteredInventories = filteredInventories;
                //.OrderBy(input.Sorting ?? "id asc")
                //.PageBy(input);
            var inventories = from o in pagedAndFilteredInventories
                              join o1 in _loanType.GetAll() on o.LoanTypeId equals o1.Id into j2
                              from s2 in j2.DefaultIfEmpty()
                              join o2 in _bankName.GetAll() on o.BankId equals o2.Id into j3
                              from s3 in j3.DefaultIfEmpty()



                              select new SMELendingApplyListDto()
                              {
                                  ApplicatioNo = o.ApplicatioNo,
                                  BusinessName = o.BusinessName,
                                  LoanTypeId = o.LoanTypeId,
                                  LoanAmount = o.LoanAmount,
                                  LoanTenor = o.LoanTenor,
                                  Bvn = o.Bvn,
                                  Email = o.Email,
                                  Password = o.Password,
                                  TitleId = o.TitleId,
                                  BusinessAccountNo = o.BusinessAccountNo,
                                  FirstName = o.FirstName,
                                  LastName = o.LastName,
                                  MiddleName = o.MiddleName,
                                  DateOfBirth = o.DateOfBirth,
                                  GenderId = o.GenderId,
                                  Phone = o.Phone,
                                  BankId = o.BankId,
                                  BankAccountNo = o.BankAccountNo,
                                  Id = o.Id,
                                  LoanTypeDescription = s2 == null || s2.LoanTypes == null ? "" : s2.LoanTypes.ToString(),
                                  BankSelection = s3 == null || s3.BankNames == null ? "" : s3.BankNames.ToString()
                              };

            var totalCount = await filteredInventories.CountAsync();


            return new PagedResultDto<SMELendingApplyListDto>(
                totalCount,
                await inventories.ToListAsync()
            );
        }
        public async Task CreateSMELendingApply(CreateSMELendingApplyInput input)
        {
            input.TenantId = _abp.GetTenantId();
            var sMELending = ObjectMapper.Map<SMELendingApply>(input);
            await _sMELendingRepository.InsertAsync(sMELending);
        }

        public async Task<SMELendingApplyListDto> GetSMELendingApplyForView(int id)
        {
            var input = await _sMELendingRepository.GetAsync(id);

            //var output = new GetApplicationScoringForViewDto { ApplicationScoring = ObjectMapper.Map<ApplicationScoringDto>(inventory) };
            var sMELending = ObjectMapper.Map<SMELendingApplyListDto>(input);
         
            if (input.LoanTypeId != null)
            {
                var loanType = await _loanType.FirstOrDefaultAsync((int)sMELending.LoanTypeId);
                sMELending.LoanTypeDescription = loanType?.LoanTypes?.ToString();
            }

            if (input.BankId != null)
            {
                var bankType = await _bankName.FirstOrDefaultAsync((int)sMELending.BankId);
                sMELending.LoanTypeDescription = bankType?.BankNames?.ToString();
            }
            return sMELending;
        }
        public async Task DeleteSMELendingApply(EntityDto input)
        {
            await _sMELendingRepository.DeleteAsync(input.Id);
        }

    }
}
