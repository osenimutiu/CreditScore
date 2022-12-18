using IFRSDemo.Cooperate;
using IFRSDemo.Cooperate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Cooperate
{
    [Table("SetupQualitatives")]
    public class SetupQualitative : Entity/*, IMayHaveTenant*/
    {
        public int? TenantId { get; set; }

        public virtual string Qualitative { get; set; }

        public virtual int Value { get; set; }

        public virtual bool Status { get; set; }

        public virtual int SectionSetupId { get; set; }

        [ForeignKey("SectionSetupId")]
        public SectionSetup SectionSetupFk { get; set; }

        public virtual int SetupSubHeadingId { get; set; }

        [ForeignKey("SetupSubHeadingId")]
        public SetupSubHeading SetupSubHeadingFk { get; set; }

    }

    public class CooperateCustomer : Entity<int>
    {
        public string CompanyName { get; set; }
        public string RCNumber { get; set; }
        public string AccountNo { get; set; }
    }
    public class CooperateScore : Entity<int>
    {
        public int CompanyId { get; set; }
        public double Score { get; set; }
    }

    public class CooperateCutOff : Entity<int>
    {
        public double CuttOff { get; set; }
    }



}