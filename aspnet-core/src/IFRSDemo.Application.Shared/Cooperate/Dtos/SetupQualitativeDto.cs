using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class SetupQualitativeDto : EntityDto
    {
        public string Qualitative { get; set; }

        public int Value { get; set; }

        public bool Status { get; set; }

        public int SectionSetupId { get; set; }

        public int SetupSubHeadingId { get; set; }

    }
}