using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
    [Table("Tbl_QualitativeAnalysis")]
    public class Tbl_QualitativeAnalysis : Entity<int>
    {
        public string Attribute { get; set; }
        public int Weight { get; set; }
        public double Percentage { get; set; }
        public int MaxScore { get; set; }
        public string Value { get; set; }
        public int AttributeScore { get; set; }
        public int WeightedAttribute { get; set; }
    }
    public class tbl_score : Entity<int>
    {
        public string CustomerName { get; set; }
        public int Score { get; set; }
    }
}
