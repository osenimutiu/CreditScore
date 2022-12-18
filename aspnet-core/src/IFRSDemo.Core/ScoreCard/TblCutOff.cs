using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("CreditScore_CutOff")]
    public class TblCutOff : Entity<int>
    {
        public double? CutOff { get; set; }
    }

    public class TblScoreReport : Entity<int>
    {
        public string CustomerName { get; set; }
        public string AccountNumber { get; set; }
        public double? TotalScore { get; set; }
        public string QualitativeRating { get; set; }
    }
}
