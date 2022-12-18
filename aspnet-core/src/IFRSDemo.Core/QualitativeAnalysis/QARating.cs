using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.QualitativeAnalysis
{
    [Table("Tbl_QualitativeAnalysisRating")]
    public class QARating : Entity<int>
    {
        public string Rating { get; set; }
        [Column(TypeName = "varchar(500)")] 
        public string RatingDescription { get; set; }
        public int Score { get; set; }
        public int Range { get; set; }
    }
    public class RatingAttribute : Entity<int>
    {
        public string Items { get; set; }
    }
    public class Tbl_Rating : Entity<int>
    {
        public string Rating { get; set; }
    }
}
