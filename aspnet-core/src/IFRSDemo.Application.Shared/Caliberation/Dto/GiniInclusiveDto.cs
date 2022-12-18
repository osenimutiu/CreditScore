using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.Caliberation.Dto
{
    public class GiniInclusiveDto : EntityDto
    {
        public bool Good_Bad { get; set; }
        public double? Score { get; set; }
        public int? CumNoDefaulters { get; set; }
        public int? CumNoApplicants { get; set; }
        public double? CumPercDefaulters { get; set; }
        public double? CumPercApplicants { get; set; }
        public double? AreaUnderCAP { get; set; }
        public double? Y_fit { get; set; }
        public double? Residual { get; set; }
        public double? ResSquare { get; set; }
    }

    public  class CalibrationCDto : EntityDto
    {
        public string Rating { get; set; }
        public double PercPD_real { get; set; }
        public double PD_real { get; set; }
        public int NOC { get; set; }
        public int NOD { get; set; }
        public string ScoreRanges { get; set; }
        public double Odds { get; set; }
        public double PercPD_Odds { get; set; }
        public double PD_Odds { get; set; }
        public double Xr { get; set; }
        public double PercPD_est { get; set; }
        public double PD_est { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public bool BinomialTestSP { get; set; }
        public bool BinomialTestOdds { get; set; }
    }

    public class CreateSetUPDto
    {
        public double CreditScoreWeight { get; set; }
        public double QualitativeAnalysisWeight { get; set; }
    }
    public class SetuPPageDto : EntityDto
    {
        public double CreditScoreWeight { get; set; }
        public double QualitativeAnalysisWeight { get; set; }
    }

    public class VintageAnalysisDto : EntityDto
    {
        public DateTime FullDate { get; set; }
        public string FullYear { get; set; }
        public string FullMonth { get; set; }
        public int FullCount { get; set; }
        public double Q1 { get; set; }
        public double Q2 { get; set; }
        public double Q3 { get; set; }
        public double Q4 { get; set; }
        public double Q5 { get; set; }
        public double Q6 { get; set; }
        public double Q7 { get; set; }
        public double Q8 { get; set; }
        public double Q9 { get; set; }
        public double Q10 { get; set; }
        public double Q11 { get; set; }
        public double Q12 { get; set; }
    }
}
