using Abp.Application.Services.Dto;

namespace IFRSDemo.Regression.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}