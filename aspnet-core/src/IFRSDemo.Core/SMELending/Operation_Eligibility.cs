using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_Operation_Eligibity")]
    public class Operation_Eligibility : Entity<int>
    {
        public virtual string Option { get; set; }
    }
}
