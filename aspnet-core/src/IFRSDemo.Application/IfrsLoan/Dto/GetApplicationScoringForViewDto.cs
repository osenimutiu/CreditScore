using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
   public class GetApplicationScoringForViewDto
    {
        public ApplicationScoringDto ApplicationScoring { get; set; }

        public string ApplicationScoringTypeAgeGroup { get; set; }
        public string ApplicationScoringTypeLocationGroup { get; set; }
        public string ApplicationScoringProductType { get; set; }
        public string ApplicationScoringTypeIncomeRange { get; set; }
        public string ApplicationScoringTypeRentGroup { get; set; }
        public string ApplicationScoringTypeRentToIncomeGroup { get; set; }
        public string ApplicationScoringTypeReturnonAssets { get; set; }
        public string ApplicationScoringTypeSectorGroup { get; set; }

    }
}
