using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.SetUp.Dto
{
    
    public class MethodListDto : EntityDto
    {
        public string MethodName { get; set; }
    }
	public class SplittingMethodListDto : EntityDto
    {
        public string MethodName { get; set; }
    }
    public class AgeRangeDto : EntityDto
    {
        public string Age { get; set; }
    }
}
