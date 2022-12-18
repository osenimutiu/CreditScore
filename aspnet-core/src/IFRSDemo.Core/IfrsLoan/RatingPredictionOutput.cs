using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Rating_Prediction_Output")]
    public class RatingPredictionOutput : Entity<int>, IHasModificationTime, IMayHaveTenant
    {

        [Column(TypeName = "nvarchar(50)")]
        public virtual string Name { get; set; }
        public virtual string App_Type { get; set; }
        public virtual double? Score { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public virtual string Risk_Level { get; set; }
        public virtual double? PD { get; set; }
        public virtual double? Good_Bad_Odd { get; set; }
        public virtual double? Debt_Income_Ratio { get; set; }
        public virtual double? Interest_Rate { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public virtual string Recommendation { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? TenantId { get; set; }
    }
}
