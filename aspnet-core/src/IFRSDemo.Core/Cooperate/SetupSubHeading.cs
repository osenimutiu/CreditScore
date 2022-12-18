using IFRSDemo.Cooperate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Cooperate
{
    [Table("SetupSubHeadings")]
    public class SetupSubHeading : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string SubHeading { get; set; }

        public virtual int SectionSetupId { get; set; }

        [ForeignKey("SectionSetupId")]
        public SectionSetup SectionSetupFk { get; set; }

    }
}