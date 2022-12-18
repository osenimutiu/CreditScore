using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Regression
{
    [Table("Tbl_RegressionOutputs")]
    public class RegressionOutput : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        [Required]
        public virtual string ParamName { get; set; }

        public virtual double Coeff_Estimate { get; set; }

        public virtual double Std_Error { get; set; }

        public virtual double t_value { get; set; }

        public virtual double p_value { get; set; }

    }
}