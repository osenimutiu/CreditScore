using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_ProfitAnalysis")]
    public class ProfitAnalysis : Entity<int>
    {
        public double CutOff { get; set; }
        public double TPCount { get; set; }
        public double FPCount { get; set; }
        public double Profit { get; set; }
        public double ModelDifference { get; set; }
    }
}
