using Abp.Application.Services.Dto;

namespace IFRSDemo.UserLoanRequest.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}