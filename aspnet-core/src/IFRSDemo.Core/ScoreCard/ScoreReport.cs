using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("CreditScore_ScoreReport")]
    public class ScoreReport : Entity<int>
    {
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public string Value { get; set; }
        public double Score { get; set; }
    }
}
