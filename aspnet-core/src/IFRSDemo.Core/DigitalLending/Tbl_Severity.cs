using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.DigitalLending
{
    [Table("Tbl_Severity")]
    public class Tbl_Severity : Entity<int>
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Severity { get; set; }
    }
}
