using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
    [Table("Tbl_SCMonitoring")]
    public class SCMonitoring : Entity<int>
    {
        public int Scores { get; set; }
        public int Bin_name { get; set; }
        public bool Approved { get; set; }
        public bool Rejected { get; set; }
    }

    public class BinRange : Entity<int>
    {
        public string Range { get; set; }
    }
}
