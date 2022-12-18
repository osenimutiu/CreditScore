using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("credit_preprocessingb")]
    public class PreProcessing : FullAuditedEntity
    {
        public virtual string name { get; set; }
        public virtual int num_null { get; set; }
        public virtual double outl_ier { get; set; }
        public virtual string components { get; set; }
        public virtual int num { get; set; }
        public virtual string combination { get; set; }
    }
}
