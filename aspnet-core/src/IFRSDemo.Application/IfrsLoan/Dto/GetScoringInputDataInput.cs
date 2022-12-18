using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using IFRSDemo.Dto;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class GetScoringInputDataInput : PagedAndSortedInputDto
    {
        public string Filter { get; set; }
       public string UniqueIDFilter { get; set; }
       
  
    }
}
