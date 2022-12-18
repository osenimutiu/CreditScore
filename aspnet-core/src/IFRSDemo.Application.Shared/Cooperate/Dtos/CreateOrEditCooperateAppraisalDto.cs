using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class CreateOrEditCooperateAppraisalDto : EntityDto<int?>
    {

        public string CompanyName { get; set; }

        public string RCNumber { get; set; }

        public string AccountNumber { get; set; }

        public int Score { get; set; }

        public int SetupQualitativeId { get; set; }

    }
}