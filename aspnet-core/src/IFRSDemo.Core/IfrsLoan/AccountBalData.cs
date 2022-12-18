using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("account_bal_data")]
    public class AccountBalData : FullAuditedEntity
    {
       
        [Column(TypeName = "varchar(150)")]
        public virtual string Name { get; set; }
        public virtual int? Age { get; set; }
        public virtual int? Income { get; set; }
        public virtual int? Rent_Range { get; set; }
        public virtual int? Rent_Income { get; set; }
        public virtual int? ROA { get; set; }
        public virtual int? Sector { get; set; }
        public virtual int? Location { get; set; }
        public virtual int? DTSR { get; set; }
        public virtual double? OutBal { get; set; }
        public virtual double? coverage { get; set; }
        public virtual double? bal_other_fi { get; set; }

    }
}
