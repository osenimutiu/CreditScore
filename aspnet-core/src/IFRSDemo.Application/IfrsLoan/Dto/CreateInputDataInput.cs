using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapTo(typeof(InputData))]
    public class CreateInputDataInput
    {
        public string Attributes { get; set; }
      
    }

    [AutoMapFrom(typeof(InputData))]
    public class InputDataListDto : FullAuditedEntityDto
    {
        public string Attributes { get; set; }
       

    }
    public class GetInputDataInput 
    {
        public string Filter { get; set; }
    }
}
