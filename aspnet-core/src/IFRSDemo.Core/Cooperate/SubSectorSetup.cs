using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Cooperate
{
    [Table("SubSectorSetups")]
    public class SubSectorSetup : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public virtual string Section { get; set; }

        public virtual string SubHeading { get; set; }

    }
}