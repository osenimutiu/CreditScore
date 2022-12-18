using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_GenderType")]
    public class GenderType : Entity<int>
    {
        public virtual string Type { get; set; }
    }
}
