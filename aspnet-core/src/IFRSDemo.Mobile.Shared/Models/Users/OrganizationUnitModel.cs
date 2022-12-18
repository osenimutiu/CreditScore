using Abp.AutoMapper;
using IFRSDemo.Organizations.Dto;

namespace IFRSDemo.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}