using System;
using Abp.Application.Services.Dto;

namespace IFRSDemo.Cooperate.Dtos
{
    public class QualitativeSetupDto : EntityDto
    {
        public string Section { get; set; }

        public string SubHeading { get; set; }

        public string Qualitative { get; set; }

        public int Value { get; set; }

        public bool Status { get; set; }

    }
}