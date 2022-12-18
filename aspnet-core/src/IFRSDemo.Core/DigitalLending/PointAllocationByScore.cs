using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.DigitalLending
{
    [Table("DL_Point_Allocation_By_Score")]
    public class PointAllocationByScore : Entity<int>
    {
        public string Refno { get; set; }
        public string Characteristic { get; set; }
        public string Attribute { get; set; }
        public double Score { get; set; }  
    }
}
