using Abp.Application.Services.Dto;
using System;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetAllSetupQualitativesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string QualitativeFilter { get; set; }

        public int? MaxValueFilter { get; set; }
        public int? MinValueFilter { get; set; }

        public int? StatusFilter { get; set; }

        public string SectionSetupSectionFilter { get; set; }

        public string SetupSubHeadingSubHeadingFilter { get; set; }

    }
}