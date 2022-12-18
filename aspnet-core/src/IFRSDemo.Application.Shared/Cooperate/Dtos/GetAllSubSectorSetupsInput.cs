using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllSubSectorSetupsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string SectionFilter { get; set; }

        public string SubHeadingFilter { get; set; }

    }
}