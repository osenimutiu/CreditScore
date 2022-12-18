using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.Curves
{
    [Table("CRTD_Population_Stability_Report")]
    public class Tbl_Psi : Entity<int>
    {
        
        public string Score_Bands { get; set; }
        public double Actual { get; set; }
        public double Expected { get; set; }
        public double Actual_Expected { get; set; }
        public double Ln_Actual_Expected { get; set; }
        public double INDEX { get; set; }
        public double PSI { get; set; }
    }
}
