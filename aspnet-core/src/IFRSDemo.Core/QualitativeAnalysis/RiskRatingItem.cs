using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
    public class RiskRatingItem : Entity<int>
    {
        public int Position { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Category { get; set; }
        public string Option { get; set; }
        public int Score { get; set; }
    }

    public class PositionInIdustry : Entity<int>
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class Ownership : Entity<int>
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class ProductCont : Entity<int>
    {
        public string Option { get; set; }
        public int Score { get; set; }
    } 
    public class Legal : Entity<int>
    {
        public string Option { get; set; }
        public int Score { get; set; }
    }
}
