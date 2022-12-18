using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("IncomeAttributes")]
    public class IncomeAttribute : FullAuditedEntity
    {
        public virtual string IncomeRange { get; set; }
    }
}
