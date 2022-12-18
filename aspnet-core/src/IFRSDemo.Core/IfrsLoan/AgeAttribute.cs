using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("AgeGroup")]
    public class AgeAttribute : FullAuditedEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public virtual string AgeGroup { get; set; }
        public virtual double NumberOfLoans { get; set; }
        public virtual double NumberOfBadLoans { get; set; }
        public virtual double NumberOfGoodLoans { get; set; }
        public virtual double BadLoanPerc { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public virtual string BinGroup { get; set; }
        public virtual double DB { get; set; }
        public virtual double DG { get; set; }
        public virtual double WOE { get; set; }
        public virtual double DG_DB { get; set; }
        public virtual double WoeDGBG { get; set; }
        public virtual double ScoreAfterReg { get; set; }
        public virtual double ScorePoint { get; set; }
     
    }
}
