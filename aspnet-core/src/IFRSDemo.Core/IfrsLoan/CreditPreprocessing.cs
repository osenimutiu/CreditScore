using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Credit_Preprocessing")]
    public class CreditPreprocessing : FullAuditedEntity
    {

        [Column(TypeName = "nvarchar(50)")]
        public virtual string Name { get; set; }
        public virtual int NumNull { get; set; }
        public virtual double OutlIer { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public virtual string Components { get; set; }
        public virtual int Num { get; set; }
        [Column(TypeName = "nvarchar(850)")]
        public virtual int Combination { get; set; }
    }
}
