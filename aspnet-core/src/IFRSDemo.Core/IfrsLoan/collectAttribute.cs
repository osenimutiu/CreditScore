using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.IfrsLoan
{
    [Table("collectAttribute")]
    public class collectAttribute : Entity<int>
    {
        public string attributes { get; set; }
    }
}
