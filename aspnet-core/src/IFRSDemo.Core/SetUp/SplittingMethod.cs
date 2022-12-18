using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SetUp
{
    [Table("Tbl_SplittingMethod")]
   public class SplittingMethod : Entity<int>
    {
        public string SplittingName { get; set; }
    }
}
