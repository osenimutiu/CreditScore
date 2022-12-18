using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IFRSDemo.ScoreCard
{
    [Table("CRTD_Score_Card_Scaling")]
    public class ScoreCardScaling : Entity<int>
    {
        public string ParameterGroup { get; set; }
        public string ParameterName { get; set; }
        public double Score_After_Regression { get; set; }
        public double Score_Card_Point { get; set; }
    }
}
