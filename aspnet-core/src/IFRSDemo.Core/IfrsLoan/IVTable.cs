using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("IV_Table")]
    public class IVTable : FullAuditedEntity
    {

        [Column(TypeName = "nvarchar(200)")]
        public virtual string Characteristic { get; set; }

        public virtual double IV { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public virtual string Inference { get; set; }
    }
}
