using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.LogisticRegression
{
    [Table("CreditScore_LogisticRegression")]
    public class LogisticRegressionOutput : Entity<int>
    {
        public double coefficients { get; set; }
        public string name { get; set; }
    }
}
