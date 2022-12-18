using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Caliberation
{
    [Table("Tbl_VintageAnalysis")]
    public class VintageAnalysis : Entity<int>
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
