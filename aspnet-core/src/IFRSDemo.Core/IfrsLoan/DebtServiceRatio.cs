using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("debt_service_ratio")]
    public class DebtServiceRatio : FullAuditedEntity
    {
        public virtual double? LB { get; set; }
        public virtual double? UP { get; set; }
        public virtual double? amount { get; set; }
        public virtual int? DTSR { get; set; }
        [Column(TypeName = "varchar(50)")]
        public virtual string coverage { get; set; }
        public virtual double? grant_amt { get; set; }
    }
}
