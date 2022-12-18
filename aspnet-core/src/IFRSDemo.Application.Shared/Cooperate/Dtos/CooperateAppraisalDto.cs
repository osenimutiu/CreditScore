using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class CooperateAppraisalDto : EntityDto
    {
        public string CompanyName { get; set; }

        public string RCNumber { get; set; }

        public string AccountNumber { get; set; }

        public int Score { get; set; }
        public int TenantId { get; set; }
        public int SetupQualitativeId { get; set; }

    }
}