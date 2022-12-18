using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SMELending.Dtos
{
    [AutoMapFrom(typeof(Operation_Eligibility))]
    public class OperationEligibilityListDto : EntityDto
    {
        public string Option { get; set; }
    }
    public class GetOperationEligibilityInput
    {
        public string Filter { get; set; }
    }
}
