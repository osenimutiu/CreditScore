using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("Tbl_CharacteristicsAnalysis")]
    public class CharacteristicsAnalysis : Entity<int>
    {
        public string Attributes { get; set; }
        public string Bins { get; set; }
        public int DevFrequency { get; set; }
        public int RecFrequency { get; set; }
        public double DevFrequencyPerc { get; set; }
        public double RecFrequencyPerc { get; set; }
        public int SCPoints { get; set; }
        public double Index { get; set; }
    }
}
