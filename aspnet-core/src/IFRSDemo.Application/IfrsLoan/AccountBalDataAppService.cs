using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using System.Linq;
using System;
using System.Collections.Generic;
using Abp.Linq.Extensions;
using Abp.Authorization;
using IFRSDemo.Authorization;
using System.Text;
using IFRSDemo.IfrsLoan.Dto;

namespace IFRSDemo.IfrsLoan
{
   public class AccountBalDataAppService : IFRSDemoAppServiceBase, IAccountBalDataAppService
    {
        private readonly IRepository<AccountBalData> _accountBalDataRepository;
        public AccountBalDataAppService(IRepository<AccountBalData> accountBalDataRepository)
        {
            _accountBalDataRepository = accountBalDataRepository;
        }
        public ListResultDto<AccountBalDataListDto> GetAccountBalData(GetAccountBalDataInput input)
        {
            var accountBalData = _accountBalDataRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Name.Contains(input.Filter) ||
                        p.Age.ToString().Contains(input.Filter) ||
                        p.Income.ToString().Contains(input.Filter) ||
                        p.Rent_Range.ToString().Contains(input.Filter) ||
                        p.Rent_Income.ToString().Contains(input.Filter) ||
                        p.ROA.ToString().Contains(input.Filter) ||
                        p.Sector.ToString().Contains(input.Filter) ||
                        p.Location.ToString().Contains(input.Filter) ||
                        p.DTSR.ToString().Contains(input.Filter) ||
                        p.OutBal.ToString().Contains(input.Filter) ||
                        p.coverage.ToString().Contains(input.Filter) ||
                        p.bal_other_fi.ToString().Contains(input.Filter) 

               )
               .OrderBy(p => p.Name)
               .ThenBy(p => p.Age)
               .ToList();

            return new ListResultDto<AccountBalDataListDto>(ObjectMapper.Map<List<AccountBalDataListDto>>(accountBalData));

        }

    }
}
