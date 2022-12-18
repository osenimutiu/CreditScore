using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("ProductTypeAttributes")]
    public class ProductTypeAttribute : FullAuditedEntity
    {
        public virtual string ProductType { get; set; }
    }
}
