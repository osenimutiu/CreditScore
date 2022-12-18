using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace IFRSDemo.Curves
{
    [Table("Viewbincountpercentage")]
    public class Viewbincountpercentage : Entity<int>
    {
        public string attribute { get; set; }
        [Column(TypeName =("varchar(500)"))]
        public string binning { get; set; }
        public double percentage { get; set; }
    }
}
