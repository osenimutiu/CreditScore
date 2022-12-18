using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class GetInputDataValueCollectorInput : PagedAndSortedResultRequestDto 
    {
        public string Filter { get; set; }
    }
}
