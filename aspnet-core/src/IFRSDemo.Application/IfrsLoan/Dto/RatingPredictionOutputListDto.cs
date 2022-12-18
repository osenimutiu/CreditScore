using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace IFRSDemo.IfrsLoan.Dto
{
    [AutoMapFrom(typeof(RatingPredictionOutput))]
    public class RatingPredictionOutputListDto : FullAuditedEntityDto
    {

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public double? Score { get; set; }
        public string App_Type { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Risk_Level { get; set; }
        public double? PD { get; set; }
        public double? Good_Bad_Odd { get; set; }
        public double? Debt_Income_Ratio { get; set; }
        public double? Interest_Rate { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string Recommendation { get; set; }
    }
}
