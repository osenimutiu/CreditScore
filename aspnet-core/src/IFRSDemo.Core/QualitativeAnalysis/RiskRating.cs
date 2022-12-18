using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
    [Table("Tbl_ObligorRiskRating")]
    public class RiskRating : Entity<int>
    {
        [Column(TypeName = "varchar(200)")]
        public string Category { get; set; }
        public string Option { get; set; }
        public int Score { get; set; }
    }
    public class CreateProfit_Analysis : Entity<int>
    {
        public decimal? AverageLoan { get; set; }
        public decimal? Profit { get; set; }
        public int? Loss { get; set; }
        public int? TotalGood { get; set; }
        public int? TotalBad { get; set; }
    }

}
