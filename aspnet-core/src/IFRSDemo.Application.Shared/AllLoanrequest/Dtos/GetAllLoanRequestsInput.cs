using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.AllLoanrequest.Dtos
{
    public class GetAllLoanRequestsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string CustomerFilter { get; set; }

        public string LoanTypeFilter { get; set; }

        public decimal? MaxAmountFilter { get; set; }
        public decimal? MinAmountFilter { get; set; }

        public int? MaxTenorFilter { get; set; }
        public int? MinTenorFilter { get; set; }

        public string StatuaFilter { get; set; }

    }
}