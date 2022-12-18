using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace IFRSDemo.Cooperate
{
    [Table("SectionSetups")]
    public class SectionSetup : Entity, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string Section { get; set; }

        public int Position { get; set; }

        public bool Active { get; set; }

    }
}