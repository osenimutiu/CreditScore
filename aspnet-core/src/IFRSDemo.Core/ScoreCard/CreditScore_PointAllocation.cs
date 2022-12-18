using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("CreditScore_PointAllocation")]
    public class CreditScore_PointAllocation : Entity<int>
    {
        public string Attribute { get; set; }
        public string Binning { get; set; }
        public double WOE { get; set; }
        public double Score { get; set; }
    }
}
