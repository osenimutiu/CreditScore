using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_Scaling")]
   public class Scaling : Entity<int>
    {
        public string Items { get; set; }
        public double Values { get; set; }
    }
    public class Tbl_AttributeCount : Entity<int>
    {
        public int AttributeCount { get; set; }
    }
}
