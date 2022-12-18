using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("CreditScore_WOE")]
    public class CreditScoreWOE : Entity<int>
    {
        [Column(TypeName = "varchar(250)")]
        public string Characteristic { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Attribute { get; set; }
        public double WOE { get; set; }
    }
}
