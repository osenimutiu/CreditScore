using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.LogisticRegression
{
    [Table("Tbl_RegOutputRunDate")]
   public class RegOutputRunData : Entity<int>
    {
        public DateTime RunDate { get; set; }
    }
}
