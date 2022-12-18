using IFRSDemo.Cooperate;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Cooperate
{
    [Table("CooperateAppraisals")]
    public class CooperateAppraisal : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string RCNumber { get; set; }

        public virtual string AccountNumber { get; set; }

        public virtual int Score { get; set; }

        public virtual int SetupQualitativeId { get; set; }

        [ForeignKey("SetupQualitativeId")]
        public SetupQualitative SetupQualitativeFk { get; set; }

    }
}