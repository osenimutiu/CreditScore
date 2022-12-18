using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.AllLoanrequest.Dtos
{
    public class LoanRequestDto : EntityDto
    {
        public string Customer { get; set; }

        public string LoanType { get; set; }

        public decimal Amount { get; set; }

        public int Tenor { get; set; }

        public string Statua { get; set; }

    }
}