using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("AllScores")]
    public class AllScore : FullAuditedEntity
    {
        [Column(TypeName = "bigint")]
        public virtual int? ln { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public virtual string Group { get; set; }
        public virtual double Pd { get; set; }
        public virtual double Score { get; set; }
        public virtual int Item { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public virtual string ItemName { get; set; }
        
    }
}
