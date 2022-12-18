using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_CurrentAccStatusDistribution")]
    public class CurrentAccDist : Entity<int>
    {
        public string AgeBins { get; set; }
        public double Weight { get; set; }
        public double Score { get; set; }
    }
}
