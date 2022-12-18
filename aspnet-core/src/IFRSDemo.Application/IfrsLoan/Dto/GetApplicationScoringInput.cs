using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class GetApplicationScoringInput
    {
        public string Filter { get; set; }
        public string ApplicanFilter { get; set; }
        public string Applicant_With_AccnoFilter { get; set; }
        public string LoanRequestFilter { get; set; }
        public string AppAttributeFilter { get; set; }
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
