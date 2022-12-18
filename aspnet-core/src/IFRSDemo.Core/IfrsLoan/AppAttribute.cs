using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
    [Table("AppType")]
    public class AppAttribute: FullAuditedEntity
    {
        public virtual string ApplicanType { get; set; }
      
    }
}
