using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ManualUpload
{
    [Table("Tbl_GoodBad")]
    public class GoodBad : Entity<int>
    {
        public int? Good { get; set; }
        public int? Bad { get; set; }
        public string GoodLabel { get; set; }
        public string BadLabel { get; set; }

    }
}
