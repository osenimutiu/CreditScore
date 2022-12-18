using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("Tbl_GiniCurve")]
    public class GiniCurve : Entity<int>
    {
        public bool Good_Bad { get; set; }
        public double? Score { get; set; }
        public double? Defaulters { get; set; }
        public int? CustomersTotal { get; set; }
        public double? Cumm_Perc_Defaulters { get; set; }
        public double? Cumm_Perc_Customers { get; set; }
        public double? AUC { get; set; }
    }
}
