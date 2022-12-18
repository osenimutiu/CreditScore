using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(ScoringOutput))]
    public class ScoringOutputListDto : FullAuditedEntityDto
    {
        public double Score { get; set; }
        public string Risk_Level { get; set; }
        public double PD { get; set; }
        public double Good_Bad_Odd { get; set; }
        public double Interest_Rate { get; set; }
        public string Recommendation { get; set; }
        public string App_Type { get; set; }
        public double Debt_Income_Ratio { get; set; }
    }
}
