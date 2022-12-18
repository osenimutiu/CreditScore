using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllCooperateAppraisalsForExcelInput
    {
        public string Filter { get; set; }

        public string CompanyNameFilter { get; set; }

        public string RCNumberFilter { get; set; }

        public string AccountNumberFilter { get; set; }

        public int? MaxScoreFilter { get; set; }
        public int? MinScoreFilter { get; set; }

        public string SetupQualitativeQualitativeFilter { get; set; }

    }
}