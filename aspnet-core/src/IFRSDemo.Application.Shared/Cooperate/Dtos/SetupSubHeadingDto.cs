using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class SetupSubHeadingDto : EntityDto
    {
        public string SubHeading { get; set; }

        public int SectionSetupId { get; set; }

    }
}