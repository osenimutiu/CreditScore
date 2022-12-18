using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_Bank")]
    public class Bank : Entity<int>
    {
        public virtual string BankNames { get; set; }
    }
}
