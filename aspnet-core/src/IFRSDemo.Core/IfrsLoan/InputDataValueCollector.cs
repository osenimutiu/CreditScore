using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace IFRSDemo.IfrsLoan
{
    [Table("Selected_Attributes")]
    public class InputDataValueCollector : Entity<int>, IMayHaveTenant
    {
        [Column(TypeName = "nvarchar(900)")]
        public virtual string SelectedValues { get; set; }
        public int? TenantId { get; set; }
    }
}
