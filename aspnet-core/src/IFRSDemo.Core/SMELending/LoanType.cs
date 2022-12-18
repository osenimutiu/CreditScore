using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_LoanType")]
    public class LoanType : Entity<int>
    {
        public virtual string LoanTypes { get; set; }
    }
}
