using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapTo(typeof(ScoringOutput))]
    public class CreateScoringOutputInput
    {
        [MaxLength(ScoringOutput.MaxScoreLength)]
        public double Score { get; set; }
        [MaxLength(ScoringOutput.MaxRisk_LevelLength)]
        public string Risk_Level { get; set; }
        public double PD { get; set; }
        public double Good_Bad_Odd { get; set; }
        public double Interest_Rate { get; set; }
        public string Recommendation { get; set; }
        public string App_Type { get; set; }
        public double Debt_Income_Ratio { get; set; }
        public int? TenantId { get; set; }
    }
}
