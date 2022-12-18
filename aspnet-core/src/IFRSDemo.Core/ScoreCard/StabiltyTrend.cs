using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_StabiltyTrend")]
    public class StabiltyTrend : Entity<int>
    {
        public string Bins { get; set; }
        public int SampleFrequency { get; set; }
        public int RecentFrequency { get; set; }
        public int ThreeMonthFrequency { get; set; }
        public int SixMonthFrequency { get; set; }
        public double SampleFrequencyPerc { get; set; }
        public double RecentFrequencyPerc { get; set; }
        public double ThreeMonthFrequencyPerc { get; set; }
        public double SixMonthFrequencyPerc { get; set; }
    }
}
