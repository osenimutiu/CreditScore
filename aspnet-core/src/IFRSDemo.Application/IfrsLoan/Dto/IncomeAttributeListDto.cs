using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(IncomeAttribute))]
    public class IncomeAttributeListDto : FullAuditedEntityDto
    {
        public string IncomeRange { get; set; }
    }
}
