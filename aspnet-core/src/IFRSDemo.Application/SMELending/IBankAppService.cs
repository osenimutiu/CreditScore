using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.SMELending.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IFRSDemo.SMELending
{
   public interface IBankAppService : IApplicationService
    {
        Task<PagedResultDto<BankListDto>> GetBank(GetBankInput input);
    }
}
