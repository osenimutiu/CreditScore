using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetSetupQualitativeForEditOutput
    {
        public CreateOrEditSetupQualitativeDto SetupQualitative { get; set; }

        public string SectionSetupSection { get; set; }

        public string SetupSubHeadingSubHeading { get; set; }

    }
}