﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IAccountBalDataAppService : IApplicationService
    {
        ListResultDto<AccountBalDataListDto> GetAccountBalData(GetAccountBalDataInput input);
    }
}
