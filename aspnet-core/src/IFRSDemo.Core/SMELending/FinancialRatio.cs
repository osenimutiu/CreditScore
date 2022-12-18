using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_FinancialRatio")]
    public class FinancialRatio : FullAuditedEntity, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public virtual string RatioName { get; set; }
        [Column(TypeName = "nvarchar(900)")]
        public virtual string RatioDefinition { get; set; }
    }
}
