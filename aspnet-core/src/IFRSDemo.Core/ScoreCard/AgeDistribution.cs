using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_AgeDistribution")]
    public class AgeDistribution : Entity<int>
    {
        public string AgeBins { get; set; }
        public double Weight { get; set; }
        public double Score { get; set; }
    }
}
