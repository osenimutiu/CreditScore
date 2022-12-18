using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.UserLoanRequest.Dtos
{
    public class ULoanRequestDto : EntityDto
    {
        public string LoanType { get; set; }

        public decimal Amount { get; set; }

        public int Tenor { get; set; }

        public string Status { get; set; }

    }
}