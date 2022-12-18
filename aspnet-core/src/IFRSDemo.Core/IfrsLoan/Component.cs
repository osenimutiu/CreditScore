using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Tbl_Components")]
    public class Component : FullAuditedEntity
    {
        public const int MaxNameLength = 32;
    
        [Required]
        [MaxLength(MaxNameLength)]
        [Column(TypeName="varchar(100)")]
        public virtual string Name { get; set; }
      
        //// public virtual ICollection<Histogram> Tbl_Histograms { get; set; }
    }
}
