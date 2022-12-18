using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Tbl_Attributes")]
    public class InputData :  FullAuditedEntity
    {
        public virtual string Attributes { get; set; }
    }
}
