using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.SMELending
{
    [Table("Tbl_SMETitle")]
    public class SMETitle: Entity<int>
    {
        public virtual string IndivividualTitle { get; set; }
    }
}
