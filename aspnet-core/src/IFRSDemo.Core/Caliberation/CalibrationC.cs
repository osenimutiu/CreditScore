using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Caliberation
{
    [Table("Tbl_ScoretoRating")]
    public class CalibrationC : Entity<int>
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

    public class SetupPage : Entity<int>
    {
        public double CreditScoreWeight { get; set; }
        public double QualitativeAnalysisWeight { get; set; }
    }
}
