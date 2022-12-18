using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Caliberation
{
    [Table("Tbl_GiniInclusives")]
    public class GiniInclusive : Entity<int>
    {
        public bool Good_Bad { get; set; }
        public double? Score { get; set; }
        public int? CumNoDefaulters { get; set; }
        public int? CumNoApplicants { get; set; }
        public double? CumPercDefaulters { get; set; }
        public double? CumPercApplicants { get; set; }
        public double? AreaUnderCAP { get; set; }
        public double? Y_fit { get; set; }
        public double? Residual { get; set; }
        public double? ResSquare { get; set; }
    }
}
