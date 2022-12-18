using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("ReturnonAssetsAttributes")]
    public class ReturnonAssetsAttribute : FullAuditedEntity
    {
        public virtual string ReturnonAssets { get; set; }
    }
}
