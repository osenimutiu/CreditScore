using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class GetAllApplicationScoringInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string ApplicantFilter { get; set; }
        public string LoanRequestFilter { get; set; }
        public string AmountFilter { get; set; }
        public string TenorMonthFilter { get; set; }
        public string AgeAttributeFilter { get; set; }
        public string ProductTypeAttributeFilter { get; set; }
        public string IncomeAttributeFilter { get; set; }
        public string LocationAttributeFilter { get; set; }
        public string RentAttributeFilter { get; set; }
        public string RenttoIncomeAttributeFilter { get; set; }
        public string ReturnonAssetsAttributeFilter { get; set; }
        public string SubSectorAttributeFilter { get; set; }
        public string ExtraParam1Filter { get; set; }
        public string ExtraParam2Filter { get; set; }
    }
}
