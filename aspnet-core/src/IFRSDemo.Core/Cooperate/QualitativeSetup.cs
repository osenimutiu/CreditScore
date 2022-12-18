using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Cooperate
{
    [Table("QualitativeSetups")]
    public class QualitativeSetup : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string Section { get; set; }

        public virtual string SubHeading { get; set; }

        public virtual string Qualitative { get; set; }

        public virtual int Value { get; set; }

        public virtual bool Status { get; set; }

    }
}