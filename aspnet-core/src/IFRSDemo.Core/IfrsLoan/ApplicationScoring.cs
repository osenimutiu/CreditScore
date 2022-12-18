using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("ratingapplicationscoring")]
    public class ApplicationScoring : FullAuditedEntity, IMayHaveTenant
    {
      
        public virtual int? ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductTypeAttribute ProductTypeAttributeFK { get; set; }

        public virtual int? ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        public ApplicantAttribute ApplicantAttributeFK { get; set; }

        public virtual int? Appld { get; set; }
        [ForeignKey("Appld")]
        public AppAttribute AppAttributeFK { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public virtual string LoanRequest { get; set; }
        public virtual double Amount { get; set; }
        public virtual int TenorMonth { get; set; }
        public virtual int? AgeAttributeId { get; set; }
        [ForeignKey("AgeAttributeId")]
        public AgeAttribute AgeAttributeFK { get; set; }

        public virtual int? IncomeAttributeId { get; set; }
        [ForeignKey("IncomeAttributeId")]
        public IncomeAttribute IncomeAttributeFK { get; set; }

        public virtual int? LocationAttributeId { get; set; }
        [ForeignKey("LocationAttributeId")]
        public LocationAttribute LocationAttributeFK { get; set; }

        public virtual int? RentAttributeId { get; set; }
        [ForeignKey("RentAttributeId")]
        public RentAttribute RentAttributeFK { get; set; }

        public virtual int? RenttoIncomeAttributeId { get; set; }
        [ForeignKey("RenttoIncomeAttributeId")]
        public RenttoIncomeAttribute RenttoIncomeAttributeFK { get; set; }

        public virtual int? ReturnonAssetsAttributeId { get; set; }
        [ForeignKey("ReturnonAssetsAttributeId")]
        public ReturnonAssetsAttribute ReturnonAssetsAttributeFK { get; set; }

        public virtual int? SubSectorAttributeId { get; set; }
        [ForeignKey("SubSectorAttributeId")]
        public SubSectorAttribute SubSectorAttributeFK { get; set; }

        public virtual string ExtraParam1 { get; set; }
        public virtual int ExtraParam2 { get; set; }
        public int? TenantId { get; set; }
    }
}
