using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}