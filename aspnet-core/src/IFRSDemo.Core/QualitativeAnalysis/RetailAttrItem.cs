using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
    [Table("Retail_Attributes")]
    public class RetailAttrItem : Entity<int>
    {
        public string Attributes { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
    }
}
