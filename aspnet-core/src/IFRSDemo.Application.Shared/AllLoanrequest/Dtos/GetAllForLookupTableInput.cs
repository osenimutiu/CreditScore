using Abp.Application.Services.Dto;

namespace IFRSDemo.AllLoanrequest.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}