using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Tbl_Histograms")]
    public class Histogram : FullAuditedEntity
    {
        public const int MaxfeaturenameLength = 32;
        public const int MaxlowerBoundLength = 32;
        public const int MaxupperBoundLength = 32;

        [Required]
        [MaxLength(MaxfeaturenameLength)]
        public virtual string featurename { get; set; }

        [Required]
        [MaxLength(MaxlowerBoundLength)]
        public virtual string lowerBound { get; set; }

        [Required]
        [MaxLength(MaxupperBoundLength)]
        public virtual double upperBound { get; set; }
        public virtual double count { get; set; }
        public virtual double percent { get; set; }
        public virtual string UpdatedBy { get; set; }


        // public virtual Component Component { get; set; }
        //public virtual int? ComponentId { get; set; }

        //[ForeignKey("ComponentId")]
        //public Component ComponentIdFk { get; set; }
    }
}
