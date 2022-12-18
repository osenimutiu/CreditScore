using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.Curves
{
   public class Tbl_GoodBadInput :Entity
    {
        public int? Good { get; set; }
        public int? Bad { get; set; }
        public string GoodLabel { get; set; }
        public string BadLabel { get; set; }
    }
}
