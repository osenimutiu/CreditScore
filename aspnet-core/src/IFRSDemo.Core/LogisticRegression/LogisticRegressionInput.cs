using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.LogisticRegression
{
    [Table("Tbl_LogisticRegressionInputs")]
    public class LogisticRegressionInput : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual double Location { get; set; }

        public virtual double Rent_bin { get; set; }

        public virtual double Rent_to_Income_bin { get; set; }

        public virtual double Return_on_Assets_bin { get; set; }

        public virtual double Total_assets_bin { get; set; }

        public virtual bool Good_Bad { get; set; }

        public virtual bool Training_Test { get; set; }

    }
}