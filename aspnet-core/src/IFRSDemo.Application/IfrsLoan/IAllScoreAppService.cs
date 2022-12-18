using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.IfrsLoan.Dto;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IAllScoreAppService : IApplicationService
    {
        ListResultDto<AllScoreListDto> GetAllScore(GetAllScoreInput input);
    }
}
