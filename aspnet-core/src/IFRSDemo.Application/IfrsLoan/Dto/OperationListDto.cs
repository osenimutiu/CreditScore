using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(Operation))]
    public class OperationListDto : FullAuditedEntityDto
    {
        public string OperationName { get; set; }
    }
}
