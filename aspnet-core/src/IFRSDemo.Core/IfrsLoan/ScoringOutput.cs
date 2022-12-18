using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Tbl_ScoringOutputs")]
    
    public class ScoringOutput : Entity<int>, IHasModificationTime, IMayHaveTenant
    {
        public const int MaxScoreLength = 32;
        public const int MaxRisk_LevelLength = 32;

        [Required]
        [MaxLength(MaxScoreLength)]
        public virtual double Score { get; set; }

        //public bool? IsDeleted { get; set; }
       
        [Required]
        [MaxLength(MaxRisk_LevelLength)]
        public virtual string Risk_Level { get; set; }
        public virtual double PD { get; set; }
        public virtual double Good_Bad_Odd { get; set; }
        public virtual double Interest_Rate { get; set; }
        public virtual string Recommendation { get; set; }
        public virtual string App_Type { get; set; }
        public virtual double Debt_Income_Ratio { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public int? TenantId { get; set; }
    }
}
