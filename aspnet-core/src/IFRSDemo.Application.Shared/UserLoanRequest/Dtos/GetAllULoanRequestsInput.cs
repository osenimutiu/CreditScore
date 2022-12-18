using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.UserLoanRequest.Dtos
{
    public class GetAllULoanRequestsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string LoanTypeFilter { get; set; }

        public decimal? MaxAmountFilter { get; set; }
        public decimal? MinAmountFilter { get; set; }

        public int? MaxTenorFilter { get; set; }
        public int? MinTenorFilter { get; set; }

        public string StatusFilter { get; set; }

    }
}