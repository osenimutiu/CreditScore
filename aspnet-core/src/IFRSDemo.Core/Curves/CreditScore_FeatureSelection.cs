using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("CreditScore_FeatureSelection")]
    public class CreditScore_FeatureSelection : Entity
    {
        [Column(TypeName = "varchar(250)")]
        public string Characteristic { get; set; }
        public double IV { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Inference { get; set; }
        public bool SelectStatus { get; set; }
    }
}
