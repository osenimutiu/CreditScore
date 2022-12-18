using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("Tbl_KSTestCurve")]
   public class KSTestCurve : Entity<int>
    {
        public int? Score { get; set; }
        public int? Range { get; set; }
        public int? Good { get; set; }
         public int? Bad { get; set; }
         public int? Cumm_Good { get; set; }
         public int? Cumm_Bad { get; set; }
         public double? Cumm_Perc_Good { get; set; }
         public double? Cumm_Perc_Bad { get; set; }
         public double? Cumm_Perc_Diff { get; set; }
         public int? Cumm_Pop_Good { get; set; }
         public int? Cumm_Pop_Bad { get; set; }
         public int? Volume_Accepted { get; set; }
         public double? Cumm_Accp_Perc { get; set; }
        public double? Cumm_Bad_Rate { get; set; }
    }
}
