using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.LogisticRegression
{
    [Table("Tbl_Regression")]
    public class LogRegression : Entity
    {
        public virtual double Location { get; set; }
        public virtual double Rent_bin { get; set; }
        public virtual double Rent_to_Income_bin { get; set; }
        public virtual double Return_on_Assets_bin { get; set; }
        public virtual double Total_assets_bin { get; set; }
        public virtual bool Good_Bad { get; set; }
        public virtual string Training_Test { get; set; }
    }
}
