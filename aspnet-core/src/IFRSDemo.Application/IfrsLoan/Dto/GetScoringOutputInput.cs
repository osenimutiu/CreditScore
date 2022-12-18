using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class GetScoringOutputInput 
    {
        public string Filter { get; set; }
        public string App_TypeFilter { get; set; }
    }
}
