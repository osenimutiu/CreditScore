using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.LogisticRegression
{
    [Table("Tbl_RegOutput")]
   public class RegOutput : Entity
    {
        public string ParamName { get; set; }
        public double Coeff_Estimate { get; set; }
        public double Std_Error { get; set; }
        public double t_value { get; set; }
        public double p_value { get; set; }

    }
}
