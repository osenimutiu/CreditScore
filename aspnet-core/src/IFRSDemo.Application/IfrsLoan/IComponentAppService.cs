using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IFRSDemo.IfrsLoan;
using IFRSDemo.IfrsLoan.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
   public interface IComponentAppService : IApplicationService
    {
        ListResultDto<ComponentListDto> GetComponent(GetComponentInput input);
    }
}
