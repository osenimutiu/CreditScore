using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace IFRSDemo.Cooperate.Dtos
{
    public class GetSetupSubHeadingForEditOutput
    {
        public CreateOrEditSetupSubHeadingDto SetupSubHeading { get; set; }

        public string SectionSetupSection { get; set; }

    }
}